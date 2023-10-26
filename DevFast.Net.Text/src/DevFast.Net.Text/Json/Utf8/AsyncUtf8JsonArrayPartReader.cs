using DevFast.Net.Extensions.SystemTypes;
using System.Diagnostics;
using System.Text;

namespace DevFast.Net.Text.Json.Utf8
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class AsyncUtf8JsonArrayPartReader : IAsyncJsonArrayPartReader
    {
        private readonly bool _disposeStream;
        Stream? _stream;
        byte[] _buffer;
        int _begin, _end, _current;
        long _bytesConsumed;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="token"></param>
        /// <param name="size"></param>
        /// <param name="disposeStream"></param>
        /// <returns></returns>
        public static async ValueTask<IAsyncJsonArrayPartReader> CreateAsync(Stream stream,
            CancellationToken token,
            int size = TextConst.RawUtf8JsonPartReaderMinBuffer,
            bool disposeStream = false)
        {
            var buffer = new byte[Math.Max(TextConst.RawUtf8JsonPartReaderMinBuffer, size)];
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
        /// 
        /// </summary>
        public bool EndOfJson => _stream == null && _current == _end;
        /// <summary>
        /// 
        /// </summary>
        public byte? Current => EndOfJson ? null : _buffer[_current];
        /// <summary>
        /// 
        /// </summary>
        public long Distance => _bytesConsumed + (_current - _begin);
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
                                                   $"0-Based Position = {Distance}.");
                }
                throw new JsonArrayPartParsingException("Reached end, unable to find JSON begin-array." +
                                               $"0-Based Position = {Distance}.");
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
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<bool> ReadIsEndArrayAsync(CancellationToken token)
        {
            return await ReadIsGivenByteAsync(JsonConst.ArrayEndByte, token).ConfigureAwait(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValueTask<bool> ReadIsEndArrayOrEndOfJsonAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ValueTask ReadIsEndArrayWithEndOfJsonVerifyAsync(CancellationToken token)
        {
            throw new NotImplementedException();
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
            await ReDefineBufferAsync(0, token).ConfigureAwait(false);
            if (!InRange || _buffer[_current] == JsonConst.ArrayEndByte) return Array.Empty<byte>();
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
                    await SkipTrueAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.FirstOfFalseByte:
                    await SkipFalseAsync(token).ConfigureAwait(false);
                    break;
                case JsonConst.FirstOfNullByte:
                    await SkipNullAsync(token).ConfigureAwait(false);
                    break;
                default:
                    throw new JsonArrayPartParsingException($"Invalid byte value for start of JSON element. " +
                                                   $"Found = {_buffer[_current]}, " +
                                                   $"0-Based Position = {Distance}.");
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
                                           $"0-Based Position = {Distance}.");
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
                            $"0-Based Position = {Distance}.");
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
                                           $"0-Based Position = {Distance}.");
        }

        private async ValueTask ReadIsValueSeparationOrEndWithVerifyAsync(byte end, string partOf, string expected, CancellationToken token)
        {
            if (await ReadIsValueSeparationOrEndAsync(end, token).ConfigureAwait(false)) return;
            if (InRange)
            {
                throw new JsonArrayPartParsingException($"Invalid byte value for '{partOf}'. " +
                    $"Expected = {expected}, " +
                    $"Found = {_buffer[_current]}, " +
                    $"0-Based Position = {Distance}.");
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find '{end}'. " +
                                           $"0-Based Position = {Distance}.");
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
                                    //We do not care if it is NOT a valid hex code
                                    //Json Serializer will do its work! we just skip 4 bytes!
                                    if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                       await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                       await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                       await NextWithEnsureCapacityAsync(token).ConfigureAwait(false))
                                    {
                                        _current--;
                                        continue;
                                    }
                                    throw new JsonArrayPartParsingException($"Reached end, unable to find valid HEX-DIGITs. " +
                                                                   $"0-Based Position = {Distance}.");
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
                                        $"\\{JsonConst.SecondOfHexDigitInStringByte}XXXX, " +
                                        $"Found = \\{_buffer[_current]}, " +
                                        $"0-Based Position = {Distance}.");
                            }
                        }
                        throw new JsonArrayPartParsingException($"Reached end, unable to find valid escape character. " +
                                                       $"0-Based Position = {Distance}.");
                    case JsonConst.StringQuoteByte:
                        await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
                        return;
                }
            }
            throw new JsonArrayPartParsingException($"Reached end, unable to find end-of-string quote '\"'. " +
                                           $"0-Based Position = {Distance}.");
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

        private async ValueTask SkipTrueAsync(CancellationToken token)
        {
            await NextExpectedOrThrowAsync(JsonConst.LastOfCarriageReturnInStringByte, token, "true literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync(JsonConst.SecondOfHexDigitInStringByte, token, "true literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync(JsonConst.ExponentLowerByte, token, "true literal").ConfigureAwait(false);
            await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
        }

        private async ValueTask SkipFalseAsync(CancellationToken token)
        {
            await NextExpectedOrThrowAsync((byte)'a', token, "false literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'l', token, "false literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'s', token, "false literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync(JsonConst.ExponentLowerByte, token, "false literal").ConfigureAwait(false);
            await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
        }

        private async ValueTask SkipNullAsync(CancellationToken token)
        {
            await NextExpectedOrThrowAsync(JsonConst.SecondOfHexDigitInStringByte, token, "null literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'l', token, "null literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'l', token, "null literal").ConfigureAwait(false);
            await NextWithEnsureCapacityAsync(token).ConfigureAwait(false);
        }

        private async ValueTask NextExpectedOrThrowAsync(byte expected, CancellationToken token, string partOf)
        {
            if (await NextWithEnsureCapacityAsync(token).ConfigureAwait(false) && _buffer[_current] == expected) return;
            if (InRange)
            {
                throw new JsonArrayPartParsingException($"Invalid byte value while parsing '{partOf}'. " +
                                               $"Expected = {expected}, " +
                                               $"Found = {_buffer[_current]}, " +
                                               $"0-Based Position = {Distance}.");
            }
            throw new JsonArrayPartParsingException($"Reached end while parsing '{partOf}'. " +
                                           $"Expected = {expected}, " +
                                           $"0-Based Position = {Distance}.");
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
                                               $"0-Based Position = {Distance}.");
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

                    throw new JsonArrayPartParsingException("Reached end. " +
                                                   "Can not find end token of single line comment(\r or \n).");
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
                    throw new JsonArrayPartParsingException("Reached end. " +
                                                   "Can not find end token of multi line comment(*/).");
                default:
                    throw new JsonArrayPartParsingException("Can not find correct comment format " +
                                                   "(neither single line comment token '//' nor multi-line comment token '/*'). " +
                                                   $"0-Based Position = {Distance}.");
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