#### [DevFast.Net.Text](index.md 'index')

## DevFast.Net.Text.Json Namespace

| Classes | |
| :--- | :--- |
| [JsonArrayPartParsingException](DevFast.Net.Text.Json.JsonArrayPartParsingException.md 'DevFast.Net.Text.Json.JsonArrayPartParsingException') | Represents error that occurred while parsing parts of a JSON array. |
| [JsonConst](DevFast.Net.Text.Json.JsonConst.md 'DevFast.Net.Text.Json.JsonConst') | Static class holding constant or fixed values for JSON text processing. |

| Interfaces | |
| :--- | :--- |
| [IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader') | Interface dictating implementation to asynchronously parse individual items of a JSON Array  in raw form (i.e. [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[]).   Implementation MUST specifically deal with JSON array only and MUST produce a [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[] representing entire value-form (including structural characters, string quotes etc.), of single element at a time, of a known [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType'). To handle any other arbitrary form of JSON one MUST use other existing JSON libraries.  Deserialization from such [System.Byte](https://docs.microsoft.com/en-us/dotnet/api/System.Byte 'System.Byte')[] should NOT be handled by the implementation. |

| Enums | |
| :--- | :--- |
| [JsonType](DevFast.Net.Text.Json.JsonType.md 'DevFast.Net.Text.Json.JsonType') | Various JSON types as defined in https://datatracker.ietf.org/doc/html/rfc7159 (also mentioned at https://www.json.org/json-en.html). |
