#### [Dot.Net.Extensions](index.md 'index')
### [Dot.Net.Extensions](Dot.Net.Extensions.md 'Dot.Net.Extensions')

## Enumerables Class

Extension methods on [System.Collections.Generic.IEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1') and [System.Collections.Generic.IAsyncEnumerable&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1').

```csharp
public static class Enumerables
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; Enumerables
### Methods

<a name='Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken)'></a>

## Enumerables.ForEach<T>(this IEnumerable<T>, Action<T,CancellationToken>, CancellationToken) Method

Calls [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).lambda 'Dot.Net.Extensions.Enumerables.ForEach<T>(this System.Collections.Generic.IEnumerable<T>, System.Action<T,System.Threading.CancellationToken>, System.Threading.CancellationToken).lambda') for every item in [collection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).collection 'Dot.Net.Extensions.Enumerables.ForEach<T>(this System.Collections.Generic.IEnumerable<T>, System.Action<T,System.Threading.CancellationToken>, System.Threading.CancellationToken).collection') with given [token](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).token 'Dot.Net.Extensions.Enumerables.ForEach<T>(this System.Collections.Generic.IEnumerable<T>, System.Action<T,System.Threading.CancellationToken>, System.Threading.CancellationToken).token').

```csharp
public static void ForEach<T>(this System.Collections.Generic.IEnumerable<T> collection, System.Action<T,System.Threading.CancellationToken> lambda, System.Threading.CancellationToken token);
```
#### Type parameters

<a name='Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).T'></a>

`T`
#### Parameters

<a name='Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).collection'></a>

`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).T 'Dot.Net.Extensions.Enumerables.ForEach<T>(this System.Collections.Generic.IEnumerable<T>, System.Action<T,System.Threading.CancellationToken>, System.Threading.CancellationToken).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

Enumerable items

<a name='Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).lambda'></a>

`lambda` [System.Action&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).T 'Dot.Net.Extensions.Enumerables.ForEach<T>(this System.Collections.Generic.IEnumerable<T>, System.Action<T,System.Threading.CancellationToken>, System.Threading.CancellationToken).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Action-2 'System.Action`2')

predicate to apply

<a name='Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to pass on to the supplied [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEach_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Action_T,System.Threading.CancellationToken_,System.Threading.CancellationToken).lambda 'Dot.Net.Extensions.Enumerables.ForEach<T>(this System.Collections.Generic.IEnumerable<T>, System.Action<T,System.Threading.CancellationToken>, System.Threading.CancellationToken).lambda')

<a name='Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool)'></a>

## Enumerables.ForEachAsync<T>(this IEnumerable<T>, Func<T,CancellationToken,Task>, CancellationToken, bool) Method

Calls [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).lambda 'Dot.Net.Extensions.Enumerables.ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task>, System.Threading.CancellationToken, bool).lambda') for every item in [collection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).collection 'Dot.Net.Extensions.Enumerables.ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task>, System.Threading.CancellationToken, bool).collection') with given [token](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).token 'Dot.Net.Extensions.Enumerables.ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task>, System.Threading.CancellationToken, bool).token'), asynchronously.

```csharp
public static System.Threading.Tasks.Task ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T> collection, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task> lambda, System.Threading.CancellationToken token, bool continueOnCapturedContext=false);
```
#### Type parameters

<a name='Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).T'></a>

`T`
#### Parameters

<a name='Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).collection'></a>

`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).T 'Dot.Net.Extensions.Enumerables.ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task>, System.Threading.CancellationToken, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

Enumerable items

<a name='Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).lambda'></a>

`lambda` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).T 'Dot.Net.Extensions.Enumerables.ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task>, System.Threading.CancellationToken, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

Action to apply

<a name='Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to pass on to the supplied [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).lambda 'Dot.Net.Extensions.Enumerables.ForEachAsync<T>(this System.Collections.Generic.IEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task>, System.Threading.CancellationToken, bool).lambda')

<a name='Dot.Net.Extensions.Enumerables.ForEachAsync_T_(thisSystem.Collections.Generic.IEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_,System.Threading.CancellationToken,bool).continueOnCapturedContext'></a>

`continueOnCapturedContext` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to attempt to marshal the continuation back to the original context captured; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool)'></a>

## Enumerables.SelectAsync<TIn,TOut>(this IAsyncEnumerable<TIn>, Func<TIn,CancellationToken,Task<TOut>>, CancellationToken, bool) Method

Calls [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).lambda 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).lambda') for every item in [asyncCollection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).asyncCollection 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).asyncCollection') with given [token](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).token 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).token'), asynchronously.
Returns outputs as a newly created asynchronous enumerable.

