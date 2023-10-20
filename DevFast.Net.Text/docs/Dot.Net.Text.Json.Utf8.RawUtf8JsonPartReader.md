#### [Dot.Net.Text](index.md 'index')
### [Dot.Net.Text.Json.Utf8](Dot.Net.Text.Json.Utf8.md 'Dot.Net.Text.Json.Utf8')

## RawUtf8JsonPartReader Class

Class responsible to read bytes from a [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'), assuming UTF-8 encoded JSON Array,
and produce a JSON item at a time as raw bytes.

```csharp
public sealed class RawUtf8JsonPartReader :
Dot.Net.Text.Json.IJsonPartReader
```
- *Properties*
  - **[NotAnEndArray](Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.md#Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.NotAnEndArray 'Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.NotAnEndArray')**
- *Methods*
  - **[CreateAsync(Stream, CancellationToken, int, bool)](Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.md#Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool) 'Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream, System.Threading.CancellationToken, int, bool)')**
  - **[GetNextPartAsync(CancellationToken)](Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.md#Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.GetNextPartAsync(System.Threading.CancellationToken) 'Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.GetNextPartAsync(System.Threading.CancellationToken)')**
  - **[ThrowIfTokenNotStartArrayAsync(CancellationToken)](Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.md#Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken) 'Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken)')**

## RawUtf8JsonPartReader Class

Class responsible to read bytes from a [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream'), assuming UTF-8 encoded JSON Array,
and produce a JSON item at a time as raw bytes.

```csharp
public sealed class RawUtf8JsonPartReader :
Dot.Net.Text.Json.IJsonPartReader
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; RawUtf8JsonPartReader

Implements [IJsonPartReader](Dot.Net.Text.Json.IJsonPartReader.md 'Dot.Net.Text.Json.IJsonPartReader')
### Properties

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.NotAnEndArray'></a>

## RawUtf8JsonPartReader.NotAnEndArray Property

Simply checks if we have reached the end of array or not yet.

```csharp
public bool NotAnEndArray { get; }
```

Implements [NotAnEndArray](Dot.Net.Text.Json.IJsonPartReader.md#Dot.Net.Text.Json.IJsonPartReader.NotAnEndArray 'Dot.Net.Text.Json.IJsonPartReader.NotAnEndArray')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool)'></a>

## RawUtf8JsonPartReader.CreateAsync(Stream, CancellationToken, int, bool) Method

Creates a newly initialized instance of [RawUtf8JsonPartReader](Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.md 'Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader').

```csharp
public static System.Threading.Tasks.Task<Dot.Net.Text.Json.IJsonPartReader> CreateAsync(System.IO.Stream stream, System.Threading.CancellationToken token, int size=8192, bool disposeInner=false);
```
#### Parameters

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

Stream to read from.

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe.

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).size'></a>

`size` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

Initial buffer size. Auto Min. bound = [RawUtf8JsonPartReaderMinBuffer](Dot.Net.Text.TextConst.md#Dot.Net.Text.TextConst.RawUtf8JsonPartReaderMinBuffer 'Dot.Net.Text.TextConst.RawUtf8JsonPartReaderMinBuffer')

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).disposeInner'></a>

`disposeInner` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to dispose [stream](Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.md#Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).stream 'Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.CreateAsync(System.IO.Stream, System.Threading.CancellationToken, int, bool).stream') else [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[IJsonPartReader](Dot.Net.Text.Json.IJsonPartReader.md 'Dot.Net.Text.Json.IJsonPartReader')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.GetNextPartAsync(System.Threading.CancellationToken)'></a>

## RawUtf8JsonPartReader.GetNextPartAsync(CancellationToken) Method

Returns the next item in the JSON Array stream as byte sequence, asynchronously.

```csharp
public System.Threading.Tasks.Task<byte[]> GetNextPartAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.GetNextPartAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Token to observer for cancellation.

Implements [GetNextPartAsync(CancellationToken)](Dot.Net.Text.Json.IJsonPartReader.md#Dot.Net.Text.Json.IJsonPartReader.GetNextPartAsync(System.Threading.CancellationToken) 'Dot.Net.Text.Json.IJsonPartReader.GetNextPartAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.Task&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task-1 'System.Threading.Tasks.Task`1')

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken)'></a>

## RawUtf8JsonPartReader.ThrowIfTokenNotStartArrayAsync(CancellationToken) Method

Check if JSON stream do start with opening Array symbol, if not, throws
an exception.

NOTE: This should be the first call (and MUST be the ONLY call) before calling any other method.

```csharp
public System.Threading.Tasks.Task ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='Dot.Net.Text.Json.Utf8.RawUtf8JsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Token to observer for cancellation.

Implements [ThrowIfTokenNotStartArrayAsync(CancellationToken)](Dot.Net.Text.Json.IJsonPartReader.md#Dot.Net.Text.Json.IJsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken) 'Dot.Net.Text.Json.IJsonPartReader.ThrowIfTokenNotStartArrayAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.Task](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.Task 'System.Threading.Tasks.Task')