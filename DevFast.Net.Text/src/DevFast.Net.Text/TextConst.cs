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
        /// Minimum buffer size of <see cref="Utf8JsonArrayPartReader"/>.
        /// </summary>
        public const int RawUtf8JsonPartReaderMinBuffer = 2048;
    }
}