```csharp
public static System.Collections.Generic.IAsyncEnumerable<TOut> SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn> asyncCollection, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>> lambda, System.Threading.CancellationToken token, bool continueOnCapturedContext=false);
```
#### Type parameters

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TIn'></a>

`TIn`

Input Type

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TOut'></a>

`TOut`

Output Type
#### Parameters

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).asyncCollection'></a>

`asyncCollection` [System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[TIn](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TIn 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TIn')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

Asynchronously Enumerable items

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).lambda'></a>

`lambda` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TIn](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TIn 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TIn')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TOut](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TOut 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

Action to apply

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to pass on to the supplied [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).lambda 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).lambda')

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).continueOnCapturedContext'></a>

`continueOnCapturedContext` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to attempt to marshal the continuation back to the original context captured; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[TOut](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IAsyncEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TOut 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IAsyncEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool)'></a>

## Enumerables.SelectAsync<TIn,TOut>(this IEnumerable<TIn>, Func<TIn,CancellationToken,Task<TOut>>, CancellationToken, bool) Method

Calls [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).lambda 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).lambda') for every item in [collection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).collection 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).collection') with given [token](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).token 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).token'), asynchronously, and returns the
outputs as a newly created asynchronous enumerable.

```csharp
public static System.Collections.Generic.IAsyncEnumerable<TOut> SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn> collection, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>> lambda, System.Threading.CancellationToken token, bool continueOnCapturedContext=false);
```
#### Type parameters

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TIn'></a>

`TIn`

Input Type

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TOut'></a>

`TOut`

Output Type
#### Parameters

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).collection'></a>

`collection` [System.Collections.Generic.IEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')[TIn](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TIn 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TIn')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IEnumerable-1 'System.Collections.Generic.IEnumerable`1')

Enumerable items

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).lambda'></a>

`lambda` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[TIn](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TIn 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TIn')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[TOut](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TOut 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

Action to apply

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to pass on to the supplied [lambda](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).lambda 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).lambda')

<a name='Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).continueOnCapturedContext'></a>

`continueOnCapturedContext` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to attempt to marshal the continuation back to the original context captured; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[TOut](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.SelectAsync_TIn,TOut_(thisSystem.Collections.Generic.IEnumerable_TIn_,System.Func_TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task_TOut__,System.Threading.CancellationToken,bool).TOut 'Dot.Net.Extensions.Enumerables.SelectAsync<TIn,TOut>(this System.Collections.Generic.IEnumerable<TIn>, System.Func<TIn,System.Threading.CancellationToken,System.Threading.Tasks.Task<TOut>>, System.Threading.CancellationToken, bool).TOut')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

<a name='Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool)'></a>

## Enumerables.ToChunksAsync<T>(this IAsyncEnumerable<T>, int, CancellationToken, bool, bool) Method

Collects maximum possible (controlled by [maxChunkSize](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).maxChunkSize 'Dot.Net.Extensions.Enumerables.ToChunksAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, int, System.Threading.CancellationToken, bool, bool).maxChunkSize')) items in the provided [asyncCollection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).asyncCollection 'Dot.Net.Extensions.Enumerables.ToChunksAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, int, System.Threading.CancellationToken, bool, bool).asyncCollection'), puts it
in a list and returns such lists as a part of newly created asynchronous enumerable.

