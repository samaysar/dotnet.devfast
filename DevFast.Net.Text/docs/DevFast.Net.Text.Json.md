#### [DevFast.Net.Text](index.md 'index')

## DevFast.Net.Text.Json Namespace

| Classes | |
| :--- | :--- |
| [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException') | Represents error that occurred while parsing parts of a JSON array. |
| [JsonConst](DevFast.Net.Text.Json.JsonConst.md 'DevFast.Net.Text.Json.JsonConst') | Static class holding constant or fixed values for JSON text processing. |

| Structs | |
| :--- | :--- |
| [RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson') | Raw JSON output that provide a valid [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType') and corresponding [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value').   When [Type](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Type 'DevFast.Net.Text.Json.RawJson.Type') is [Nothing](DevFast.Net.Text.Json.JsonType.md#DevFast.Net.Text.Json.JsonType.Nothing 'DevFast.Net.Text.Json.JsonType.Nothing'), [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value') is an empty [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte') array. |

| Interfaces | |
| :--- | :--- |
| [IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader') | Interface dictating implementation to asynchronously parse individual items of a JSON Array  or to parse individual elements (as defined in [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType')) in a JSON sequence. Parsing of such elements produces [RawJson](DevFast.Net.Text.Json.RawJson.md 'DevFast.Net.Text.Json.RawJson') representing entire value-form  (including structural characters, string quotes etc.) as [Value](DevFast.Net.Text.Json.RawJson.md#DevFast.Net.Text.Json.RawJson.Value 'DevFast.Net.Text.Json.RawJson.Value'), of single element at a time,  of a known [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType'). Implementation should avoid any kind of deserialization and, for that, should use other standard JSON deserialization libraries. |

| Enums | |
| :--- | :--- |
| [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType') | Various JSON types as defined in https://datatracker.ietf.org/doc/html/rfc7159 (also mentioned at https://www.json.org/json-en.html). |
