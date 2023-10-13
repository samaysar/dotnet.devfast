## Dot.Net.Extensions Namespace
- **[Arrays](Dot.Net.Extensions.Arrays.md 'Dot.Net.Extensions.Arrays')**
  Extension methods on Arrays
  - **[CopyToSafe(this byte[], byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.CopyToSafe(thisbyte[],byte[],int,int,int) 'Dot.Net.Extensions.Arrays.CopyToSafe(this byte[], byte[], int, int, int)')**
    Copies total bytes of source array starting from 
    sourcePosition (included) to target array's
    targetPosition (included) and onwards.
    
    This method is SAFE version of [CopyToUnSafe(this byte[], byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.CopyToUnSafe(thisbyte[],byte[],int,int,int) 'Dot.Net.Extensions.Arrays.CopyToUnSafe(this byte[], byte[], int, int, int)') 
    as constraint are checked.
  - **[CopyToUnSafe(this byte[], byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.CopyToUnSafe(thisbyte[],byte[],int,int,int) 'Dot.Net.Extensions.Arrays.CopyToUnSafe(this byte[], byte[], int, int, int)')**
    Copies total bytes of source array starting from 
    sourcePosition (included) to target array's
    targetPosition (included) and onwards.
    
    !!!- CALL IT AT YOUR OWN RISK -!!!
    
    This method is UNSAFE version of [CopyToSafe(this byte[], byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.CopyToSafe(thisbyte[],byte[],int,int,int) 'Dot.Net.Extensions.Arrays.CopyToSafe(this byte[], byte[], int, int, int)') 
    as no constraint will be check. Caller MUST make sure all required constraints are checked beforehand.
  - **[DoubleByteCapacity(this byte[])](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.DoubleByteCapacity(thisbyte[]) 'Dot.Net.Extensions.Arrays.DoubleByteCapacity(this byte[])')**
    Creates a new array with double the size. Copies the content of source to the newly created array.
  - **[EnsureByteCapacity(byte[], int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.EnsureByteCapacity(byte[],int) 'Dot.Net.Extensions.Arrays.EnsureByteCapacity(byte[], int)')**
    Checks if array needs to be resized. When resize takes place, the content of source
    are copied to the newly created array.
  - **[EnsureByteCapacity(this byte[], int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.EnsureByteCapacity(thisbyte[],int) 'Dot.Net.Extensions.Arrays.EnsureByteCapacity(this byte[], int)')**
    Checks if array needs to be up-sized. When resize takes place, the content of source
    are copied to the newly created array.
  - **[LiftNCopySafe(this byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.LiftNCopySafe(thisbyte[],int,int,int) 'Dot.Net.Extensions.Arrays.LiftNCopySafe(this byte[], int, int, int)')**
    Copies total bytes starting from sourcePosition (included) 
    to targetPosition (Included) and onwards.
    
    NOTE: This method is SAFE version of [LiftNCopyUnSafe(this byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.LiftNCopyUnSafe(thisbyte[],int,int,int) 'Dot.Net.Extensions.Arrays.LiftNCopyUnSafe(this byte[], int, int, int)') as
    constraint are checked.
  - **[LiftNCopyUnSafe(this byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.LiftNCopyUnSafe(thisbyte[],int,int,int) 'Dot.Net.Extensions.Arrays.LiftNCopyUnSafe(this byte[], int, int, int)')**
    Copies total bytes starting from sourcePosition (included) 
    to targetPosition (Included) and onwards.
    
    !!!- CALL IT AT YOUR OWN RISK -!!!
    
    This method is UNSAFE version of [LiftNCopySafe(this byte[], int, int, int)](Dot.Net.Extensions.Arrays.md#Dot.Net.Extensions.Arrays.LiftNCopySafe(thisbyte[],int,int,int) 'Dot.Net.Extensions.Arrays.LiftNCopySafe(this byte[], int, int, int)') 
    as no constraint will be check. Caller MUST make sure all required constraints are checked beforehand.
- **[Enumerables](Dot.Net.Extensions.Enumerables.md 'Dot.Net.Extensions.Enumerables')**
  Extension methods on Enumerables
  - **[ForEach&lt;T&gt;(this IEnumerable&lt;T&gt;, Action&lt;T,CancellationToken&gt;, CancellationToken)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken) 'Dot.Net.Extensions.Enumerables.ForEach<T>(this System.Collections.Generic.IEnumerable<T>, System.Action<T,System.Threading.CancellationToken>, System.Threading.CancellationToken)')**
    Calls lambda for every item in collection with given token.
  - **[ForEachAsync&lt;T&gt;(this IEnumerable&lt;T&gt;, Func&lt;T,CancellationToken,Task&gt;, CancellationToken, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool) 'Dot.Net.Extensions.Enumerables.ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task>, System.Threading.CancellationToken, bool)')**
    Calls lambda for every item in collection with given token, asynchronously.
  - **[SelectAsync&lt;TIn,TOut&gt;(this IAsyncEnumerable&lt;TIn&gt;, Func&lt;TIn,CancellationToken,Task&lt;TOut&gt;&gt;, CancellationToken, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool) 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool)')**
    Calls lambda for every item in asyncCollection with given token, asynchronously.
    Returns outputs as a newly created asynchronous enumerable.
  - **[SelectAsync&lt;TIn,TOut&gt;(this IEnumerable&lt;TIn&gt;, Func&lt;TIn,CancellationToken,Task&lt;TOut&gt;&gt;, CancellationToken, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool) 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool)')**
    Calls lambda for every item in collection with given token, asynchronously, and returns the
    outputs as a newly created asynchronous enumerable.
  - **[ToChunksAsync&lt;T&gt;(this IAsyncEnumerable&lt;T&gt;, int, CancellationToken, bool, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool) 'Dot.Net.Extensions.Enumerables.ToChunksAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, int, System.Threading.CancellationToken, bool, bool)')**
    Collects maximum possible (controlled by maxChunkSize) items in the provided asyncCollection, puts it
    in a list and returns such lists as a part of newly created asynchronous enumerable.
    
    USE-CASE: When the cost of calling [ToListAsync&lt;T&gt;(this IAsyncEnumerable&lt;T&gt;, CancellationToken, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool) 'Dot.Net.Extensions.Enumerables.ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Threading.CancellationToken, bool)') is too huge (requires too much memory or items
    are too many to fit in a single [System.Collections.Generic.List&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')); and working on a small set of such items (instead of consuming single item at a time)
    is advantageous (for e.g. database batch inserts using medium sized collection, instead of inserting item at a time).
  - **[ToListAsync&lt;T&gt;(this IAsyncEnumerable&lt;T&gt;, CancellationToken, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool) 'Dot.Net.Extensions.Enumerables.ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Threading.CancellationToken, bool)')**
    Returns a new [System.Collections.Generic.List&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') containing all the items of provided asyncCollection asynchronously.
  - **[WhereAsync&lt;T&gt;(this IAsyncEnumerable&lt;T&gt;, Func&lt;T,CancellationToken,Task&lt;bool&gt;&gt;, CancellationToken, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool) 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool)')**
    Calls predicate for every item in asyncCollection with given token, asynchronously. Returns the
    filtered items as a newly created asynchronous enumerable.