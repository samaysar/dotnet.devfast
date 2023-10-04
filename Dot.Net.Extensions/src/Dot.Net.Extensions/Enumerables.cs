using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dot.Net.Extensions
{
    /// <summary>
    /// Extension methods on Enumerables
    /// </summary>
    public static class Enumerables
    {
        /// <summary>
        /// Calls <paramref name="lambda"/> for every item of the given enumerable while observing for cancellation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Items</param>
        /// <param name="lambda">lambda to apply</param>
        /// <param name="token">Cancellation token to observe</param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T> lambda, CancellationToken token)
        {
            foreach (var item in items)
            {
                lambda(item);
                token.ThrowIfCancellationRequested();
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item of the given enumerable.
        /// <para>
        /// NOTE: This method itself does not observes provided <paramref name="token"/> and relies on
        /// the fact that <paramref name="lambda"/> itself will generate cancellation errors as needed.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Items</param>
        /// <param name="lambda">lambda to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/></param>
        public static void ForEach<T>(this IEnumerable<T> items, Action<T, CancellationToken> lambda,
            CancellationToken token)
        {
            foreach (var item in items)
            {
                lambda(item, token);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item of the given enumerable, asynchronously.
        /// <para>
        /// NOTE: This method itself does not observes provided <paramref name="token"/> and relies on
        /// the fact that <paramref name="lambda"/> itself will generate cancellation errors as needed.
        /// </para>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items">Items</param>
        /// <param name="lambda">Action to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async Task ForEachAsync<T>(this IEnumerable<T> items,
            Func<T, CancellationToken, Task> lambda,
            CancellationToken token,
            bool continueOnCapturedContext = false)
        {
            foreach (var item in items)
            {
                await lambda(item, token).ConfigureAwait(continueOnCapturedContext);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item of the given enumerable, asynchronously, and returns the
        /// outputs in linq fashion.
        /// <para>
        /// NOTE: This method itself does not observes provided <paramref name="token"/> and relies on
        /// the fact that <paramref name="lambda"/> itself will generate cancellation errors as needed.
        /// </para>
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <param name="items">Items</param>
        /// <param name="lambda">Action to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IEnumerable<TIn> items,
            Func<TIn, CancellationToken, Task<TOut>> lambda,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            foreach (var item in items)
            {
                yield return await lambda(item, token).ConfigureAwait(continueOnCapturedContext);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item of the given enumerable, asynchronously, and returns the
        /// outputs in linq fashion.
        /// <para>
        /// NOTE: This method itself does not observes provided <paramref name="token"/> and relies on
        /// the fact that <paramref name="lambda"/> itself will generate cancellation errors as needed.
        /// </para>
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <param name="items">Items</param>
        /// <param name="lambda">Action to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/></param>
        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IAsyncEnumerable<TIn> items,
            Func<TIn, CancellationToken, Task<TOut>> lambda,
            [EnumeratorCancellation] CancellationToken token = default)
        {
            await foreach (var item in items)
            {
                yield return await lambda(item, token);
            }
        }
    }
}
