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
        /// JSON Begin-Object ('{') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte ObjectBeginByte = (byte)'{';

        /// <summary>
        /// JSON Begin-Object ('}') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte ObjectEndByte = (byte)'}';

        /// <summary>
        /// JSON String-Quote ('"') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte StringQuoteByte = (byte)'"';

        /// <summary>
        /// JSON value separator (',') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte ValueSeparatorByte = (byte)',';

        /// <summary>
        /// JSON name separator (':') character value as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte NameSeparatorByte = (byte)':';

        /// <summary>
        /// JSON 't' character, of 'true' literal value, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte FirstOfTrueByte = (byte)'t';

        /// <summary>
        /// JSON 'f' character, of 'false' literal value, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte FirstOfFalseByte = (byte)'f';

        /// <summary>
        /// JSON 'n' character, of 'null' literal value, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte FirstOfNullByte = (byte)'n';

        /// <summary>
        /// JSON Minus Sign ('-') character, as in numeric values, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte MinusSignByte = (byte)'-';

        /// <summary>
        /// JSON Plus Sign ('+') character, as in numeric values, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte PlusSignByte = (byte)'+';

        /// <summary>
        /// JSON Upper Case Exponent ('E') character, as in numeric values, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte ExponentUpperByte = (byte)'E';

        /// <summary>
        /// JSON Lower Case Exponent ('e') character, as in numeric values, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte ExponentLowerByte = (byte)'e';

        /// <summary>
        /// JSON Decimal Point ('.') character, as in numeric values, as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte DecimalPointByte = (byte)'.';

        /// <summary>
        /// JSON numeric 1 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number1Byte = (byte)'1';

        /// <summary>
        /// JSON numeric 2 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number2Byte = (byte)'2';

        /// <summary>
        /// JSON numeric 3 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number3Byte = (byte)'3';

        /// <summary>
        /// JSON numeric 4 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number4Byte = (byte)'4';

        /// <summary>
        /// JSON numeric 5 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number5Byte = (byte)'5';

        /// <summary>
        /// JSON numeric 6 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number6Byte = (byte)'6';

        /// <summary>
        /// JSON numeric 7 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number7Byte = (byte)'7';

        /// <summary>
        /// JSON numeric 8 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number8Byte = (byte)'8';

        /// <summary>
        /// JSON numeric 9 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number9Byte = (byte)'9';

        /// <summary>
        /// JSON numeric 0 character as <see cref="byte"/> (based on https://datatracker.ietf.org/doc/html/rfc7159).
        /// </summary>
        public const byte Number0Byte = (byte)'0';

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