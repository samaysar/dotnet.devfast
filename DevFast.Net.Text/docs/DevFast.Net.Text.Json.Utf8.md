#### [DevFast.Net.Text](index.md 'index')

## DevFast.Net.Text.Json.Utf8 Namespace

| Classes | |
| :--- | :--- |
| [AsyncUtf8JsonArrayPartReader](DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader.md 'DevFast.Net.Text.Json.Utf8.AsyncUtf8JsonArrayPartReader') | Class implementing [IAsyncJsonArrayPartReader](DevFast.Net.Text.Json.IAsyncJsonArrayPartReader.md 'DevFast.Net.Text.Json.IAsyncJsonArrayPartReader') for standard Utf-8 JSON data encoding based on https://datatracker.ietf.org/doc/html/rfc7159 (grammar shown at https://www.json.org/json-en.html).   Current implementation parses following two (2) types and three (3) literal values 'null', 'true', 'false' without any validation:  1. Unicode code-points values (i.e. in \uXXXX, X can be any valid byte value). 2. Numeric values (both 2.0e-1+10 and 2.0Ee10 will be parsed as Numeric values without error).   The main reason to ignore validation is that such error MUST be thrown during deserialization. Also, to keep the code simple and faster. This implementation support both single line comments (starting with '//' and ending in either Carriage return '\r' or newline '\n') and multiline comments (starting with '/*' and ending with '*/'). |
