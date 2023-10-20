#### [Dot.Net.Text](index.md 'index')
### [Dot.Net.Text.Json](Dot.Net.Text.Json.md 'Dot.Net.Text.Json')

## IJsonPartReader Interface

Interface to dictate how to read a single raw item from a stream of JSON Array.

These readers MUST NOT be used to read any arbitrary JSON but a single JSON Array only.

```csharp
public interface IJsonPartReader
```

Derived  
&#8627; [RawUtf8JsonPartReader](Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.md 'Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader')
### Properties

<a name='Dot.Net.Text.Json.IJsonPartReader.NotAnEndArray'></a>

## IJsonPartReader.NotAnEndArray Property

Simply checks if we have reached the end of array or not yet.

```csharp
bool NotAnEndArray { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='Dot.Net.Text.Json.IJsonPartReader.GetNextPartAsync(System.Threading.CancellationToken)'></a>

## IJsonPartReader.GetNextPartAsync(CancellationToken) Method

Returns the next item in the JSON Array stream as byte sequence, asynchronously.

```csharp
System.Threading.Tasks.Task<byte[]> GetNextPartAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Dot.Net.Text.Json.IJsonPartReader.GetNextPartAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Token to observer for cancellation.

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='Dot.Net.Text.Json.IJsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken)'></a>

## IJsonPartReader.ThrowIfTokenNotStartArrayAsync(CancellationToken) Method

Check if JSON stream do start with opening Array symbol, if not, throws
an exception.

NOTE: This should be the first call (and MUST be the ONLY call) before calling any other method.

```csharp
System.Threading.Tasks.Task ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Dot.Net.Text.Json.IJsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Token to observer for cancellation.

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')