#### [DevFast.Net.Text](index.md 'index')
### [DevFast.Net.Text.Json.Utf8](DevFast.Net.Text.Json.Utf8.md 'DevFast.Net.Text.Json.Utf8')

## AsyncUtf8JsonArrayPartReader Class

```csharp
public sealed class AsyncUtf8JsonArrayPartReader :
DevFast.Net.Text.Json.IAsyncJsonArrayPartReader,
System.IAsyncDisposable
```
- *Properties*
  - **[Current](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Current 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Current')**
  - **[Distance](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Distance 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Distance')**
  - **[EndOfJson](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EndOfJson 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EndOfJson')**
- *Methods*
  - **[CreateAsync(Stream, CancellationToken, int, bool)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.CreateAsync(System.IO.Stream, System.Threading.CancellationToken, int, bool)')**
  - **[DisposeAsync()](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.DisposeAsync() 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.DisposeAsync()')**
  - **[EnumerateRawJsonArrayElementAsync(bool, CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, System.Threading.CancellationToken)')**
  - **[GetCurrentRawAsync(CancellationToken, bool)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken, bool)')**
  - **[ReadIsBeginArrayAsync(CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)')**
  - **[ReadIsBeginArrayWithVerifyAsync(CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)')**
  - **[ReadIsEndArrayAsync(CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken)')**
  - **[ReadIsEndArrayOrEndOfJsonAsync(CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken)')**
  - **[ReadIsEndArrayWithEndOfJsonVerifyAsync(CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken)')**

## AsyncUtf8JsonArrayPartReader Class

```csharp
public sealed class AsyncUtf8JsonArrayPartReader :
DevFast.Net.Text.Json.IAsyncJsonArrayPartReader,
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AsyncUtf8JsonArrayPartReader

Implements [IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader'), [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Properties

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Current'></a>

## AsyncUtf8JsonArrayPartReader.Current Property

```csharp
public System.Nullable<byte> Current { get; }
```

Implements [Current](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Current 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Current')

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Distance'></a>

## AsyncUtf8JsonArrayPartReader.Distance Property

```csharp
public long Distance { get; }
```

Implements [Distance](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Distance 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Distance')

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EndOfJson'></a>

## AsyncUtf8JsonArrayPartReader.EndOfJson Property

```csharp
public bool EndOfJson { get; }
```

Implements [EndOfJson](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool)'></a>

## AsyncUtf8JsonArrayPartReader.CreateAsync(Stream, CancellationToken, int, bool) Method

```csharp
public static System.Threading.Tasks.ValueTask<DevFast.Net.Text.Json.IAsyncJsonArrayPartReader> CreateAsync(System.IO.Stream stream, System.Threading.CancellationToken token, int size=2048, bool disposeStream=false);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).stream'></a>

`stream` [System.IO.Stream](https://docs.microsoft.com/en-us/dotnet/api/System.IO.Stream 'System.IO.Stream')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).size'></a>

`size` [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.CreateAsync(System.IO.Stream,System.Threading.CancellationToken,int,bool).disposeStream'></a>

`disposeStream` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.DisposeAsync()'></a>

## AsyncUtf8JsonArrayPartReader.DisposeAsync() Method

```csharp
public System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, CancellationToken) Method

```csharp
public System.Collections.Generic.IAsyncEnumerable<byte[]> EnumerateRawJsonArrayElementAsync(bool ensureEoj, System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).ensureEoj'></a>

`ensureEoj` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Implements [EnumerateRawJsonArrayElementAsync(bool, CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, System.Threading.CancellationToken)')

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

#### Exceptions

[System.NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotImplementedException 'System.NotImplementedException')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool)'></a>

## AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(CancellationToken, bool) Method

```csharp
public System.Threading.Tasks.ValueTask<byte[]> GetCurrentRawAsync(System.Threading.CancellationToken token, bool withVerify=true);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).withVerify'></a>

`withVerify` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

Implements [GetCurrentRawAsync(CancellationToken, bool)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken, bool)')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(CancellationToken) Method

```csharp
public System.Threading.Tasks.ValueTask<bool> ReadIsBeginArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Implements [ReadIsBeginArrayAsync(CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(CancellationToken) Method

```csharp
public System.Threading.Tasks.ValueTask ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Implements [ReadIsBeginArrayWithVerifyAsync(CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(CancellationToken) Method

```csharp
public System.Threading.Tasks.ValueTask<bool> ReadIsEndArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Implements [ReadIsEndArrayAsync(CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(CancellationToken) Method

```csharp
public System.Threading.Tasks.ValueTask<bool> ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Implements [ReadIsEndArrayOrEndOfJsonAsync(CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

#### Exceptions

[System.NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotImplementedException 'System.NotImplementedException')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(CancellationToken) Method

```csharp
public System.Threading.Tasks.ValueTask ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Implements [ReadIsEndArrayWithEndOfJsonVerifyAsync(CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

#### Exceptions

[System.NotImplementedException](https://docs.microsoft.com/en-us/dotnet/api/System.NotImplementedException 'System.NotImplementedException')