namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Interface dictating implementation to asynchronously parse individual items of a JSON Array 
    /// in raw form (i.e. <see cref="byte"/>[]).
    /// <para>
    /// Implementation MUST ONLY deal with JSON array and MUST produce a <see cref="byte"/>[]
    /// representing entire value-form (including structural characters, string quotes etc.), of single
    /// element at a time, of a known <see cref="JsonType"/>.
    /// To handle any other arbitrary form of JSON one MUST use other existing JSON libraries.
    /// </para>
    /// <para>
    /// Deserialization from such <see cref="byte"/>[] should NOT be handled by the implementation.
    /// </para>
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
        /// Provides a convenient way to asynchronously enumerate over elements of a JSON array (one at a time).
        /// For every iteration, such mechanism produces <see cref="byte"/>[] representing
        /// entire value-form (including structural characters, string quotes etc.) of such an individual
        /// element. Any standard JSON serializer can be used to deserialize such <see cref="byte"/>[]
        /// to obtain an instance of corresponding .Net type.
        /// </summary>
        /// <param name="ensureEoj"><see langword="false"/> to ignore leftover JSON after <see cref="JsonConst.ArrayEndByte"/>.
        /// <see langword="true"/> to ensure that data is present after <see cref="JsonConst.ArrayEndByte"/> (however, both
        /// single line and multiline comments are allowed).</param>
        /// <param name="token">Cancellation token to observe.</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        IAsyncEnumerable<byte[]> EnumerateRawJsonArrayElementAsync(bool ensureEoj, CancellationToken token);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
        /// <see langword="true"/> if value is <see cref="JsonConst.ArrayBeginByte"/>
        /// (also makes reader advance its current position to next <see cref="byte"/> in the sequence).
        /// Otherwise, it returns <see langword="false"/> when current byte is NOT <see cref="JsonConst.ArrayBeginByte"/> and
        /// reader position is maintained on the current byte.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        ValueTask<bool> ReadIsBeginArrayAsync(CancellationToken token);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it checks
        /// if value is <see cref="JsonConst.ArrayBeginByte"/>. If the value matches, then reader advances 
        /// its current position to next <see cref="byte"/> in the sequence. If the value does NOT match,
        /// reader position is maintained on the current byte and an error 
        /// (of type <see cref="JsonArrayPartParsingException"/>) is thrown.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        /// <exception cref="JsonArrayPartParsingException"></exception>
        ValueTask ReadIsBeginArrayWithVerifyAsync(CancellationToken token);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
        /// <see langword="true"/> if value is <see cref="JsonConst.ArrayEndByte"/>
        /// (also makes reader advance its current position to next <see cref="byte"/> in the sequence or to end of JSON).
        /// Otherwise, it returns <see langword="false"/> when current byte is NOT <see cref="JsonConst.ArrayEndByte"/> and
        /// reader position is maintained on the current byte.
        /// </summary>
        /// <param name="ensureEoj"><see langword="false"/> to ignore any text (JSON or not) after 
        /// observing <see cref="JsonConst.ArrayEndByte"/>.
        /// <see langword="true"/> to ensure that no data (however, single line and multiline comments are allowed) 
        /// is present after <see cref="JsonConst.ArrayEndByte"/>.</param>
        /// <param name="token">Cancellation token to observe</param>
        ValueTask<bool> ReadIsEndArrayAsync(bool ensureEoj, CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        /// <param name="withVerify"></param>
        ValueTask<byte[]> GetCurrentRawAsync(CancellationToken token, bool withVerify = true);
    }
}
