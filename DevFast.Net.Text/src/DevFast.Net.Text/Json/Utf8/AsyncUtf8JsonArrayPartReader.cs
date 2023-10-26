using DevFast.Net.Extensions.SystemTypes;
using System.Text;

namespace DevFast.Net.Text.Json.Utf8
{
    /// <summary>
    /// Class implementing <see cref="IAsyncJsonArrayPartReader"/> for standard Utf-8 JSON data encoding
    /// based on https://datatracker.ietf.org/doc/html/rfc7159 (grammar shown at https://www.json.org/json-en.html).
    /// <para>
    /// Current implementation parses following two (2) types and three (3) literal values 'null', 'true', 'false' without any validation:
    /// </para>
    /// <para>
    /// 1. Unicode code-points values (i.e. in \uXXXX, X can be any valid byte value).
    /// </para>
    /// 2. Numeric values (both 2.0e-1+10 and 2.0Ee10 will be parsed as Numeric values without error).
    /// <para>
    /// The main reason to ignore validation is that such error MUST be thrown during deserialization.
    /// Also, to keep the code simple and faster.
    /// </para>
    /// This implementation support both single line comments (starting with '//' and ending in either Carriage return '\r'
    /// or newline '\n') and multiline comments (starting with '/*' and ending with '*/').
    /// </summary>
    public sealed class AsyncUtf8JsonArrayPartReader : IAsyncJsonArrayPartReader
    {
        private readonly bool _disposeStream;
        private Stream? _stream;
        private byte[] _buffer;
        private int _begin, _end, _current;
        private long _bytesConsumed;

        /// <summary>
        /// Convenient <see langword="static"/> <see langword="async"/> method, to create
        /// well initialized instance of type <see cref="IAsyncJsonArrayPartReader"/>.
        /// </summary>
        /// <param name="stream">A readable stream containing JSON array data.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <param name="size">Initial size of underlying byte buffer. Any value less than
        /// <see cref="JsonConst.RawUtf8JsonPartReaderMinBuffer"/> will be ignored.</param>
        /// <param name="disposeStream"><see langword="true"/> to dispose <paramref name="stream"/> when either
        /// current instance of <see cref="IAsyncJsonArrayPartReader"/> itself disposing or
        /// when <paramref name="stream"/> is completely read; <see langword="false"/> otherwise.</param>
        public static async ValueTask<IAsyncJsonArrayPartReader> CreateInstanceAsync(Stream stream,
            CancellationToken token,
            int size = JsonConst.RawUtf8JsonPartReaderMinBuffer,
            bool disposeStream = false)
        {
            if (!stream.CanRead) throw new ArgumentException($"{nameof(stream)} should support Read operation!");
            var buffer = new byte[Math.Max(JsonConst.RawUtf8JsonPartReaderMinBuffer, size)];
            var end = await stream.ReadAsync(buffer, token).ConfigureAwait(false);
            var begin = 0;
            var bom = Encoding.UTF8.GetPreamble();
            if (end >= bom.Length &&
                bom[0] == buffer[0] &&
                bom[1] == buffer[1] &&
                bom[2] == buffer[2])
            {
                begin = 3;
            }
            return new AsyncUtf8JsonArrayPartReader(stream, buffer, begin, end, disposeStream);
        }

        private AsyncUtf8JsonArrayPartReader(Stream stream, byte[] buffer, int begin, int end, bool disposeStream)
        {
            _stream = stream;
            _buffer = buffer;
            _current = _begin = begin;
            _bytesConsumed = _begin;
            _end = end;
            _disposeStream = disposeStream;
        }

        /// <summary>
        /// <see langword="true"/> indicating that reader has reached end of JSON input,
        /// otherwise <see langword="false"/>.
        /// </summary>
        public bool EoJ => _stream == null && _current == _end;

        /// <summary>
        /// <see cref="byte"/> value of current position of reader. <see langword="null"/> when
        /// reader has reached <see cref="EoJ"/>.
        /// </summary>
        public byte? Current => EoJ ? null : _buffer[_current];

