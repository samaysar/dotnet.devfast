using System;

namespace DevFast.Net.Text
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ReaderBuffer
    {
        private readonly bool _disposeStream;
        private Stream? _stream;
        private DataNode _beginNode, _currentNode;
        private byte[] _data;
        private int _end, _begin, _current;
        private ulong _currentPosition, _beginPosition;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="buffer"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <param name="disposeStream"></param>
        public ReaderBuffer(Stream stream, byte[] buffer, int begin, int end, bool disposeStream)
        {
            _stream = stream;
            _current = _begin = begin;
            _end = end;
            _disposeStream = disposeStream;
            _beginPosition = _currentPosition = (ulong)_begin;
            _currentNode = _beginNode = new DataNode(buffer);
            _data = _beginNode.Data;
        }

        /// <summary>
        /// <see langword="true"/> indicating that buffer has reached end of input,
        /// otherwise <see langword="false"/>.
        /// </summary>
        public bool EoF => _stream == null && _current == _end;

        /// <summary>
        /// <see cref="byte"/> value of current position in buffer. <see langword="null"/> when
        /// buffer has reached <see cref="EoF"/>.
        /// </summary>
        public byte Current => _data[_current];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public async ValueTask<bool> EnsureNextAsync(CancellationToken token)
        {
            _current++;
            _currentPosition++;
            return _current != _end || await TryIncreasingBufferAsync(token).ConfigureAwait(false);
        }

        private async ValueTask<bool> TryIncreasingBufferAsync(CancellationToken token)
        {
            if (_stream == null) return false;
            return _end == _data.Length ?
                await AddNodeAsync(_stream, token).ConfigureAwait(false) :
                await FillBufferAsync(_stream, token).ConfigureAwait(false);
        }

        private async Task<bool> AddNodeAsync(Stream stream, CancellationToken token)
        {
            var data = new byte[_data.Length];
            var end = await stream.ReadAsync(data, token).ConfigureAwait(false);
            if (end == 0)
            {
                await DisposeStreamAsync().ConfigureAwait(false);
                return false;
            }

            _current = 0;
            _end = end;
            _data = data;
            _currentNode = _currentNode.SetNext(data);

            return true;
        }

        private async ValueTask<bool> FillBufferAsync(Stream stream, CancellationToken token)
        {
            var end = await stream.ReadAsync(_data.AsMemory(_end, _data.Length - _end), token).ConfigureAwait(false);
            if (end == 0)
            {
                await DisposeStreamAsync().ConfigureAwait(false);
                return false;
            }

            _end += end;
            return true;
        }

        private async ValueTask DisposeStreamAsync()
        {
            if (_stream != null && _disposeStream) await _stream.DisposeAsync().ConfigureAwait(false);
            _stream = null;
        }

        private sealed class DataNode
        {
            private readonly byte[] _data;
            private DataNode? _next;

            public DataNode(byte[] data)
            {
                _data = data;
                _next = null;
            }

            public byte[] Data => _data;

            public DataNode SetNext(byte[] data)
            {
                _next = new DataNode(data);
                return _next;
            }
        }
    }
}