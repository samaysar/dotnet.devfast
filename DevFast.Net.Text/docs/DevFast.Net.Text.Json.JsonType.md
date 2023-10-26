#### [DevFast.Net.Text](index.md 'index')
### [DevFast.Net.Text.Json](DevFast.Net.Text.Json.md 'DevFast.Net.Text.Json')

## JsonType Enum

Various JSON types as defined in https://datatracker.ietf.org/doc/html/rfc7159
(also mentioned at https://www.json.org/json-en.html).

```csharp
public enum JsonType
```
### Fields

<a name='DevFast.Net.Text.Json.JsonType.Arr'></a>

`Arr` 2

Array/collection of other JSON types (see [System.Array](https://docs.microsoft.com/en-us/dotnet/api/System.Array 'System.Array')).

<a name='DevFast.Net.Text.Json.JsonType.Bool'></a>

`Bool` 5

JSON 'true' or 'false' literal (see [System.Boolean](https://docs.microsoft.com/en-us/dotnet/api/System.Boolean 'System.Boolean')).

<a name='DevFast.Net.Text.Json.JsonType.Nothing'></a>

`Nothing` 0

Absence of any other Json types. Normally represents end of JSON data or absence of value.

<a name='DevFast.Net.Text.Json.JsonType.Null'></a>

`Null` 6

JSON 'null' literal (NOT same as [Nothing](DevFast.Net.Text.Json.JsonType.md#DevFast.Net.Text.Json.JsonType.Nothing 'DevFast.Net.Text.Json.JsonType.Nothing'), see [null](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null 'https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/null')).

<a name='DevFast.Net.Text.Json.JsonType.Num'></a>

`Num` 3

Numerical values (see [System.Int32](https://docs.microsoft.com/en-us/dotnet/api/System.Int32 'System.Int32'), [System.Int64](https://docs.microsoft.com/en-us/dotnet/api/System.Int64 'System.Int64'), [System.Double](https://docs.microsoft.com/en-us/dotnet/api/System.Double 'System.Double'), [System.Decimal](https://docs.microsoft.com/en-us/dotnet/api/System.Decimal 'System.Decimal') etc.).

<a name='DevFast.Net.Text.Json.JsonType.Obj'></a>

`Obj` 1

Json object containing everything including and in-between '{' and '}'.

<a name='DevFast.Net.Text.Json.JsonType.Str'></a>

`Str` 4

Text value containing everything including and in-between '"' and '"' (see [System.String](https://docs.microsoft.com/en-us/dotnet/api/System.String 'System.String')).