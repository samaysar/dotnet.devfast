using DevFast.Net.Extensions.SystemTypes;
using System.Text;
using Utf8Json;

namespace DevFast.Net.Text.Json.Utf8
{
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

        private long Distance => _bytesConsumed + (_current - _begin);
        private bool InRange => _current < _end;

        private async Task ReDefineBufferAsync(CancellationToken token)
        {
            if (_stream == null) return;
            if (_current >= (_buffer.Length + 1) / 2)
            {
                Interlocked.Add(ref _end, -_current);
                _buffer.LiftNCopyUnSafe(_current, _end, 0);
                Interlocked.Add(ref _bytesConsumed, _current - _begin);
                _current = _begin = 0;
            }
            var end = await _stream.ReadAsync(_buffer.AsMemory(_end, _buffer.Length - _end), token).ConfigureAwait(false);
            if (end == 0)
            {
                Interlocked.Exchange(ref _stream, null);
            }
            else
            {
                Interlocked.Add(ref _end, end);
            }
        }

        public async Task ReadIsBeginArrayWithVerifyAsync(CancellationToken token)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            if (InRange && _buffer[_current] == TextConst.JsonArrayBeginByte)
            {
                Interlocked.Increment(ref _current);
                await ReDefineBufferAsync(token).ConfigureAwait(false);
            }
            else
            {
                if (InRange)
                {
                    throw new JsonParsingException("Invalid byte value for JSON begin-array. " +
                                               $"Expected = {TextConst.JsonArrayBeginByte}, " +
                                               $"Found = {_buffer[_current]}, " +
                                               $"0-Based Position = {Distance}.");
                }

                throw new JsonParsingException("Reached end, unable to find JSON begin-array." +
                                               $"0-Based Position = {Distance}.");
            }
        }

        private async Task SkipWhiteSpaceAsync(CancellationToken token)
        {
            while (_stream != null)
            {
                var localCurrent = _current - 1;
                while (true)
                {
                    localCurrent++;
                    if (localCurrent < _end)
                    {
                        switch (_buffer[localCurrent])
                        {
                            case 0x20: // Space
                            case 0x09: // Horizontal tab
                            case 0x0A: // Line feed or New line
                            case 0x0D: // Carriage return
                                continue;
                            case (byte)'/': // BeginComment
                                localCurrent = await ReadCommentAsync(localCurrent, token).ConfigureAwait(false);
                                continue;                            
                            default:
                                _current = localCurrent;
                                return;
                        }
                    }
                    if (await TryIncreasingBufferAsync(token).ConfigureAwait(false))
                    {
                        localCurrent--;
                    }
                    else return;
                }
            }
        }

        private async Task<bool> TryIncreasingBufferAsync(CancellationToken token)
        {
            if(_stream == null) return false;
            var end = await _stream.ReadAsync(_buffer.AsMemory(_end, _buffer.Length - _end), token).ConfigureAwait(false);
            if (end == 0)
            {
                Interlocked.Exchange(ref _stream, null);
                return false;
            }
            Interlocked.Add(ref _end, end);
            return true;
        }

        private async Task<int> ReadCommentAsync(int current)
        {
            throw new NotImplementedException();
        }

        private async Task EnsureData(int offset, CancellationToken token)
        {
            if (_stream == null || ((_begin + offset) < (_end - 1))) return;
            if (_begin >= (_buffer.Length + 1) / 2)
            {
                //unsafe
                //{
                //    fixed (byte* pSrc = &_buffer[_begin])
                //    fixed (byte* pDst = &_buffer[0])
                //    {
                //        Buffer.MemoryCopy(pSrc, pDst, _buffer.Length, _end - _begin);
                //    }
                //}
                _end = _end - _begin;
                _bytesConsumed = _begin;
                _begin = 0;
            }
            else
            {

            }
            var read = await _stream.ReadAsync(_buffer.AsMemory(_end, _buffer.Length - _end), token).ConfigureAwait(false);
            _end += read;
            if (read == 0)
            {
                if (_disposeInner)
                {
                    await _stream.DisposeAsync().ConfigureAwait(false);
                }
                _stream = null;
            }
        }
    }
}