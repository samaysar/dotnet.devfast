using System.Runtime.CompilerServices;

namespace DevFast.Net.Extensions.SystemTypes
{
    /// <summary>
    /// Extension methods on <see cref="IEnumerable{T}"/> and <see cref="IAsyncEnumerable{T}"/>.
    /// </summary>
    public static class Enumerables
    {
        /// <summary>
        /// Calls <paramref name="lambda"/> for every item in <paramref name="collection"/> with given <paramref name="token"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Enumerable items</param>
        /// <param name="lambda">predicate to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/></param>
        public static void ForEach<T>(this IEnumerable<T> collection, Action<T, CancellationToken> lambda,
            CancellationToken token = default)
        {
            foreach (var item in collection)
            {
                lambda(item, token);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item in <paramref name="collection"/> with given <paramref name="token"/>, asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">Enumerable items</param>
        /// <param name="lambda">Lambda to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async Task ForEachAsync<T>(this IEnumerable<T> collection,
            Func<T, CancellationToken, ValueTask> lambda,
            CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            foreach (var item in collection)
            {
                await lambda(item, token).ConfigureAwait(continueOnCapturedContext);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item in <paramref name="asyncCollection"/> with given <paramref name="token"/>, asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="lambda">Lambda to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/> and enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async Task ForEachAsync<T>(this IAsyncEnumerable<T> asyncCollection,
            Func<T, CancellationToken, ValueTask> lambda,
            CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            await foreach (var item in asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext))
            {
                await lambda(item, token).ConfigureAwait(continueOnCapturedContext);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item in <paramref name="collection"/> with given <paramref name="token"/>, asynchronously, and returns the
        /// outputs as a newly created asynchronous enumerable.
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <param name="collection">Enumerable items</param>
        /// <param name="lambda">Lambda to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IEnumerable<TIn> collection,
            Func<TIn, CancellationToken, ValueTask<TOut>> lambda,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            foreach (var item in collection)
            {
                yield return await lambda(item, token).ConfigureAwait(continueOnCapturedContext);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item in <paramref name="asyncCollection"/> with given <paramref name="token"/>, asynchronously.
        /// Returns outputs as a newly created asynchronous enumerable.
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="lambda">Lambda to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/> and enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IAsyncEnumerable<TIn> asyncCollection,
            Func<TIn, CancellationToken, TOut> lambda,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            await foreach (var item in asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext))
            {
                yield return lambda(item, token);
            }
        }

        /// <summary>
        /// Calls <paramref name="lambda"/> for every item in <paramref name="asyncCollection"/> with given <paramref name="token"/>, asynchronously.
        /// Returns outputs as a newly created asynchronous enumerable.
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <typeparam name="TOut">Output Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="lambda">Lambda to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="lambda"/> and enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<TOut> SelectAsync<TIn, TOut>(this IAsyncEnumerable<TIn> asyncCollection,
            Func<TIn, CancellationToken, ValueTask<TOut>> lambda,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            await foreach (var item in asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext))
            {
                yield return await lambda(item, token).ConfigureAwait(continueOnCapturedContext);
            }
        }

        /// <summary>
        /// While iterating on supplied <paramref name="asyncCollection"/> total of <paramref name="count"/>
        /// elements are bypassed and remaining (if any) items are returned as a part of iteration.
        /// No exception is thrown it <paramref name="asyncCollection"/> contains lesser number of items. 
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="count">Total number of elements to skip</param>
        /// <param name="token">Cancellation token for enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<TIn> SkipAsync<TIn>(this IAsyncEnumerable<TIn> asyncCollection,
            int count,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            var ae = asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext).GetAsyncEnumerator();
            try
            {
                while (count > 0 && await ae.MoveNextAsync()) count--;
                while (await ae.MoveNextAsync()) yield return ae.Current;
            }
            finally
            {
                await ae.DisposeAsync();
            }
        }

