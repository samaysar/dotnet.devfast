using DevFast.Net.Extensions.SystemTypes;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using Utf8Json;

namespace DevFast.Net.Text.Json.Utf8
{
    // based on the work done on project Utf8Json (https://github.com/neuecc/Utf8Json)
    internal sealed class Utf8JsonArrayArrayPartReader : IJsonArrayPartReader
    {
        volatile Stream? _stream;
        volatile byte[] _buffer;
        volatile int _begin, _end, _current;
        long _bytesConsumed;

        public static async Task<IJsonArrayPartReader> CreateAsync(Stream stream,
            CancellationToken token,
            int size = TextConst.RawUtf8JsonPartReaderMinBuffer)
        {
            var buffer = new byte[Math.Max(TextConst.RawUtf8JsonPartReaderMinBuffer, size)];
            var end = await stream.ReadAsync(buffer, token).ConfigureAwait(false);
            int begin = 0;
            var bom = Encoding.UTF8.GetPreamble();
            if (end >= bom.Length &&
                bom[0] == buffer[0] &&
                bom[1] == buffer[1] &&
                bom[2] == buffer[2])
            {
                begin = 3;
            }
            return new Utf8JsonArrayArrayPartReader(stream, buffer, begin, end);
        }

        private Utf8JsonArrayArrayPartReader(Stream stream, byte[] buffer, int begin, int end)
        {
            _stream = stream;
            _buffer = buffer;
            _current = _begin = begin;
            _bytesConsumed = _begin;
            _end = end;
        }

        public bool EndOfJson => _stream == null && _current == _end;
        public byte Current => _buffer[_end];
        private long Distance => _bytesConsumed + (_current - _begin);
        private bool InRange => _current < _end;

        public async ValueTask ReadIsBeginArrayWithVerifyAsync(CancellationToken token)
        {
            if (!await ReadIsBeginArrayAsync(token).ConfigureAwait(false))
            {
                if (InRange)
                {
                    throw new JsonParsingException("Invalid byte value for JSON begin-array. " +
                                                   $"Expected = {JsonConst.ArrayBeginByte}, " +
                                                   $"Found = {_buffer[_current]}, " +
                                                   $"0-Based Position = {Distance}.");
                }
                throw new JsonParsingException("Reached end, unable to find JSON begin-array." +
                                               $"0-Based Position = {Distance}.");
            }
        }

        public async ValueTask<bool> ReadIsBeginArrayAsync(CancellationToken token)
        {
            return await ReadIsGivenByteAsync(JsonConst.ArrayBeginByte, token).ConfigureAwait(false);
        }

        public async ValueTask<bool> ReadIsEndArrayAsync(CancellationToken token)
        {
            return await ReadIsGivenByteAsync(JsonConst.ArrayEndByte, token).ConfigureAwait(false);
        }

