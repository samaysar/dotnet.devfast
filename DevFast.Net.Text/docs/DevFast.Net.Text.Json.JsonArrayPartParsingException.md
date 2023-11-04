#### [DevFast.Net.Text](index.md 'index')
### [DevFast.Net.Text.Json](DevFast.Net.Text.Json.md 'DevFast.Net.Text.Json')

## JsonArrayPartParsingException Class

Represents error that occurred while parsing parts of a JSON array.

```csharp
public sealed class JsonArrayPartParsingException : System.Exception
```
- *Constructors*
  - **[JsonArrayPartParsingException()](DevFast.Net.Text.Json.JsonArrayPartParsingException.md#DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException() 'DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException()')**
  - **[JsonArrayPartParsingException(string)](DevFast.Net.Text.Json.JsonArrayPartParsingException.md#DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string) 'DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string)')**
  - **[JsonArrayPartParsingException(string, Exception)](DevFast.Net.Text.Json.JsonArrayPartParsingException.md#DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string,System.Exception) 'DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string, System.Exception)')**

## JsonArrayPartParsingException Class

Represents error that occurred while parsing parts of a JSON array.

```csharp
public sealed class JsonArrayPartParsingException : System.Exception
```

Inheritance [System.Object](https://docs.microsoft.com/en-us/dotnet/api/System.Object 'System.Object') &#129106; [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception') &#129106; JsonArrayPartParsingException
### Constructors

<a name='DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException()'></a>

## JsonArrayPartParsingException() Constructor

Initializes a default new instance of [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException') class.

```csharp
public JsonArrayPartParsingException();
```

<a name='DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string)'></a>

## JsonArrayPartParsingException(string) Constructor

Initializes a new instance of [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException') class
with given [message](DevFast.Net.Text.Json.JsonArrayPartParsingException.md#DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string).message 'DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string).message').

```csharp
public JsonArrayPartParsingException(string message);
```
#### Parameters

<a name='DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Specific error message

<a name='DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string,System.Exception)'></a>

## JsonArrayPartParsingException(string, Exception) Constructor

Initializes a new instance of [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException') class
with given [message](DevFast.Net.Text.Json.JsonArrayPartParsingException.md#DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string,System.Exception).message 'DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string, System.Exception).message') and provided [innerException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md#DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string,System.Exception).innerException 'DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string, System.Exception).innerException').

```csharp
public JsonArrayPartParsingException(string message, System.Exception innerException);
```
#### Parameters

<a name='DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string,System.Exception).message'></a>

`message` [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')

Specific error message

<a name='DevFast.Net.Text.Json.JsonArrayPartParsingException.JsonArrayPartParsingException(string,System.Exception).innerException'></a>

`innerException` [System.Exception](https://docs.microsoft.com/en-us/dotnet/api/System.Exception 'System.Exception')

Inner error instance