        /// <summary>
        /// While iterating on supplied <paramref name="asyncCollection"/> maximum of <paramref name="count"/>
        /// elements are returned as a part of iteration.
        /// If <paramref name="asyncCollection"/> contains lesser number of items, all iterated items
        /// are returned. 
        /// </summary>
        /// <typeparam name="TIn">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="count">Total number of elements to skip</param>
        /// <param name="token">Cancellation token for enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<TIn> TakeAsync<TIn>(this IAsyncEnumerable<TIn> asyncCollection,
            int count,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            var ae = asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext).GetAsyncEnumerator();
            try
            {
                while (count > 0 && await ae.MoveNextAsync())
                {
                    count--;
                    yield return ae.Current;
                }
            }
            finally
            {
                await ae.DisposeAsync();
            }
        }

        /// <summary>
        /// Calls <paramref name="predicate"/> for every item in <paramref name="asyncCollection"/> with given <paramref name="token"/>, asynchronously. Returns the
        /// filtered items as a newly created asynchronous enumerable.
        /// </summary>
        /// <typeparam name="T">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="predicate">Predicate to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="predicate"/> and enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<T> WhereAsync<T>(this IAsyncEnumerable<T> asyncCollection,
            Func<T, CancellationToken, bool> predicate,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            var ae = asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext).GetAsyncEnumerator();
            try
            {
                while (await ae.MoveNextAsync())
                {
                    if (predicate(ae.Current, token)) yield return ae.Current;
                }
            }
            finally
            {
                await ae.DisposeAsync();
            }
        }

        /// <summary>
        /// Calls <paramref name="predicate"/> for every item in <paramref name="asyncCollection"/> with given <paramref name="token"/>, asynchronously. Returns the
        /// filtered items as a newly created asynchronous enumerable.
        /// </summary>
        /// <typeparam name="T">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="predicate">Predicate to apply</param>
        /// <param name="token">Cancellation token to pass on to the supplied <paramref name="predicate"/> and enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<T> WhereAsync<T>(this IAsyncEnumerable<T> asyncCollection,
            Func<T, CancellationToken, ValueTask<bool>> predicate,
            [EnumeratorCancellation] CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            var ae = asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext).GetAsyncEnumerator();
            try
            {
                while (await ae.MoveNextAsync())
                {
                    if (await predicate(ae.Current, token).ConfigureAwait(continueOnCapturedContext)) yield return ae.Current;
                }
            }
            finally
            {
                await ae.DisposeAsync();
            }
        }

        /// <summary>
        /// Counts number of elements in <paramref name="asyncCollection"/>, asynchronously.
        /// </summary>
        /// <typeparam name="T">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="token">Cancellation token to pass to enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async ValueTask<int> CountAsync<T>(this IAsyncEnumerable<T> asyncCollection,
            CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            var ae = asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext).GetAsyncEnumerator();
            try
            {
                var i = 0;
                while (await ae.MoveNextAsync()) i++;
                return i;
            }
            finally
            {
                await ae.DisposeAsync();
            }
        }

        /// <summary>
        /// Counts number of elements in <paramref name="asyncCollection"/>, asynchronously.
        /// </summary>
        /// <typeparam name="T">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="token">Cancellation token to pass to enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async ValueTask<ulong> CountLongAsync<T>(this IAsyncEnumerable<T> asyncCollection,
            CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            var ae = asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext).GetAsyncEnumerator();
            try
            {
                ulong i = 0;
                while (await ae.MoveNextAsync()) i++;
                return i;
            }
            finally
            {
                await ae.DisposeAsync();
            }
        }

        /// <summary>
        /// Returns a new <see cref="List{T}"/> containing all the items of provided <paramref name="asyncCollection"/> asynchronously.
        /// </summary>
        /// <typeparam name="T">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="token">Cancellation token to pass to enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async ValueTask<List<T>> ToListAsync<T>(this IAsyncEnumerable<T> asyncCollection,
            CancellationToken token = default,
            bool continueOnCapturedContext = false)
        {
            var l = new List<T>();
            await foreach (var item in asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext))
            {
                l.Add(item);
            }
            return l;
        }

        /// <summary>
        /// Collects maximum possible (controlled by <paramref name="maxChunkSize"/>) items in the provided <paramref name="asyncCollection"/>, puts it
        /// in a list and returns such lists as a part of newly created asynchronous enumerable.
        /// <para>
        /// USE-CASE: When the cost of calling <see cref="ToListAsync{T}(IAsyncEnumerable{T}, CancellationToken, bool)"/> is too huge (requires too much memory or items
        /// are too many to fit in a single <see cref="List{T}"/>); and working on a small set of such items (instead of consuming single item at a time)
        /// is advantageous (for e.g. database batch inserts using medium sized asyncCollection, instead of inserting item at a time).
        /// </para>
        /// </summary>
        /// <typeparam name="T">Input Type</typeparam>
        /// <param name="asyncCollection">Asynchronously Enumerable items</param>
        /// <param name="maxChunkSize">Maximum size of chunk</param>
        /// <param name="token">Cancellation token to pass to enumerator of <paramref name="asyncCollection"/></param>
        /// <param name="reUseList"><see langword="true"/> to reuse list for next iteration result; otherwise, <see langword="false"/>.
        /// <para>
        /// USE-CASE of <see langword="true"/>: Resultant chunk (<see cref="List{T}"/>) of an iteration is out-of-scope (i.e. candidate for GC) after the iteration.
        /// In other words, it is not shared with some part of the code which may out-live the iteration (e.g. a <see cref="Task"/>) or
        /// the reference of the list itself out-lives the iteration (e.g. setting it to a static field or a reference to another variable that out-lives the iteration).
        /// If such conditions are met, we are better off reusing the list (already allocated space) compared to re-creating a list again.
        /// </para>
        /// <para>
        /// WARNING: Be sure of the use-case when passing <see langword="true"/>, in case of doubt pass <see langword="false"/>.
        /// </para>
        /// </param>
        /// <param name="continueOnCapturedContext"><see langword="true"/> to attempt to marshal the continuation back to the original context captured; otherwise, <see langword="false"/>.</param>
        public static async IAsyncEnumerable<List<T>> ToChunksAsync<T>(this IAsyncEnumerable<T> asyncCollection,
            int maxChunkSize,
            [EnumeratorCancellation] CancellationToken token = default,
            bool reUseList = false,
            bool continueOnCapturedContext = false)
        {
            var l = new List<T>(maxChunkSize);
            await foreach (var item in asyncCollection.WithCancellation(token).ConfigureAwait(continueOnCapturedContext))
            {
                l.Add(item);
                if (l.Count < maxChunkSize) continue;
                yield return l;
                if (reUseList)
                {
                    l.Clear();
                }
                else
                {
                    l = new List<T>(maxChunkSize);
                }
            }

            if (l.Count > 0) yield return l;
        }
    }
}