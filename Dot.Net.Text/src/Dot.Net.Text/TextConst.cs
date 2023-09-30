using System.Text;

namespace Dot.Net.Text
{
    /// <summary>
    /// Contains constant or fixed values.
    /// </summary>
    public static class TextConst
    {
        /// <summary>
        /// Instance of <see cref="Encoding.UTF8"/> encoding which will not emit BOM.
        /// </summary>
        public static readonly Encoding Utf8NoBom = new UTF8Encoding(false);

        /// <summary>
        /// Minimum buffer size of <see cref="Json.Utf8.RawUtf8JsonPartReader"/>.
        /// </summary>
        public const int RawJsonReaderMinBuffer = 256;
    }
}
