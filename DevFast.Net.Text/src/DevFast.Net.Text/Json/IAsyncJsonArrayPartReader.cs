namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Interface dictating implementation to asynchronously parse individual items of a JSON Array 
    /// in raw form (i.e. <see cref="byte"/>[]).
    /// <para>
    /// Implementation MUST specifically deal with JSON array only and MUST produce a <see cref="byte"/>[]
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
        bool EndOfJson { get; }

        /// <summary>
        /// <see cref="byte"/> value of current position of reader. <see langword="null"/> when
        /// reader has reached <see cref="EndOfJson"/>.
        /// </summary>
        byte? Current { get; }

        /// <summary>
        /// Total number of <see cref="byte"/>s observed by the reader since the very beginning (0-based position).
        /// </summary>
        long Distance { get; }

        /// <summary>
        /// Provides a convenient way to asynchronously enumerate over elements of a JSON array (one at a time).
        /// For every iteration, such mechanism produces <see cref="byte"/>[] representing
        /// entire value-form (including structural characters, string quotes etc.) of such an individual
        /// element.
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
        /// <param name="token">Cancellation token to observe</param>
        ValueTask<bool> ReadIsEndArrayAsync(CancellationToken token);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
        /// <see langword="true"/> if value is <see cref="JsonConst.ArrayEndByte"/> 
        /// (also makes reader advance its current position to next <see cref="byte"/> in the sequence)
        /// or <see cref="EndOfJson"/> is reached.
        /// Otherwise, it returns <see langword="false"/> when current byte is NEITHER <see cref="JsonConst.ArrayEndByte"/> 
        /// NOR <see cref="EndOfJson"/> and reader position is maintained on the current byte.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        ValueTask<bool> ReadIsEndArrayOrEndOfJsonAsync(CancellationToken token);

        /// <summary>
        /// Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it checks
        /// if value is <see cref="JsonConst.ArrayEndByte"/>. If the value matches, then reader advances 
        /// its current position to next <see cref="byte"/> in the sequence. If the value does NOT match or
        /// <see cref="EndOfJson"/> is detected, reader position is maintained on the current byte and an error 
        /// (of type <see cref="JsonArrayPartParsingException"/>) is thrown.
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        ValueTask ReadIsEndArrayWithEndOfJsonVerifyAsync(CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">Cancellation token to observe</param>
        /// <param name="withVerify"></param>
        ValueTask<byte[]> GetCurrentRawAsync(CancellationToken token, bool withVerify = true);
    }
}
