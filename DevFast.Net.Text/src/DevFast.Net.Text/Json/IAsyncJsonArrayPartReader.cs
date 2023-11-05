namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Interface dictating implementation to asynchronously parse individual items of a JSON Array 
    /// or to parse individual elements (as defined in <see cref="JsonType"/>) in a JSON sequence.
    /// Parsing of such elements produces <see cref="RawJson"/> representing entire value-form 
    /// (including structural characters, string quotes etc.) as <see cref="RawJson.Value"/>, of single element at a time, 
    /// of a known <see cref="JsonType"/>.
    /// Implementation should avoid any kind of deserialization and, for that, should use other standard
    /// JSON deserialization libraries.
    /// </summary>
    public interface IAsyncJsonArrayPartReader : IAsyncDisposable
    {
        /// <summary>
        /// <see langword="true"/> indicating that reader has reached end of JSON input,
        /// otherwise <see langword="false"/>.
        /// </summary>
        bool EoJ { get; }

        /// <summary>
        /// <see cref="byte"/> value of current position of reader. <see langword="null"/> when
        /// reader has reached <see cref="EoJ"/>.
        /// </summary>
        byte? Current { get; }

        /// <summary>
        /// Total number of <see cref="byte"/>s observed by the reader since the very beginning (0-based position).
        /// </summary>
        long Position { get; }

        /// <summary>
        /// Current capacity as total number of <see cref="byte"/>s.
        /// </summary>
        int Capacity { get; }

        /// <summary>
        /// Provides a convenient way to asynchronously enumerate over elements of a JSON array (one at a time).
        /// For every iteration, such mechanism produces <see cref="RawJson"/>, where <see cref="RawJson.Value"/> represents
        /// entire value-form (including structural characters, string quotes etc.) of such an individual
        /// element &amp; <see cref="RawJson.Type"/> indicates underlying JSON element type. 
        /// Any standard JSON serializer can be used to deserialize <see cref="RawJson.Value"/>
        /// to obtain an instance of corresponding .Net type.
        /// </summary>
        /// <param name="ensureEoj"><see langword="false"/> to ignore leftover JSON after <see cref="JsonConst.ArrayEndByte"/>.
        /// <see langword="true"/> to ensure that no data is present after <see cref="JsonConst.ArrayEndByte"/>. However, both
        /// single line and multiline comments are allowed after <see cref="JsonConst.ArrayEndByte"/> until <see cref="EoJ"/>.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        IAsyncEnumerable<RawJson> EnumerateRawJsonArrayElementAsync(bool ensureEoj, CancellationToken token = default);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
        /// <see langword="true"/> if value is <see cref="JsonConst.ArrayBeginByte"/>. If the value matches, 
        /// then reader advances its current position to next <see cref="byte"/> in the sequence or to end of JSON.
        /// Otherwise, it returns <see langword="false"/> when current byte is NOT <see cref="JsonConst.ArrayBeginByte"/> and
        /// reader position is maintained on the current byte.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        ValueTask<bool> ReadIsBeginArrayAsync(CancellationToken token = default);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it checks
        /// if value is <see cref="JsonConst.ArrayBeginByte"/>. If the value matches, then reader advances 
        /// its current position to next <see cref="byte"/> in the sequence or to end of JSON. If the value does NOT match,
        /// reader position is maintained on the current byte and an error 
        /// (of type <see cref="JsonArrayPartParsingException"/>) is thrown.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        ValueTask ReadIsBeginArrayWithVerifyAsync(CancellationToken token = default);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
        /// <see langword="true"/> if value is <see cref="JsonConst.ArrayEndByte"/>. If the value matches, 
        /// then reader advances its current position to next <see cref="byte"/> in the sequence or to end of JSON.
        /// Otherwise, it returns <see langword="false"/> when current byte is NOT <see cref="JsonConst.ArrayEndByte"/> and
        /// reader position is maintained on the current byte.
        /// </summary>
        /// <param name="ensureEoj"><see langword="false"/> to ignore any text (JSON or not) after 
        /// observing <see cref="JsonConst.ArrayEndByte"/>.
        /// <see langword="true"/> to ensure that no data is present after <see cref="JsonConst.ArrayEndByte"/>. However, both
        /// single line and multiline comments are allowed before <see cref="EoJ"/>.</param>
        /// <param name="token">Cancellation token to observe</param>
        ValueTask<bool> ReadIsEndArrayAsync(bool ensureEoj, CancellationToken token = default);

        /// <summary>
        /// Reads the current JSON element as <see cref="RawJson"/>. If reaches <see cref="EoJ"/> or
        /// encounters <see cref="JsonConst.ArrayEndByte"/>, returned <see cref="RawJson.Type"/> is
        /// <see cref="JsonType.Nothing"/>.
        /// <para>
        /// One should prefer <see cref="EnumerateRawJsonArrayElementAsync(bool, CancellationToken)"/>
        /// to parse well-structured JSON stream over this method.
        /// This method is to parse non-standard chain of JSON elements separated by ',' (or not).
        /// </para>
        /// </summary>
        /// <param name="withVerify"><see langword="true"/> to verify the presence of ',' or ']' (but not ',]')
        /// after successfully parsing the current JSON element; <see langword="false"/> otherwise.</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        ValueTask<RawJson> GetCurrentRawAsync(bool withVerify = true, CancellationToken token = default);
    }
}
