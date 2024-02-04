namespace DevFast.Net.Text.Tests
{
    internal static class TestHelper
    {
        public static byte[] ComplexRawJson()
        {
            return new UTF8Encoding(false).GetBytes(@"{
                ""a"": [0,1,2,3,4,5,6,7,8,9],
                ""b"": null,
                ""c"": true, /* Another comment
                                until here */
                ""d"": false,
                ""e"": [{""a"":1},{""a"":2}], //comment
                ""f"": 10.5,
                ""g"": -1e5,
                ""h"": ""x""
            }");
        }

        public static void ValidateObjectOfComplexRawJson(dynamic exObj)
        {
            IDictionary<string, object?>? obj = exObj as IDictionary<string, object?>;
            Multiple(() =>
            {
                That(((JsonElement)obj["a"]).GetArrayLength(), Is.EqualTo(10));
                That(((JsonElement)obj["a"])[0].GetInt32(), Is.EqualTo(0));
                That(((JsonElement)obj["a"])[1].GetInt32(), Is.EqualTo(1));
                That(((JsonElement)obj["a"])[2].GetInt32(), Is.EqualTo(2));
                That(((JsonElement)obj["a"])[3].GetInt32(), Is.EqualTo(3));
                That(((JsonElement)obj["a"])[4].GetInt32(), Is.EqualTo(4));
                That(((JsonElement)obj["a"])[5].GetInt32(), Is.EqualTo(5));
                That(((JsonElement)obj["a"])[6].GetInt32(), Is.EqualTo(6));
                That(((JsonElement)obj["a"])[7].GetInt32(), Is.EqualTo(7));
                That(((JsonElement)obj["a"])[8].GetInt32(), Is.EqualTo(8));
                That(((JsonElement)obj["a"])[9].GetInt32(), Is.EqualTo(9));
                That(obj["b"], Is.Null);
                That(((JsonElement)obj["c"]).GetBoolean(), Is.True);
                That(((JsonElement)obj["d"]).GetBoolean(), Is.False);
                That(((JsonElement)obj["e"]).GetArrayLength(), Is.EqualTo(2));
                That(((JsonElement)obj["f"]).GetDecimal(), Is.EqualTo(10.5m));
                That(((JsonElement)obj["g"]).GetDouble(), Is.EqualTo(-100000.0));
                That(((JsonElement)obj["h"]).GetString(), Is.EqualTo("x"));
            });
        }
    }
}
