﻿using DevFast.Net.Extensions.SystemTypes;
using System.Text;
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
        private long Distance => _bytesConsumed + (_current - _begin);
        private bool InRange => _current < _end;

        public async ValueTask<bool> ReadIsBeginArrayAsync(CancellationToken token)
        {
            await SkipWhiteSpaceAsync(token).ConfigureAwait(false);
            if (!InRange || _buffer[_current] != JsonConst.ArrayBeginByte) return false;
            IncreaseConsumption(1);
            await ReDefineBufferAsync(token).ConfigureAwait(false);
            return true;
        }

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
                        _current = _current + 1;
                        continue;
                    case JsonConst.CommentSlashByte:
                        _current = _current + 1;
                        if (!await EnsureCapacityAsync(token).ConfigureAwait(false))
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
                {
                    _current = _current + 1;
                    while (await EnsureCapacityAsync(token).ConfigureAwait(false))
                    {
                        if (_buffer[_current] == JsonConst.CarriageReturnByte || _buffer[_current] == JsonConst.NewLineByte)
                        {
                            _current = _current + 1;
                            return;
                        }
                        _current = _current + 1;
                    }

                    throw new JsonParsingException("Reached end of JSON. " +
                                                   "Can not find end token of single line comment(\r or \n).");
                }
                case JsonConst.CommentAsteriskByte:
                {
                    _current = _current + 1;
                    while (await EnsureCapacityAsync(token).ConfigureAwait(false))
                    {
                        if (_buffer[_current] == JsonConst.CommentAsteriskByte)
                        {
                            _current = _current + 1;
                            if (await EnsureCapacityAsync(token).ConfigureAwait(false) &&
                                _buffer[_current] == JsonConst.CommentSlashByte)
                            {
                                _current = _current + 1;
                                return;
                            }
                            continue;
                        }
                        _current = _current + 1;
                    }
                    throw new JsonParsingException("Reached end of JSON. " +
                                                   "Can not find end token of multi line comment(*/).");
                }
                default:
                    throw new JsonParsingException("Can not find correct comment format " +
                                                   "(neither single line comment token '//' nor multi-line comment token '/*'). " +
                                                   $"0-Based Position = {Distance}.");
            }
        }

        private async ValueTask<bool> EnsureCapacityAsync(CancellationToken token)
        {
            return _current != _end || await TryIncreasingBufferAsync(token).ConfigureAwait(false);
        }

        private async ValueTask ReDefineBufferAsync(CancellationToken token)
        {
            if (_stream == null) return;
            if (_current >= (_buffer.Length + 1) / 2)
            {
                Interlocked.Add(ref _end, -_current);
                _buffer.LiftNCopyUnSafe(_current, _end, 0);
                _current = _begin = 0;
            }
            if (_end < _buffer.Length)
            {
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
        }

        private async ValueTask<bool> TryIncreasingBufferAsync(CancellationToken token)
        {
            if(_stream == null) return false;
            if (_end == _buffer.Length)
            {
                Interlocked.Exchange(ref _buffer, _buffer.DoubleByteCapacity());
            }
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
            _current = _current + offsetIncrement;
            Interlocked.Add(ref _bytesConsumed, _current - _begin);
            _begin = _current;
        }
    }
}