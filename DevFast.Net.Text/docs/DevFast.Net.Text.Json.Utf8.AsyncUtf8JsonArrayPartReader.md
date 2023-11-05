#### [DevFast.Net.Text](index.md 'index')
### [DevFast.Net.Text.Json.Utf8](DevFast.Net.Text.Json.Utf8.md 'DevFast.Net.Text.Json.Utf8')

## AsyncUtf8JsonArrayPartReader Class

Class implementing [IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader') for standard Utf-8 JSON data encoding
based on https://datatracker.ietf.org/doc/html/rfc7159 (grammar shown at https://www.json.org/json-en.html).

This implementation support both single line comments (starting with '//' and ending in either Carriage return '\r'
or newline '\n') and multiline comments (starting with '/*' and ending with '*/').

```csharp
public sealed class AsyncUtf8JsonArrayPartReader :
DevFast.Net.Text.Json.IAsyncJsonArrayPartReader,
System.IAsyncDisposable
```
- *Properties*
  - **[Capacity](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Capacity 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Capacity')**
  - **[Current](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Current 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Current')**
  - **[EoJ](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ')**
  - **[Position](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Position 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Position')**
- *Methods*
  - **[DisposeAsync()](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.DisposeAsync() 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.DisposeAsync()')**
  - **[EnumerateRawJsonArrayElementAsync(bool, CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, System.Threading.CancellationToken)')**
  - **[GetCurrentRawAsync(bool, CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(bool, System.Threading.CancellationToken)')**
  - **[ReadIsBeginArrayAsync(CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)')**
  - **[ReadIsBeginArrayWithVerifyAsync(CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)')**
  - **[ReadIsEndArrayAsync(bool, CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(bool, System.Threading.CancellationToken)')**

## AsyncUtf8JsonArrayPartReader Class

Class implementing [IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader') for standard Utf-8 JSON data encoding
based on https://datatracker.ietf.org/doc/html/rfc7159 (grammar shown at https://www.json.org/json-en.html).

This implementation support both single line comments (starting with '//' and ending in either Carriage return '\r'
or newline '\n') and multiline comments (starting with '/*' and ending with '*/').

```csharp
public sealed class AsyncUtf8JsonArrayPartReader :
DevFast.Net.Text.Json.IAsyncJsonArrayPartReader,
System.IAsyncDisposable
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; AsyncUtf8JsonArrayPartReader

Implements [IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader'), [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Properties

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Capacity'></a>

## AsyncUtf8JsonArrayPartReader.Capacity Property

Current capacity as total number of [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')s.

```csharp
public int Capacity { get; }
```

Implements [Capacity](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Capacity 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Capacity')

#### Property Value
[System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Current'></a>

## AsyncUtf8JsonArrayPartReader.Current Property

[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') value of current position of reader. [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') when
            reader has reached [EoJ](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ').

```csharp
public System.Nullable<byte> Current { get; }
```

Implements [Current](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Current 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Current')

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ'></a>

## AsyncUtf8JsonArrayPartReader.EoJ Property

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') indicating that reader has reached end of JSON input,
            otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

```csharp
public bool EoJ { get; }
```

Implements [EoJ](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ')

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.Position'></a>

## AsyncUtf8JsonArrayPartReader.Position Property

Total number of [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')s observed by the reader since the very beginning (0-based position).

```csharp
public long Position { get; }
```

Implements [Position](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Position 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Position')

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Methods

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.DisposeAsync()'></a>

## AsyncUtf8JsonArrayPartReader.DisposeAsync() Method

Asynchronous clean up by releasing resources.

```csharp
public System.Threading.Tasks.ValueTask DisposeAsync();
```

Implements [DisposeAsync()](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable.DisposeAsync 'System.IAsyncDisposable.DisposeAsync')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, CancellationToken) Method

Provides a convenient way to asynchronously enumerate over elements of a JSON array (one at a time).
For every iteration, such mechanism produces [RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson'), where [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value') represents
entire value-form (including structural characters, string quotes etc.) of such an individual
element & [Type](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Type 'DevFast.Net.Text.Json.RawJson.Type') indicates underlying JSON element type. 
Any standard JSON serializer can be used to deserialize [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value')
to obtain an instance of corresponding .Net type.

```csharp
public System.Collections.Generic.IAsyncEnumerable<DevFast.Net.Text.Json.RawJson> EnumerateRawJsonArrayElementAsync(bool ensureEoj, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).ensureEoj'></a>

`ensureEoj` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ignore leftover JSON after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte').
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ensure that no data is present after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'). However, both
            single line and multiline comments are allowed after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') until [EoJ](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ').

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe.

Implements [EnumerateRawJsonArrayElementAsync(bool, CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, System.Threading.CancellationToken)')

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(bool,System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(bool, CancellationToken) Method

Reads the current JSON element as [RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson'). If reaches [EoJ](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ') or
encounters [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'), returned [Type](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Type 'DevFast.Net.Text.Json.RawJson.Type') is
[Nothing](DevFast.Net.Text.Json.JsonType.md#DevFast.Net.Text.Json.JsonType.Nothing 'DevFast.Net.Text.Json.JsonType.Nothing').

One should prefer [EnumerateRawJsonArrayElementAsync(bool, CancellationToken)](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, System.Threading.CancellationToken)')
to parse well-structured JSON stream over this method.
This method is to parse non-standard chain of JSON elements separated by ',' (or not).

```csharp
public System.Threading.Tasks.ValueTask<DevFast.Net.Text.Json.RawJson> GetCurrentRawAsync(bool withVerify=true, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(bool,System.Threading.CancellationToken).withVerify'></a>

`withVerify` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to verify the presence of ',' or ']' (but not ',]')
            after successfully parsing the current JSON element; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') otherwise.

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.GetCurrentRawAsync(bool,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe.

Implements [GetCurrentRawAsync(bool, CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(bool, System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if value is [ArrayBeginByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayBeginByte 'DevFast.Net.Text.Json.JsonConst.ArrayBeginByte'). If the value matches, 
then reader advances its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence or to end of JSON.
Otherwise, it returns [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when current byte is NOT [ArrayBeginByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayBeginByte 'DevFast.Net.Text.Json.JsonConst.ArrayBeginByte') and
reader position is maintained on the current byte.

```csharp
public System.Threading.Tasks.ValueTask<bool> ReadIsBeginArrayAsync(System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

Implements [ReadIsBeginArrayAsync(CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it checks
if value is [ArrayBeginByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayBeginByte 'DevFast.Net.Text.Json.JsonConst.ArrayBeginByte'). If the value matches, then reader advances 
its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence or to end of JSON. If the value does NOT match,
reader position is maintained on the current byte and an error 
(of type [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')) is thrown.

```csharp
public System.Threading.Tasks.ValueTask ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

Implements [ReadIsBeginArrayWithVerifyAsync(CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken)'></a>

## AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(bool, CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if value is [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'). If the value matches, 
then reader advances its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence or to end of JSON.
Otherwise, it returns [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when current byte is NOT [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') and
reader position is maintained on the current byte.

```csharp
public System.Threading.Tasks.ValueTask<bool> ReadIsEndArrayAsync(bool ensureEoj, System.Threading.CancellationToken token=default(System.Threading.CancellationToken));
```
#### Parameters

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken).ensureEoj'></a>

`ensureEoj` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ignore any text (JSON or not) after 
            observing [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte').
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ensure that no data is present after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'). However, both
            single line and multiline comments are allowed before [EoJ](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md#DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.EoJ').

<a name='DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

Implements [ReadIsEndArrayAsync(bool, CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(bool, System.Threading.CancellationToken)')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')