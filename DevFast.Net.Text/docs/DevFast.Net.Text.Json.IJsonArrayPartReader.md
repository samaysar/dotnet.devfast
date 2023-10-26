#### [DevFast.Net.Text](index.md 'index')
### [DevFast.Net.Text.Json](DevFast.Net.Text.Json.md 'DevFast.Net.Text.Json')

## IJsonArrayPartReader Interface

Interface to dictate how to read a single raw item from a stream of JSON Array.

These readers MUST NOT be used to read any arbitrary JSON but a single JSON Array only.

```csharp
public interface IJsonArrayPartReader :
System.IAsyncDisposable
```

Implements [System.IAsyncDisposable](https://docs.microsoft.com/en-us/dotnet/api/System.IAsyncDisposable 'System.IAsyncDisposable')
### Methods

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool)'></a>

## IJsonArrayPartReader.GetCurrentRawAsync(CancellationToken, bool) Method

```csharp
System.Threading.Tasks.ValueTask<byte[]> GetCurrentRawAsync(System.Threading.CancellationToken token, bool withVerify=true);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.GetCurrentRawAsync(System.Threading.CancellationToken,bool).withVerify'></a>

`withVerify` [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[[]](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken)'></a>

## IJsonArrayPartReader.ReadIsBeginArrayAsync(CancellationToken) Method

```csharp
System.Threading.Tasks.ValueTask<bool> ReadIsBeginArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.ReadIsBeginArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken)'></a>

## IJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(CancellationToken) Method

```csharp
System.Threading.Tasks.ValueTask ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.ReadIsBeginArrayWithVerifyAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.ValueTask](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask 'System.Threading.Tasks.ValueTask')

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken)'></a>

## IJsonArrayPartReader.ReadIsEndArrayAsync(CancellationToken) Method

```csharp
System.Threading.Tasks.ValueTask<bool> ReadIsEndArrayAsync(System.Threading.CancellationToken token);
```
#### Parameters

<a name='DevFast.Net.Text.Json.IJsonArrayPartReader.ReadIsEndArrayAsync(System.Threading.CancellationToken).token'></a>

`token` [System.Threading.CancellationToken](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.CancellationToken 'System.Threading.CancellationToken')

#### Returns
[System.Threading.Tasks.ValueTask&lt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')[System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')[&gt;](https://docs.microsoft.com/en-us/dotnet/api/System.Threading.Tasks.ValueTask-1 'System.Threading.Tasks.ValueTask`1')