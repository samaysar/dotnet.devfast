namespace Dot.Net.Text.Json
{
    /// <summary>
    /// Interface to dictate how to read a single raw item from a stream of JSON Array.
    /// <para>
    /// These readers MUST NOT be used to read any arbitrary JSON but a single JSON Array only.
    /// </para>
    /// </summary>
    public interface IJsonPartReader
    {
        /// <summary>
        /// Check if JSON stream do start with opening Array symbol, if not, throws
        /// an exception.
        /// <para>
        /// NOTE: This should be the first call (and MUST be the ONLY call) before calling any other method.
        /// </para>
        /// </summary>
        /// <param name="token">Token to observer for cancellation.</param>
        Task ThrowIfTokenNotStartArrayAsync(CancellationToken token);

        /// <summary>
        /// Simply checks if we have reached the end of array or not yet.
        /// </summary>
        bool NotAnEndArray { get; }

        /// <summary>
        /// Returns the next item in the JSON Array stream as byte sequence, asynchronously.
        /// </summary>
        /// <param name="token">Token to observer for cancellation.</param>
        Task<byte[]> GetNextPartAsync(CancellationToken token);
    }
}
