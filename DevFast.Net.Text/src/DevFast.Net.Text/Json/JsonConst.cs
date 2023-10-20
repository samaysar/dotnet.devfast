namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Static class holding constant or fixed values for JSON text processing.
    /// </summary>
    public static class JsonConst
    {
        /// <summary>
        /// JSON Begin-Array ('[') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte ArrayBeginByte = (byte)'[';

        /// <summary>
        /// JSON End-Array (']') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte ArrayEndByte = (byte)']';

        /// <summary>
        /// JSON single line comment's slash ('/') character value as <see cref="byte"/>.
        /// </summary>
        public const byte CommentSlashByte = (byte)'/';

        /// <summary>
        /// JSON multi-line comment's asterisk ('*') character value as <see cref="byte"/>.
        /// </summary>
        public const byte CommentAsteriskByte = (byte)'*';

        /// <summary>
        /// JSON space (' ') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte SpaceByte = 0x20;

        /// <summary>
        /// JSON horizontal tab ('\t') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte HorizontalTabByte = 0x09;

        /// <summary>
        /// JSON newline ('\n') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte NewLineByte = 0x0A;

        /// <summary>
        /// JSON carriage return ('\r') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte CarriageReturnByte = 0x0D;
    }
}