USE-CASE: When the cost of calling [ToListAsync&lt;T&gt;(this IAsyncEnumerable&lt;T&gt;, CancellationToken, bool)](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool) 'Dot.Net.Extensions.Enumerables.ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Threading.CancellationToken, bool)') is too huge (requires too much memory or items
are too many to fit in a single [System.Collections.Generic.List&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')); and working on a small set of such items (instead of consuming single item at a time)
is advantageous (for e.g. database batch inserts using medium sized collection, instead of inserting item at a time).

```csharp
public static System.Collections.Generic.IAsyncEnumerable<System.Collections.Generic.List<T>> ToChunksAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T> asyncCollection, int maxChunkSize, System.Threading.CancellationToken token, bool reUseList=true, bool continueOnCapturedContext=false);
```
#### Type parameters

<a name='Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).T'></a>

`T`

Input Type
#### Parameters

<a name='Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).asyncCollection'></a>

`asyncCollection` [System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).T 'Dot.Net.Extensions.Enumerables.ToChunksAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, int, System.Threading.CancellationToken, bool, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

Asynchronously Enumerable items

<a name='Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).maxChunkSize'></a>

`maxChunkSize` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Maximum size of chunk

<a name='Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe while iterating [asyncCollection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).asyncCollection 'Dot.Net.Extensions.Enumerables.ToChunksAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, int, System.Threading.CancellationToken, bool, bool).asyncCollection')

<a name='Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).reUseList'></a>

`reUseList` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to reuse list for next iteration result; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').
            

USE-CASE of [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool'): Resultant chunk ([System.Collections.Generic.List&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')) of an iteration is out-of-scope (i.e. candidate for GC) after the iteration.
In other words, it is not shared with some part of the code which may out-live the iteration (e.g. a [System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')) or
the reference of the list itself out-lives the iteration (e.g. setting it to a static field or a reference to another variable that out-lives the iteration).
If such conditions are met, we are better off reusing the list (already allocated space) compared to re-creating a list again.

WARNING: Be sure of the use-case when passing [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool'), in case of doubt pass [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

<a name='Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).continueOnCapturedContext'></a>

`continueOnCapturedContext` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to attempt to marshal the continuation back to the original context captured; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToChunksAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,int,System.Threading.CancellationToken,bool,bool).T 'Dot.Net.Extensions.Enumerables.ToChunksAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, int, System.Threading.CancellationToken, bool, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

<a name='Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool)'></a>

## Enumerables.ToListAsync<T>(this IAsyncEnumerable<T>, CancellationToken, bool) Method

Returns a new [System.Collections.Generic.List&lt;&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1') containing all the items of provided [asyncCollection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).asyncCollection 'Dot.Net.Extensions.Enumerables.ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Threading.CancellationToken, bool).asyncCollection') asynchronously.

```csharp
public static System.Threading.Tasks.Task<System.Collections.Generic.List<T>> ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T> asyncCollection, System.Threading.CancellationToken token, bool continueOnCapturedContext=false);
```
#### Type parameters

<a name='Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).T'></a>

`T`

Input Type
#### Parameters

<a name='Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).asyncCollection'></a>

`asyncCollection` [System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).T 'Dot.Net.Extensions.Enumerables.ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Threading.CancellationToken, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

Asynchronously Enumerable items

<a name='Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe while iterating [asyncCollection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).asyncCollection 'Dot.Net.Extensions.Enumerables.ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Threading.CancellationToken, bool).asyncCollection')

<a name='Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).continueOnCapturedContext'></a>

`continueOnCapturedContext` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to attempt to marshal the continuation back to the original context captured; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Collections.Generic.List&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.ToListAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Threading.CancellationToken,bool).T 'Dot.Net.Extensions.Enumerables.ToListAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Threading.CancellationToken, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.List-1 'System.Collections.Generic.List`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool)'></a>

## Enumerables.WhereAsync<T>(this IAsyncEnumerable<T>, Func<T,CancellationToken,Task<bool>>, CancellationToken, bool) Method

Calls [predicate](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).predicate 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool).predicate') for every item in [asyncCollection](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).asyncCollection 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool).asyncCollection') with given [token](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).token 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool).token'), asynchronously. Returns the
filtered items as a newly created asynchronous enumerable.

```csharp
public static System.Collections.Generic.IAsyncEnumerable<T> WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T> asyncCollection, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>> predicate, System.Threading.CancellationToken token, bool continueOnCapturedContext=false);
```
#### Type parameters

<a name='Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).T'></a>

`T`

Input Type
#### Parameters

<a name='Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).asyncCollection'></a>

`asyncCollection` [System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).T 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

Asynchronously Enumerable items

<a name='Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).predicate'></a>

`predicate` [System.Func&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).T 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool).T')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')[,](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Func-3 'System.Func`3')

Predicate to apply

<a name='Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to pass on to the supplied [predicate](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).predicate 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool).predicate')

<a name='Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).continueOnCapturedContext'></a>

`continueOnCapturedContext` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to attempt to marshal the continuation back to the original context captured; otherwise, [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[T](Dot.Net.Extensions.Enumerables.md#Dot.Net.Extensions.Enumerables.WhereAsync_T_(thisSystem.Collections.Generic.IAsyncEnumerable_T_,System.Func_T,System.Threading.CancellationToken,System.Threading.Tasks.Task_bool__,System.Threading.CancellationToken,bool).T 'Dot.Net.Extensions.Enumerables.WhereAsync<T>(this System.Collections.Generic.IAsyncEnumerable<T>, System.Func<T,System.Threading.CancellationToken,System.Threading.Tasks.Task<bool>>, System.Threading.CancellationToken, bool).T')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')