        public async ValueTask<byte[]> GetCurrentRawAsync(CancellationToken token, bool withVerify = true)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            await ReDefineBufferAsync(0, token).ConfigureAwait(false);
            if (!InRange) return Array.Empty<byte>();
            await SkipUntilNextRawAsync(token).ConfigureAwait(false);
            var currentRaw = new byte[_current - _begin];
            _buffer.CopyToUnSafe(currentRaw, _begin, currentRaw.Length, 0);
            //We want to intentionally keep 'withVerify' after ',' check!
            //to either validate everything or nothing
            if (await ReadIsGivenByteAsync(JsonConst.ValueSeparatorByte, token).ConfigureAwait(false) ||
                !withVerify || (InRange && _buffer[_current] == JsonConst.ArrayEndByte)) return currentRaw;
            if (InRange)
            {
                throw new JsonParsingException($"Invalid byte value when parsing JSON element inside a JSON Array. " +
                                               $"Expected = {JsonConst.ValueSeparatorByte} or {JsonConst.ArrayEndByte}, " +
                                               $"Found = {_buffer[_current]}, " +
                                               $"0-Based Position = {Distance}.");
            }
            throw new JsonParsingException("Reached end, unable to find JSON end-array." +
                                           $"0-Based Position = {Distance}.");
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
                    throw new JsonParsingException($"Invalid byte value for start of JSON element. " +
                                                   $"Found = {_buffer[_current]}, " +
                                                   $"0-Based Position = {Distance}.");
            }
        }

        private async ValueTask SkipArrayAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        private async ValueTask SkipObjectAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        private async ValueTask SkipStringAsync(CancellationToken token)
        {
            
        }

        private async ValueTask SkipNumberAsync(CancellationToken token)
        {
            //we just take everything until begin of next token (even if number is not valid!)
            //number parsing rules are too much to write here
            //Serializer will do its job during deserialization
            while (await EnsureCapacityAsync(token).ConfigureAwait(false))
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
                        _current = 1 + _current;
                        continue;
                    default: return;
                }
            }
        }

        private async ValueTask SkipTrueAsync(CancellationToken token)
        {
            await NextExpectedOrThrowAsync((byte)'r', token, "true literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'u', token, "true literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'e', token, "true literal").ConfigureAwait(false);
        }

        private async ValueTask SkipFalseAsync(CancellationToken token)
        {
            await NextExpectedOrThrowAsync((byte)'a', token, "false literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'l', token, "false literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'s', token, "false literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'e', token, "false literal").ConfigureAwait(false);
        }

        private async ValueTask SkipNullAsync(CancellationToken token)
        {
            await NextExpectedOrThrowAsync((byte)'u', token, "null literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'l', token, "null literal").ConfigureAwait(false);
            await NextExpectedOrThrowAsync((byte)'l', token, "null literal").ConfigureAwait(false);
        }

        private async ValueTask NextExpectedOrThrowAsync(byte expected, CancellationToken token, string partOf)
        {
            if (await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false) && _buffer[_current] == expected) return;
            throw new JsonParsingException($"Invalid byte value when parsing '{partOf}' JSON element. " +
                                           $"Expected = {expected}, " +
                                           $"Found = {_buffer[_current]}, " +
                                           $"0-Based Position = {Distance}.");
        }

        private async ValueTask<bool> ReadIsGivenByteAsync(byte match, CancellationToken token)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            if (!InRange || _buffer[_current] != match) return false;
            await ReDefineBufferAsync(1, token).ConfigureAwait(false);
            return true;
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
                        await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false);
                        continue;
                    case JsonConst.CommentSlashByte:
                        if (!await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false))
                        {
                            throw new JsonParsingException("Reached end of JSON. " +
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
                case JsonConst.CommentSlashByte:
                    while (await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false))
                    {
                        if (_buffer[_current] == JsonConst.CarriageReturnByte || _buffer[_current] == JsonConst.NewLineByte)
                        {
                            await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false);
                            return;
                        }
                    }

                    throw new JsonParsingException("Reached end of JSON. " +
                                                   "Can not find end token of single line comment(\r or \n).");
                case JsonConst.CommentAsteriskByte:
                    while (await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false))
                    {
                        if (_buffer[_current] == JsonConst.CommentAsteriskByte)
                        {
                            if (await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false) &&
                                _buffer[_current] == JsonConst.CommentSlashByte)
                            {
                                await SkipOneWithEnsureCapacityAsync(token).ConfigureAwait(false);
                                return;
                            }
                            _current = _current - 1;
                        }
                    }
                    throw new JsonParsingException("Reached end of JSON. " +
                                                   "Can not find end token of multi line comment(*/).");
                default:
                    throw new JsonParsingException("Can not find correct comment format " +
                                                   "(neither single line comment token '//' nor multi-line comment token '/*'). " +
                                                   $"0-Based Position = {Distance}.");
            }
        }

        private async ValueTask<bool> SkipOneWithEnsureCapacityAsync(CancellationToken token)
        {
            _current = 1 + _current;
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
                Interlocked.Add(ref _end, -_current);
                if (_end > 0) _buffer.LiftNCopyUnSafe(_current, _end, 0);
                _current = _begin = 0;
            }
            if (_end < _buffer.Length) await FillBufferAsync(token).ConfigureAwait(false);
        }

        private async ValueTask<bool> TryIncreasingBufferAsync(CancellationToken token)
        {
            if(_stream == null) return false;
            if (_end == _buffer.Length)
            {
                Interlocked.Exchange(ref _buffer, _buffer.DoubleByteCapacity());
            }
            return await FillBufferAsync(token).ConfigureAwait(false);
        }

        private async ValueTask<bool> FillBufferAsync(CancellationToken token)
        {
            Debug.Assert(_stream != null);
            var end = await _stream.ReadAsync(_buffer.AsMemory(_end, _buffer.Length - _end), token).ConfigureAwait(false);
            if (end == 0)
            {
                Interlocked.Exchange(ref _stream, null);
                return false;
            }

            Interlocked.Add(ref _end, end);
            return true;
        }

        private void IncreaseConsumption(int offsetIncrement)
        {
            _current = offsetIncrement + _current;
            Interlocked.Add(ref _bytesConsumed, _current - _begin);
            _begin = _current;
        }

        public void Dispose()
        {
            _stream = null;
        }
    }
}