using System.Text;
using DevFast.Net.Text.Json.Utf8;

namespace DevFast.Net.Text
{
    /// <summary>
    /// Static class holding constant or fixed values for text processing.
    /// </summary>
    public static class TextConst
    {
        /// <summary>
        /// Instance of <see cref="Encoding.UTF8"/> encoding which will not emit BOM.
        /// </summary>
        public static readonly Encoding Utf8NoBom = new UTF8Encoding(false);

        /// <summary>
        /// Minimum buffer size of <see cref="Utf8JsonArrayArrayPartReader"/>.
        /// </summary>
        public const int RawUtf8JsonPartReaderMinBuffer = 1024;

        /// <summary>
        /// Json Begin-Array ('[') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte JsonArrayBeginByte = 91;

        /// <summary>
        /// Json End-Array (']') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte JsonArrayEndByte = 93;
    }
}
