namespace DevFast.Net.Text.Json
{
    /// <summary>
    /// Various JSON types as defined in https://datatracker.ietf.org/doc/html/rfc7159
    /// (also mentioned at https://www.json.org/json-en.html).
    /// </summary>
    public enum JsonType
    {
        /// <summary>
        /// Absence of any other Json types. Normally represents end of JSON data or absence of value.
        /// </summary>
        Nothing = 0,
        /// <summary>
        /// Json object containing everything including and in-between '{' and '}'.
        /// </summary>
        Obj = 1,
        /// <summary>
        /// Array/collection of other JSON types (see <see cref="Array"/>).
        /// </summary>
        Arr = 2,
        /// <summary>
        /// Numerical values (see <see cref="int"/>, <see cref="long"/>, <see cref="double"/>, <see cref="decimal"/> etc.).
        /// </summary>
        Num = 3,
        /// <summary>
        /// Text value containing everything including and in-between '"' and '"' (see <see cref="string"/>).
        /// </summary>
        Str = 4,
        /// <summary>JSON 'true' or 'false' literal (see <see cref="bool"/>).</summary>
        Bool = 5,
        /// <summary>JSON 'null' literal (NOT same as <see cref="Nothing"/>, see <see langword="null"/>).</summary>
        Null = 6
    }
}