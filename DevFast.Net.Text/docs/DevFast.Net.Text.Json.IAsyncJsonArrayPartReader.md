#### [DevFast.Net.Text](index.md 'index')
### [DevFast.Net.Text.Json](DevFast.Net.Text.Json.md 'DevFast.Net.Text.Json')

## IAsyncJsonArrayPartReader Interface

Interface dictating implementation to asynchronously parse individual items of a JSON Array 
or to parse individual elements (as defined in [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType')) in a JSON sequence.
Parsing of such elements produces [RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson') representing entire value-form 
(including structural characters, string quotes etc.) as [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value'), of single element at a time, 
of a known [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType').
Implementation should avoid any kind of deserialization and, for that, should use other standard
JSON deserialization libraries.

```csharp
public interface IAsyncJsonArrayPartReader :
System.IAsyncDisposable
```

Derived  
&#8627; [AsyncUtf8JsonArrayPartReader](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader')

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Properties

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Current'></a>

## IAsyncJsonArrayPartReader.Current Property

[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') value of current position of reader. [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null') when
            reader has reached [EoJ](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ').

```csharp
System.Nullable<byte> Current { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ'></a>

## IAsyncJsonArrayPartReader.EoJ Property

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') indicating that reader has reached end of JSON input,
            otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

```csharp
bool EoJ { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Position'></a>

## IAsyncJsonArrayPartReader.Position Property

Total number of [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')s observed by the reader since the very beginning (0-based position).

```csharp
long Position { get; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')
### Methods

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, CancellationToken) Method

Provides a convenient way to asynchronously enumerate over elements of a JSON array (one at a time).
For every iteration, such mechanism produces [RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson'), where [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value') represents
entire value-form (including structural characters, string quotes etc.) of such an individual
element & [Type](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Type 'DevFast.Net.Text.Json.RawJson.Type') indicates underlying JSON element type. 
Any standard JSON serializer can be used to deserialize [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value')
to obtain an instance of corresponding .Net type.

```csharp
System.Collections.Generic.IAsyncEnumerable<DevFast.Net.Text.Json.RawJson> EnumerateRawJsonArrayElementAsync(bool ensureEoj, System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).ensureEoj'></a>

`ensureEoj` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ignore leftover JSON after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte').
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ensure that no data is present after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'). However, both
            single line and multiline comments are allowed after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') until [EoJ](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ').

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe.

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool)'></a>

## IAsyncJsonArrayPartReader.GetCurrentRawAsync(CancellationToken, bool) Method

Reads the current JSON element as [RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson'). If reaches [EoJ](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ') or
encounters [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'), returned [Type](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Type 'DevFast.Net.Text.Json.RawJson.Type') is
[Nothing](DevFast.Net.Text.Json.JsonType.md#DevFast.Net.Text.Json.JsonType.Nothing 'DevFast.Net.Text.Json.JsonType.Nothing').

One should prefer [EnumerateRawJsonArrayElementAsync(bool, CancellationToken)](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken) 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, System.Threading.CancellationToken)')
to parse well-structured JSON stream over this method.
This method is to parse non-standard chain of JSON elements separated by ',' (or not).

```csharp
System.Threading.Tasks.ValueTask<DevFast.Net.Text.Json.RawJson> GetCurrentRawAsync(System.Threading.CancellationToken token, bool withVerify=true);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe.

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).withVerify'></a>

`withVerify` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to verify the presence of ',' or ']' (but not ',]')
            after successfully parsing the current JSON element; [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') otherwise.

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if value is [ArrayBeginByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayBeginByte 'DevFast.Net.Text.Json.JsonConst.ArrayBeginByte'). If the value matches, 
then reader advances its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence or to end of JSON.
Otherwise, it returns [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when current byte is NOT [ArrayBeginByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayBeginByte 'DevFast.Net.Text.Json.JsonConst.ArrayBeginByte') and
reader position is maintained on the current byte.

```csharp
System.Threading.Tasks.ValueTask<bool> ReadIsBeginArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it checks
if value is [ArrayBeginByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayBeginByte 'DevFast.Net.Text.Json.JsonConst.ArrayBeginByte'). If the value matches, then reader advances 
its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence or to end of JSON. If the value does NOT match,
reader position is maintained on the current byte and an error 
(of type [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')) is thrown.

```csharp
System.Threading.Tasks.ValueTask ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(bool, CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if value is [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'). If the value matches, 
then reader advances its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence or to end of JSON.
Otherwise, it returns [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when current byte is NOT [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') and
reader position is maintained on the current byte.

```csharp
System.Threading.Tasks.ValueTask<bool> ReadIsEndArrayAsync(bool ensureEoj, System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken).ensureEoj'></a>

`ensureEoj` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ignore any text (JSON or not) after 
            observing [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte').
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ensure that no data is present after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'). However, both
            single line and multiline comments are allowed before [EoJ](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EoJ').

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(bool,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')