namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Interface to dictate how to read a single raw item from a stream of JSON Array.
    /// <para>
    /// These readers MUST NOT be used to read any arbitrary JSON but a single JSON Array only.
    /// </para>
    /// </summary>
    public interface IJsonArrayPartReader : IDisposable, IAsyncDisposable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ValueTask<bool> ReadIsBeginArrayAsync(CancellationToken token);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        ValueTask ReadIsBeginArrayWithVerifyAsync(CancellationToken token);
    }
}
