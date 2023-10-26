#### [DevFast.Net.Text](index.md 'index')
### [DevFast.Net.Text.Json](DevFast.Net.Text.Json.md 'DevFast.Net.Text.Json')

## IAsyncJsonArrayPartReader Interface

Interface dictating implementation to asynchronously parse individual items of a JSON Array 
in raw form (i.e. [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[]).

Implementation MUST specifically deal with JSON array only and MUST produce a [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[]
representing entire value-form (including structural characters, string quotes etc.), of single
element at a time, of a known [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType').
To handle any other arbitrary form of JSON one MUST use other existing JSON libraries.

Deserialization from such [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[] should NOT be handled by the implementation.

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
            reader has reached [EndOfJson](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson').

```csharp
System.Nullable<byte> Current { get; }
```

#### Property Value
[System.Nullable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Nullable-1 'System.Nullable`1')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.Distance'></a>

## IAsyncJsonArrayPartReader.Distance Property

Total number of [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')s observed by the reader since the very beginning (0-based position).

```csharp
long Distance { get; }
```

#### Property Value
[System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson'></a>

## IAsyncJsonArrayPartReader.EndOfJson Property

[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') indicating that reader has reached end of JSON input,
            otherwise [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool').

```csharp
bool EndOfJson { get; }
```

#### Property Value
[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')
### Methods

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool, CancellationToken) Method

Provides a convenient way to asynchronously enumerate over elements of a JSON array (one at a time).
For every iteration, such mechanism produces [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[] representing
entire value-form (including structural characters, string quotes etc.) of such an individual
element.

```csharp
System.Collections.Generic.IAsyncEnumerable<byte[]> EnumerateRawJsonArrayElementAsync(bool ensureEoj, System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).ensureEoj'></a>

`ensureEoj` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

[false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ignore leftover JSON after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte').
            [true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') to ensure that data is present after [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') (however, both
            single line and multiline comments are allowed).

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EnumerateRawJsonArrayElementAsync(bool,System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe.

#### Returns
[System.Collections.Generic.IAsyncEnumerable&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Collections.Generic.IAsyncEnumerable-1 'System.Collections.Generic.IAsyncEnumerable`1')

#### Exceptions

[JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool)'></a>

## IAsyncJsonArrayPartReader.GetCurrentRawAsync(CancellationToken, bool) Method

```csharp
System.Threading.Tasks.ValueTask<byte[]> GetCurrentRawAsync(System.Threading.CancellationToken token, bool withVerify=true);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).withVerify'></a>

`withVerify` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.ReadIsBeginArrayAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if value is [ArrayBeginByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayBeginByte 'DevFast.Net.Text.Json.JsonConst.ArrayBeginByte')
(also makes reader advance its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence).
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
its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence. If the value does NOT match,
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

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if value is [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte')
(also makes reader advance its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence or to end of JSON).
Otherwise, it returns [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when current byte is NOT [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') and
reader position is maintained on the current byte.

```csharp
System.Threading.Tasks.ValueTask<bool> ReadIsEndArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it returns
[true](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') if value is [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') 
(also makes reader advance its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence)
or [EndOfJson](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson') is reached.
Otherwise, it returns [false](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/bool') when current byte is NEITHER [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte') 
NOR [EndOfJson](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson') and reader position is maintained on the current byte.

```csharp
System.Threading.Tasks.ValueTask<bool> ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayOrEndOfJsonAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken)'></a>

## IAsyncJsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(CancellationToken) Method

Call makes reader skip all the irrelevant whitespaces (comments included). Once done, it checks
if value is [ArrayEndByte](DevFast.Net.Text.Json.JsonConst.md#DevFast.Net.Text.Json.JsonConst.ArrayEndByte 'DevFast.Net.Text.Json.JsonConst.ArrayEndByte'). If the value matches, then reader advances 
its current position to next [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') in the sequence. If the value does NOT match or
[EndOfJson](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md#DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.EndOfJson') is detected, reader position is maintained on the current byte and an error 
(of type [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException')) is thrown.

```csharp
System.Threading.Tasks.ValueTask ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.ReadIsEndArrayWithEndOfJsonVerifyAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

Cancellation token to observe

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')