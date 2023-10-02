using System.IO;
using System;
using System.Security.Cryptography;
using System.Text;
using Utf8Json;

namespace Dot.Net.Text.Json.Utf8
{
    /// <summary>
    /// Class responsible to read bytes from a <see cref="Stream"/>, assuming UTF-8 encoded JSON Array,
    /// and produce a JSON item at a time as raw bytes.
    /// </summary>
    public sealed class RawUtf8JsonPartReader : IJsonPartReader
    {
        const byte ArrayOpen = 91;//[
        const byte ArrayClose = 93;//]
        const byte ObjectOpen = 123;//{
        const byte ObjectClose = 125;//}

        Stream? _stream;
        byte[] _buffer;
        int _begin, _end;
        long _bytesConsumed;
        bool _disposeInner;

        /// <summary>
        /// Creates a newly initialized instance of <see cref="RawUtf8JsonPartReader"/>.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <param name="size">Initial buffer size. Auto Min. bound = <see cref="TextConst.RawJsonReaderMinBuffer"/></param>
        /// <param name="disposeInner"><see langword="true"/> to dispose <paramref name="stream"/> else <see langword="false"/>.</param>
        public static async Task<IJsonPartReader> CreateAsync(Stream stream,
            CancellationToken token,
            int size = 8 * 1024,
            bool disposeInner = false)
        {
            var buffer = new byte[Math.Max(TextConst.RawJsonReaderMinBuffer, size)];
            var end = await stream.ReadAsync(buffer, 0, buffer.Length, token).ConfigureAwait(false);
            int begin = 0;
            var bom = Encoding.UTF8.GetPreamble();
            if (end >= bom.Length &&
                bom[0] == buffer[0] &&
                bom[1] == buffer[1] &&
                bom[2] == buffer[2])
            {
                begin = 3;
            }
            return new RawUtf8JsonPartReader(stream, buffer, begin, end, disposeInner);
        }

        private RawUtf8JsonPartReader(Stream stream, byte[] buffer, int begin, int end, bool disposeInner)
        {
            _stream = stream;
            _buffer = buffer;
            _begin = begin;
            _bytesConsumed = 0;
            _end = end;
            _disposeInner = disposeInner;
        }

        /// <inheritdoc />
        public bool NotAnEndArray => CurrentByte != ArrayClose;

        private byte CurrentByte => _buffer[_begin];

        private long PositionSinceBeginning => _bytesConsumed + _begin;

        /// <inheritdoc />
        public Task<byte[]> GetNextPartAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task ThrowIfTokenNotStartArrayAsync(CancellationToken token)
        {
            await SkipNonDataAsync(token).ConfigureAwait(false);
            var currentByte = CurrentByte;
            if (currentByte != '[')
            {
                throw new JsonParsingException("Invalid JSON Array. " +
                    $"Expected Byte = {ArrayOpen} (character '['), " +
                    $"Found Byte = {currentByte}, " +
                    $"Byte Position = {PositionSinceBeginning}.");
            }
        }

        private Task SkipNonDataAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        private async Task EnsureData(int offset, CancellationToken token)
        {
            if (_stream == null || ((_begin + offset) < (_end - 1))) return;
            if (_begin >= (_buffer.Length + 1) / 2)
            {
                unsafe
                {
                    fixed (byte* pSrc = &_buffer[_begin])
                    fixed (byte* pDst = &_buffer[0])
                    {
                        Buffer.MemoryCopy(pSrc, pDst, _buffer.Length, _end - _begin);
                    }
                }
                _end = _end - _begin;
                _bytesConsumed = _begin;
                _begin = 0;
            }
            else
            {

            }
            var read = await _stream.ReadAsync(_buffer, _end, _buffer.Length - _end, token).ConfigureAwait(false);
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