namespace DevFast.Net.Text.Json.Utf8
{
    /// <summary>
    /// Class implementing <see cref="IAsyncJsonArrayPartReader"/> for standard Utf-8 JSON data encoding
    /// based on https://datatracker.ietf.org/doc/html/rfc7159 (grammar shown at https://www.json.org/json-en.html).
    /// <para>
    /// This implementation support both single line comments (starting with '//' and ending in either Carriage return '\r'
    /// or newline '\n') and multiline comments (starting with '/*' and ending with '*/').
    /// </para>
    /// </summary>
    public sealed class AsyncUtf8MemJsonArrayPartReader : IAsyncJsonArrayPartReader
    {
        private readonly bool _disposeStream;
        private MemoryStream? _stream;
        private ArraySegment<byte> _buffer;
        private int _begin, _current;

        private AsyncUtf8MemJsonArrayPartReader(MemoryStream stream, bool disposeStream)
        {
            _stream = stream;
            if(!stream.TryGetBuffer(out _buffer))
            {
                throw new UnauthorizedAccessException("Memory stream buffer is not exposed!");
            }
            _current = _begin = _buffer.Offset;
            _disposeStream = disposeStream;
        }

        /// <summary>
        /// <see langword="true"/> indicating that reader has reached end of JSON input,
        /// otherwise <see langword="false"/>.
        /// </summary>
        public bool EoJ => _stream == null && _current == _buffer.Count;

        /// <summary>
        /// <see cref="byte"/> value of current position of reader. <see langword="null"/> when
        /// reader has reached <see cref="EoJ"/>.
        /// </summary>
        public byte? Current => EoJ ? null : _buffer[_current];

        /// <summary>
        /// Total number of <see cref="byte"/>s observed by the reader since the very beginning (0-based position).
        /// </summary>
        public long Position => _current;
        private bool InRange => _current < _buffer.Count;

        public IAsyncEnumerable<RawJson> EnumerateRawJsonArrayElementAsync(bool ensureEoj, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> ReadIsBeginArrayAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public ValueTask ReadIsBeginArrayWithVerifyAsync(CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public ValueTask<bool> ReadIsEndArrayAsync(bool ensureEoj, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        public ValueTask<RawJson> GetCurrentRawAsync(CancellationToken token, bool withVerify = true)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Asynchronous clean up by releasing resources.
        /// </summary>
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