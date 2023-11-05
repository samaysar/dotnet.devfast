using System;
using System.Text;
using DevFast.Net.Text.Json.Utf8;

namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Static class to create JSON reader instance.
    /// </summary>
    public static class JsonReader
    {
        /// <summary>
        /// Convenient method, to create well initialized instance of type <see cref="IAsyncJsonArrayPartReader"/>.
        /// </summary>
        /// <param name="stream">A readable stream containing JSON array data.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <param name="size">Initial size of underlying byte buffer. Any value less than
        /// <see cref="JsonConst.RawUtf8JsonPartReaderMinBuffer"/> will be ignored.</param>
        /// <param name="disposeStream"><see langword="true"/> to dispose <paramref name="stream"/> when either
        /// current instance of <see cref="IAsyncJsonArrayPartReader"/> itself disposing or
        /// when <paramref name="stream"/> is completely read; <see langword="false"/> otherwise.</param>
        public static async ValueTask<IAsyncJsonArrayPartReader> CreateAsync(Stream stream,
            CancellationToken token = default,
            int size = JsonConst.RawUtf8JsonPartReaderMinBuffer,
            bool disposeStream = false)
        {
            if (!stream.CanRead) throw new ArgumentException($"{nameof(stream)} should support Read operation!");
            var bom = Encoding.UTF8.GetPreamble();
            if (stream is MemoryStream ms)
            {
                if (!ms.TryGetBuffer(out var segment))
                {
                    throw new UnauthorizedAccessException("Stream buffer is not exposed!");
                }
                var newOffSet = 0;
                if (segment.Count >= bom.Length &&
                    bom[0] == segment[segment.Offset] &&
                    bom[1] == segment[segment.Offset + 1] &&
                    bom[2] == segment[segment.Offset + 2])
                {
                    newOffSet = 3;
                }
                return new AsyncUtf8MemJsonArrayPartReader(ms, 
                    new ArraySegment<byte>(segment.Array!, segment.Offset + newOffSet, segment.Count - newOffSet), 
                    disposeStream);
            }
            else
            {
                var buffer = new byte[Math.Max(JsonConst.RawUtf8JsonPartReaderMinBuffer, size)];
                var end = await stream.ReadAsync(buffer, token).ConfigureAwait(false);
                if(end < bom.Length)
                {
                    int newReads;
                    do
                    {
                        newReads = await stream.ReadAsync(buffer.AsMemory(end, buffer.Length - end), token).ConfigureAwait(false);
                        end += newReads;
                    } while (newReads != 0 && end < bom.Length);
                }
                var begin = 0;
                if (end >= bom.Length &&
                    bom[0] == buffer[0] &&
                    bom[1] == buffer[1] &&
                    bom[2] == buffer[2])
                {
                    begin = 3;
                }
                return new AsyncUtf8JsonArrayPartReader(stream, buffer, begin, end, disposeStream);
            }
        }

    }
}