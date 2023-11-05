using System;
using DevFast.Net.Extensions.SystemTypes;

namespace DevFast.Net.Text
{
    internal sealed class ReaderBuffer
    {
        private readonly bool _disposeStream;
        private Stream? _stream;
        private DataNode _beginNode, _currentNode;
        private byte[] _data;
        private int _end, _begin, _current;
        private long _currentPosition, _beginPosition;

        public ReaderBuffer(Stream stream, byte[] buffer, int begin, int end, bool disposeStream)
        {
            _stream = stream;
            _current = _begin = begin;
            _end = end;
            _disposeStream = disposeStream;
            _beginPosition = _currentPosition = _begin;
            _currentNode = _beginNode = new DataNode(buffer);
            _data = _beginNode.Data;
        }

        public bool EoF => _stream == null && _current >= _end;

        public byte Current => _data[_current];

        public long Position => _currentPosition;

        public bool InRange => _current < _end;

        public int Capacity()
        {
            var c = 1;
            var n = _beginNode;
            while (!ReferenceEquals(n, _currentNode))
            {
                n = n.Next;
                c++;
            }
            return c * _data.Length;
        }

        public void SkipUntilCurrent()
        {
            _begin = _current;
            _beginNode = _currentNode;
            _beginPosition = _currentPosition;
        }

        public byte[] GetUntilCurrent()
        {
            try
            {
                var currentRaw = new byte[_currentPosition - _beginPosition];
                if (ReferenceEquals(_beginNode, _currentNode))
                {
                    _data.CopyToUnSafe(currentRaw, _begin, currentRaw.Length, 0);
                    return currentRaw;
                }
                var start = 0;
                var data = _beginNode.Data;
                data.CopyToUnSafe(currentRaw, _begin, data.Length - _begin, start);
                start += (data.Length - _begin);
                _beginNode = _beginNode.Next;
                while(!ReferenceEquals(_beginNode, _currentNode))
                {
                    data = _beginNode.Data;
                    data.CopyToUnSafe(currentRaw, 0, data.Length, start);
                    start += data.Length;
                    _beginNode = _beginNode.Next;
                }
                if(_current != 0) _data.CopyToUnSafe(currentRaw, 0, currentRaw.Length - start, start);
                return currentRaw;
            }
            finally
            {
                _beginPosition = _currentPosition;
                _begin = _current;
            }
        }

        public void StepBack()
        {
            _current--;
            _currentPosition--;
        }

        public async ValueTask<bool> MoveNextAsync(CancellationToken token, int steps = 1)
        {
            _current += steps;
            _currentPosition += steps;
            return _current < _end || await TryIncreasingBufferAsync(token).ConfigureAwait(false);
        }

        public async ValueTask DisposeAsync()
        {
            await DisposeStreamAsync().ConfigureAwait(false);
            _beginNode = _currentNode = DataNode.Empty;
            _data = DataNode.Empty.Data;
        }

        private async ValueTask<bool> TryIncreasingBufferAsync(CancellationToken token)
        {
            if (_stream == null) return false;
            return _end == _data.Length ?
                await AddNodeAsync(_stream, token).ConfigureAwait(false) :
                await FillBufferAsync(_stream, token).ConfigureAwait(false);
        }

        private async ValueTask<bool> AddNodeAsync(Stream stream, CancellationToken token)
        {
            var data = new byte[_data.Length];
            var end = await stream.ReadAsync(data, token).ConfigureAwait(false);
            if (end == 0)
            {
                await DisposeStreamAsync().ConfigureAwait(false);
                return false;
            }

            _current -= _end;
            _end = end;
            _data = data;
            _currentNode = _currentNode.SetNext(data);

            return _current < _end;
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
            return _current < _end;
        }

        private async ValueTask DisposeStreamAsync()
        {
            if (_stream != null && _disposeStream) await _stream.DisposeAsync().ConfigureAwait(false);
            _stream = null;
        }

        private sealed class DataNode
        {
            public static readonly DataNode Empty = new(Array.Empty<byte>());

            private readonly byte[] _data;
            private DataNode? _next;

            public DataNode(byte[] data)
            {
                _data = data;
                _next = null;
            }

            public byte[] Data => _data;
            public DataNode Next => _next!;

            public DataNode SetNext(byte[] data)
            {
                _next = new DataNode(data);
                return _next;
            }
        }
    }
}