        /// <summary>
        /// Total number of <see cref="byte"/>s observed by the reader since the very beginning (0-based position).
        /// </summary>
        public long Position => _bytesConsumed + (_current - _begin);
        private bool InRange => _current < _end;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        public async ValueTask ReadIsBeginArrayWithVerifyAsync(CancellationToken token)
        {
            if (!await ReadIsBeginArrayAsync(token).ConfigureAwait(false))
            {
                if (InRange)
                {
                    throw new JsonArrayPartParsingException("Invalid byte value for JSON begin-array. " +
                                                   $"Expected = {JsonConst.ArrayBeginByte}, " +
                                                   $"Found = {_buffer[_current]}, " +
                                                   $"0-Based Position = {Position}.");
                }
                throw new JsonArrayPartParsingException("Reached end, unable to find JSON begin-array." +
                                               $"0-Based Position = {Position}.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ensureEoj"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public IAsyncEnumerable<byte[]> EnumerateRawJsonArrayElementAsync(bool ensureEoj, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<bool> ReadIsBeginArrayAsync(CancellationToken token)
        {
            return await ReadIsGivenByteAsync(JsonConst.ArrayBeginByte, token).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ensureEoj"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<bool> ReadIsEndArrayAsync(bool ensureEoj, CancellationToken token)
        {
            return await ReadIsGivenByteAsync(JsonConst.ArrayEndByte, token).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <param name="withVerify"></param>
        /// <returns></returns>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        public async ValueTask<byte[]> GetCurrentRawAsync(CancellationToken token, bool withVerify = true)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            if (!InRange || _buffer[_current] == JsonConst.ArrayEndByte) return Array.Empty<byte>();
            await ReDefineBufferAsync(0, token).ConfigureAwait(false);
            await SkipUntilNextRawAsync(token).ConfigureAwait(false);
            var currentRaw = new byte[_current - _begin];
            _buffer.CopyToUnSafe(currentRaw, _begin, currentRaw.Length, 0);
            //We want to intentionally keep 'withVerify' after ',' check!
            //to either validate everything or nothing
            if(withVerify)
            {
                await ReadIsValueSeparationOrEndWithVerifyAsync(JsonConst.ArrayEndByte,
                        "array",
                        "',' or ']' (but not ',]')",
                        token)
                    .ConfigureAwait(false);
            }
            else
            {
                await ReadIsGivenByteAsync(JsonConst.ValueSeparatorByte, token).ConfigureAwait(false);
            }
            return currentRaw;            
        }

        private async ValueTask SkipUntilNextRawAsync(CancellationToken token)
        {
            switch (_buffer[_current])
            {
                case JsonConst.ArrayBeginByte:
                    await SkipArrayAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.ObjectBeginByte:
                    await SkipObjectAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.StringQuoteByte:
                    await SkipStringAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.MinusSignByte:
                case JsonConst.Number0Byte:
                case JsonConst.Number1Byte:
                case JsonConst.Number2Byte:
                case JsonConst.Number3Byte:
                case JsonConst.Number4Byte:
                case JsonConst.Number5Byte:
                case JsonConst.Number6Byte:
                case JsonConst.Number7Byte:
                case JsonConst.Number8Byte:
                case JsonConst.Number9Byte:
                    await SkipNumberAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.FirstOfTrueByte:
                    await SkipRueOfTrueWithoutValidationAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.FirstOfFalseByte:
                    await SkipAlseOfFalseWithoutValidationAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.FirstOfNullByte:
                    await SkipUllOfNullWithoutValidationAsync(token).ConfigureAwait(false);
                    break;
                default:
                    throw new JsonArrayPartParsingException($"Invalid byte value for start of JSON element. " +
                                                   $"Found = {_buffer[_current]}, " +
                                                   $"0-Based Position = {Position}.");
            }
        }

        private async ValueTask SkipArrayAsync(CancellationToken token)
        {
            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
            {
                await SkipWhiteSpaceWithVerifyAsync("]", token).ConfigureAwait(false);
                while (_buffer[_current] != JsonConst.ArrayEndByte)
                {
                    await SkipUntilNextRawAsync(token).ConfigureAwait(false);
                    await ReadIsValueSeparationOrEndWithVerifyAsync(JsonConst.ArrayEndByte,
                            "array",
                            "',' or ']' (but not ',]')",
                            token)
                        .ConfigureAwait(false);
                }
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                return;
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find valid JSON end-array (']'). " +
                                           $"0-Based Position = {Position}.");
        }

        private async ValueTask SkipObjectAsync(CancellationToken token)
        {
            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
            {
                await SkipWhiteSpaceWithVerifyAsync("}", token).ConfigureAwait(false);
                while (_buffer[_current] != JsonConst.ObjectEndByte)
                {
                    if (_buffer[_current] != JsonConst.StringQuoteByte)
                    {
                        throw new JsonArrayPartParsingException($"Invalid byte value for start of Object Property Name. " +
                            $"Expected = {JsonConst.StringQuoteByte}, " +
                            $"Found = {_buffer[_current]}, " +
                            $"0-Based Position = {Position}.");
                    }
                    await SkipStringAsync(token).ConfigureAwait(false);
                    await SkipWhiteSpaceWithVerifyAsync(":", token).ConfigureAwait(false);
                    _current--;
                    await NextExpectedOrThrowAsync(JsonConst.NameSeparatorByte, token, "Object property").ConfigureAwait(false);
                    await SkipWhiteSpaceWithVerifyAsync("Object property value", token).ConfigureAwait(false);
                    await SkipUntilNextRawAsync(token).ConfigureAwait(false);
                    await ReadIsValueSeparationOrEndWithVerifyAsync(JsonConst.ObjectEndByte,
                            "Object property",
                            "',' or '}' (but not ',}')",
                            token)
                        .ConfigureAwait(false);
                }
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                return;
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find valid JSON end-object ('}}'). " +
                                           $"0-Based Position = {Position}.");
        }

        private async ValueTask ReadIsValueSeparationOrEndWithVerifyAsync(byte end, string partOf, string expected, CancellationToken token)
        {
            if (await ReadIsValueSeparationOrEndAsync(end, token).ConfigureAwait(false)) return;
            if (InRange)
            {
                throw new JsonArrayPartParsingException($"Invalid byte value for '{partOf}'. " +
                    $"Expected = {expected}, " +
                    $"Found = {_buffer[_current]}, " +
                    $"0-Based Position = {Position}.");
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find '{end}'. " +
                                           $"0-Based Position = {Position}.");
        }

        private async ValueTask<bool> ReadIsValueSeparationOrEndAsync(byte end, CancellationToken token)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            if (!InRange) return false;
            if (_buffer[_current] == end) return true;
            if (_buffer[_current] != JsonConst.ValueSeparatorByte) return false;
            _current++;
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            return InRange && _buffer[_current] != end;
        }

        private async ValueTask SkipStringAsync(CancellationToken token)
        {
            while (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
            {
                switch (_buffer[_current])
                {
                    case JsonConst.ReverseSlashByte:
                        if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
                        {
                            switch (_buffer[_current])
                            {
                                case JsonConst.ReverseSlashByte:
                                case JsonConst.ForwardSlashByte:
                                case JsonConst.StringQuoteByte:
                                case JsonConst.LastOfBackspaceInStringByte:
                                case JsonConst.FirstOfFalseByte:
                                case JsonConst.FirstOfNullByte:
                                case JsonConst.FirstOfTrueByte:
                                case JsonConst.LastOfCarriageReturnInStringByte:
                                    continue;
                                case JsonConst.SecondOfHexDigitInStringByte:
                                    //JsonSerializer must handle validation!
                                    //we skip 4 bytes
                                    if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                        await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                        await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                        await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
                                    {
                                        continue;
                                    }
                                    throw new JsonArrayPartParsingException($"Reached end, unable to find valid Hex-Digits. " +
                                                                   $"0-Based Position = {Position}.");
                                default:
                                    throw new JsonArrayPartParsingException($"Bad JSON escape. " +
                                        $"Expected = \\{JsonConst.ReverseSlashByte} or " +
                                        $"\\{JsonConst.ForwardSlashByte} or " +
                                        $"\\{JsonConst.StringQuoteByte} or " +
                                        $"\\{JsonConst.LastOfBackspaceInStringByte} or " +
                                        $"\\{JsonConst.FirstOfFalseByte} or " +
                                        $"\\{JsonConst.FirstOfNullByte} or " +
                                        $"\\{JsonConst.FirstOfTrueByte} or " +
                                        $"\\{JsonConst.LastOfCarriageReturnInStringByte} or " +
                                        $"\\{JsonConst.SecondOfHexDigitInStringByte}4Hex, " +
                                        $"Found = \\{_buffer[_current]}, " +
                                        $"0-Based Position = {Position}.");
                            }
                        }
                        throw new JsonArrayPartParsingException($"Reached end, unable to find valid escape character. " +
                                                       $"0-Based Position = {Position}.");
                    case JsonConst.StringQuoteByte:
                        await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                        return;
                }
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find end-of-string quote '\"'. " +
                                           $"0-Based Position = {Position}.");
        }

        private async ValueTask SkipNumberAsync(CancellationToken token)
        {
            //we just take everything until begin of next token (even if number is not valid!)
            //number parsing rules are too much to write here
            //Serializer will do its job during deserialization
            while (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
            {
                switch (_buffer[_current])
                {
                    case JsonConst.MinusSignByte:
                    case JsonConst.PlusSignByte:
                    case JsonConst.ExponentLowerByte:
                    case JsonConst.ExponentUpperByte:
                    case JsonConst.DecimalPointByte:
                    case JsonConst.Number0Byte:
                    case JsonConst.Number1Byte:
                    case JsonConst.Number2Byte:
                    case JsonConst.Number3Byte:
                    case JsonConst.Number4Byte:
                    case JsonConst.Number5Byte:
                    case JsonConst.Number6Byte:
                    case JsonConst.Number7Byte:
                    case JsonConst.Number8Byte:
                    case JsonConst.Number9Byte:
                        continue;
                    default: return;
                }
            }
        }

        private async ValueTask SkipRueOfTrueWithoutValidationAsync(CancellationToken token)
        {
            //JsonSerializer must handle validation!
            //we skip 3 bytes
            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
            {
                //this one to move the pointer forward, we don't care
                //about EoF, that's handled by next read!
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                return;
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing 'true' literal. " +
                                                    $"0-Based Position = {Position}.");
        }

        private async ValueTask SkipAlseOfFalseWithoutValidationAsync(CancellationToken token)
        {
            //JsonSerializer must handle validation!
            //we skip 4 bytes
            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
            {
                //this one to move the pointer forward, we don't care
                //about EoF, that's handled by next read!
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                return;
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing 'false' literal. " +
                                                    $"0-Based Position = {Position}.");
        }

        private async ValueTask SkipUllOfNullWithoutValidationAsync(CancellationToken token)
        {
            //JsonSerializer must handle validation!
            //we skip 3 bytes
            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
            {
                //this one to move the pointer forward, we don't care
                //about EoF, that's handled by next read!
                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                return;
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing 'null' literal. " +
                                                    $"0-Based Position = {Position}.");
        }

        private async ValueTask NextExpectedOrThrowAsync(byte expected, CancellationToken token, string partOf)
        {
            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) && _buffer[_current] == expected) return;
            if (InRange)
            {
                throw new JsonArrayPartParsingException($"Invalid byte value while parsing '{partOf}'. " +
                                               $"Expected = {expected}, " +
                                               $"Found = {_buffer[_current]}, " +
                                               $"0-Based Position = {Position}.");
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing '{partOf}'. " +
                                           $"Expected = {expected}, " +
                                           $"0-Based Position = {Position}.");
        }

        private async ValueTask<bool> ReadIsGivenByteAsync(byte match, CancellationToken token)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            if (!InRange || _buffer[_current] != match) return false;
            await ReDefineBufferAsync(1, token).ConfigureAwait(false);
            return true;
        }

        private async ValueTask SkipWhiteSpaceWithVerifyAsync(string jsonToken, CancellationToken token)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            if (!InRange)
                throw new JsonArrayPartParsingException($"Reached end, expected to find '{jsonToken}'. " +
                                               $"0-Based Position = {Position}.");
        }

        private async ValueTask SkipWhiteSpaceAsync(CancellationToken token)
        {
            while (await EnsureCapacityAsync(token).ConfigureAwait(false))
            {
                switch (_buffer[_current])
                {
                    case JsonConst.SpaceByte:
                    case JsonConst.HorizontalTabByte:
                    case JsonConst.NewLineByte:
                    case JsonConst.CarriageReturnByte:
                        await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                        continue;
                    case JsonConst.ForwardSlashByte:
                        if (!await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
                        {
                            throw new JsonArrayPartParsingException("Reached end. " +
                                                           "Can not find correct comment format " +
                                                           "(neither single line comment token '//' " +
                                                           "nor multi-line comment token '/*').");
                        }
                        await ReadCommentAsync(token).ConfigureAwait(false);
                        continue;
                    default: return;
                }
            }
        }

        private async ValueTask ReadCommentAsync(CancellationToken token)
        {
            switch (_buffer[_current])
            {
                case JsonConst.ForwardSlashByte:
                    while (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
                    {
                        if (_buffer[_current] == JsonConst.CarriageReturnByte || _buffer[_current] == JsonConst.NewLineByte)
                        {
                            await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                            return;
                        }
                    }
                    //we don't throw if we reach EoJ, we consider comment ended there!
                    //so we get out. If any other token was expected, further parsing will throw
                    //proper error.
                    break;
                case JsonConst.AsteriskByte:
                    while (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
                    {
                        if (_buffer[_current] == JsonConst.AsteriskByte)
                        {
                            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                _buffer[_current] == JsonConst.ForwardSlashByte)
                            {
                                await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                                return;
                            }
                            _current--;
                        }
                    }
                    //we need to throw error even if we reached EoJ
                    //coz the comment was not properly terminated!
                    throw new JsonArrayPartParsingException("Reached end. " +
                                                   "Can not find end token of multi line comment(*/).");
                default:
                    throw new JsonArrayPartParsingException("Can not find correct comment format. " +
                        "Found single forward-slash '/' when expected " +
                        "either single line comment token '//' or multi-line comment token '/*'. " +
                        $"0-Based Position = {Position}.");
            }
        }

        private async ValueTask<bool> NextWithEnsureCapacityAsync(CancellationToken token)
        {
            _current++;
            return await EnsureCapacityAsync(token).ConfigureAwait(false);
        }

        private async ValueTask<bool> EnsureCapacityAsync(CancellationToken token)
        {
            return _current != _end || await TryIncreasingBufferAsync(token).ConfigureAwait(false);
        }

        private async ValueTask ReDefineBufferAsync(int offsetIncrement, CancellationToken token)
        {
            IncreaseConsumption(offsetIncrement);
            if (_stream == null) return;
            if (_current >= (_buffer.Length + 1) / 2)
            {
                _end -= _current;
                if (_end > 0) _buffer.LiftNCopyUnSafe(_current, _end, 0);
                _current = _begin = 0;
            }
            if (_end < _buffer.Length) await FillBufferAsync(token).ConfigureAwait(false);
        }

        private async ValueTask<bool> TryIncreasingBufferAsync(CancellationToken token)
        {
            if (_stream == null) return false;
            if (_end == _buffer.Length) _buffer = _buffer.DoubleByteCapacity();
            return await FillBufferAsync(token).ConfigureAwait(false);
        }

        private async ValueTask<bool> FillBufferAsync(CancellationToken token)
        {
            var end = await _stream!.ReadAsync(_buffer.AsMemory(_end, _buffer.Length - _end), token).ConfigureAwait(false);
            if (end == 0)
            {
                await DisposeStreamAsync().ConfigureAwait(false);
                return false;
            }

            _end += end;
            return true;
        }

        private void IncreaseConsumption(int offsetIncrement)
        {
            _current += offsetIncrement;
            _bytesConsumed += (_current - _begin);
            _begin = _current;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async ValueTask DisposeAsync()
        {
            await DisposeStreamAsync().ConfigureAwait(false);
        }

        private async ValueTask DisposeStreamAsync()
        {
            if (_stream != null && _disposeStream) await _stream.DisposeAsync().ConfigureAwait(false);
            _stream = null;
        }
    }
}