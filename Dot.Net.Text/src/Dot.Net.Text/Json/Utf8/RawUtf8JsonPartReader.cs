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

        readonly Stream _stream;
        byte[] _buffer;
        int _current, _end;
        long _bytesDiscarded;

        /// <summary>
        /// Creates a newly initialized instance of <see cref="RawUtf8JsonPartReader"/>.
        /// </summary>
        /// <param name="stream">Stream to read from.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <param name="size">Initial buffer size. Auto Min. bound = <see cref="TextConst.RawJsonReaderMinBuffer"/></param>
        public static async Task<IJsonPartReader> CreateAsync(Stream stream,
            CancellationToken token,
            int size = 1024)
        {
            var buffer = new byte[Math.Max(TextConst.RawJsonReaderMinBuffer, size)];
            var end = await stream.ReadAsync(buffer, 0, buffer.Length, token).ConfigureAwait(false);
            int start = 0;
            var bom = Encoding.UTF8.GetPreamble();
            if (end >= bom.Length &&
                bom[0] == buffer[0] &&
                bom[1] == buffer[1] &&
                bom[2] == buffer[2])
            {
                start = 3;
            }
            return new RawUtf8JsonPartReader(stream, buffer, start, end);
        }

        private RawUtf8JsonPartReader(Stream stream, byte[] buffer, int current, int end)
        {
            _stream = stream;
            _buffer = buffer;
            _current = current;
            _bytesDiscarded = 0;
            _end = end;
        }

        /// <inheritdoc />
        public bool NotAnEndArray => Current != ArrayClose;

        private byte Current => _buffer[_current];

        private long PositionSinceBeginning => _bytesDiscarded + _current;

        /// <inheritdoc />
        public Task<byte[]> GetNextPartAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public async Task ThrowIfTokenNotStartArrayAsync(CancellationToken token)
        {
            await SkipNonDataAsync(token).ConfigureAwait(false);
            var currentByte = Current;
            if (currentByte != '[')
            {
                throw new JsonParsingException("Invalid JSON Array. " +
                    $"Expected = '{ArrayOpen}' (character '['), " +
                    $"Found = '{currentByte}', " +
                    $"Byte-wise position '{PositionSinceBeginning}'.");
            }
        }

        private Task SkipNonDataAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}