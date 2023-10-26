namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Represents error that occurred while parsing parts of a JSON array.
    /// </summary>
    public sealed class JsonArrayPartParsingException : Exception
    {
        /// <summary>
        /// Initializes a default new instance of <see cref="JsonArrayPartParsingException"/> class.
        /// </summary>
        public JsonArrayPartParsingException()
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="JsonArrayPartParsingException"/> class
        /// with given <paramref name="message"/>.
        /// </summary>
        /// <param name="message">Specific error message</param>
        public JsonArrayPartParsingException(string message) : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="JsonArrayPartParsingException"/> class
        /// with given <paramref name="message"/> and provided <paramref name="innerException"/>.
        /// </summary>
        /// <param name="message">Specific error message</param>
        /// <param name="innerException">Inner error instance</param>
        public JsonArrayPartParsingException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}