using System.Dynamic;

namespace DevFast.Net.Text.Tests.Json.Utf8
{
    [TestFixture]
    public class MemJsonArrayReaderTests
    {
        [TestCase(true, false)]
        [TestCase(false, false)]
        [TestCase(true, true)]
        [TestCase(false, true)]
        public async Task Works_Well_When_Stream_Is_Empty(bool withPreamble, bool disposeInner)
        {
            MemoryStream m = new();
            UTF8Encoding e = new(withPreamble);
            await m.WriteAsync(e.GetPreamble());
            _ = m.Seek(0, SeekOrigin.Begin);
            using (IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: disposeInner))
            {
                Multiple(() =>
                {
                    That(r.ReadIsBeginArray(), Is.False);
                    That(r.ReadIsEndArray(false), Is.False);
                    RawJson current = r.ReadRaw(default);
                    That(current.Value, Is.Empty);
                    That(current.Type, Is.EqualTo(JsonType.Undefined));
                    That(r.EoJ, Is.True);
                    That(r.Current, Is.Null);
                    That(r.Position, Is.EqualTo(withPreamble ? 3 : 0));
                });
            }
            if (disposeInner)
            {
                _ = Throws<ObjectDisposedException>(() => m.Write(new byte[] { 1 }));
            }
            else
            {
                That(m.Length, Is.EqualTo(withPreamble ? 3 : 0));
            }
        }

        [TestCase(true, false)]
        [TestCase(false, false)]
        [TestCase(true, true)]
        [TestCase(false, true)]
        public async Task Works_Well_When_Stream_Contains_Empty_Array(bool withPreamble, bool disposeInner)
        {
            MemoryStream m = new();
            UTF8Encoding e = new(withPreamble);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte, JsonConst.ArrayEndByte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using (IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: disposeInner))
            {
                That(r.Capacity, Is.EqualTo(m.Capacity));
                That(r.ReadIsBeginArray(), Is.True);
                That(r.ReadIsBeginArray(), Is.False);
                RawJson current = r.ReadRaw(default);
                Multiple(() =>
                {
                    That(current.Value, Is.Empty);
                    That(current.Type, Is.EqualTo(JsonType.Undefined));
                    That(r.EoJ, Is.False);
                    That(r.Current, Is.EqualTo(JsonConst.ArrayEndByte));
                    That(r.ReadIsEndArray(true), Is.True);
                    That(r.Current, Is.Null);
                    That(r.ReadIsEndArray(false), Is.False);
                    That(r.EoJ, Is.True);
                    That(r.Position, Is.EqualTo(withPreamble ? 5 : 2));
                });
            }
            if (disposeInner)
            {
                _ = Throws<ObjectDisposedException>(() => m.Write(new byte[] { 1 }));
            }
            else
            {
                That(m.Length, Is.EqualTo(withPreamble ? 5 : 2));
            }
        }

        [Test]
        public async Task EnumerateJsonArray_Has_No_Data_When_Stream_Contains_Empty_Array()
        {
            MemoryStream m = new();
            UTF8Encoding e = new(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte, JsonConst.ArrayEndByte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using (IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true))
            {
                That(r.EnumerateJsonArray(true).Count(), Is.EqualTo(0));
            }
            _ = Throws<ObjectDisposedException>(() => m.Write(new byte[] { 1 }));
        }

        [Test]
        public async Task EnumerateJsonArray_Returns_Data_When_Stream_Contains_At_Least_One_Element()
        {
            MemoryStream m = new();
            UTF8Encoding e = new(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte, JsonConst.Number9Byte, JsonConst.ArrayEndByte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true);
            List<RawJson> dataPoints = r.EnumerateJsonArray(true).ToList();
            That(dataPoints.Count, Is.EqualTo(1));
            That(dataPoints[0].Type, Is.EqualTo(JsonType.Num));
            That(dataPoints[0].Value.Length, Is.EqualTo(1));
            That(dataPoints[0].Value[0], Is.EqualTo(JsonConst.Number9Byte));
        }

        [Test]
        public async Task EnumerateJsonArray_Throws_Error_For_Undefined_Types()
        {
            MemoryStream m = new();
            UTF8Encoding e = new(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true);
            JsonException? err = Throws<JsonException>(() => r.EnumerateJsonArray(true).ToList());
            That(err, Is.Not.Null);
            That(err.Message, Is.EqualTo("Expected a valid JSON element or end of JSON array. 0-Based Position = 1."));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReadIsBeginArrayWithVerify_Throws_Error_When_Current_Location_Is_Not_Begin_Array_Character(bool keepRange)
        {
            MemoryStream m = new();
            UTF8Encoding e = new(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(keepRange ? new[] { JsonConst.ArrayBeginByte, JsonConst.ArrayEndByte } : new[] { JsonConst.ArrayBeginByte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true);
            r.ReadIsBeginArrayWithVerify();
            JsonException? err = Throws<JsonException>(() => r.ReadIsBeginArrayWithVerify());
            That(err, Is.Not.Null);
            That(err.Message, Is.EqualTo(keepRange ?
                "Invalid byte value for JSON begin-array. Expected = 91, Found = ], 0-Based Position = 1." :
                "Reached end, unable to find JSON begin-array. 0-Based Position = 1."));
        }

        [Test]
        public async Task ReadIsEndArray_Throws_Error_When_EoJ_Is_Required_But_Data_Is_Present()
        {
            MemoryStream m = new();
            UTF8Encoding e = new(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayEndByte, JsonConst.ArrayBeginByte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true);
            JsonException? err = Throws<JsonException>(() => r.ReadIsEndArray(true));
            That(err, Is.Not.Null);
            That(err.Message, Is.EqualTo("Expected End Of JSON after encountering ']'. 0-Based Position = 1."));
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReadRaw_Can_Read_Elements_WithOrWithout_Value_Separator(bool addValueSeparator)
        {
            MemoryStream m = new();
            UTF8Encoding e = new(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(addValueSeparator ?
                new[] { JsonConst.Number9Byte, JsonConst.ValueSeparatorByte, JsonConst.Number8Byte } :
                new[] { JsonConst.Number9Byte, JsonConst.SpaceByte, JsonConst.Number8Byte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true);
            RawJson d1 = r.ReadRaw(false);
            RawJson d2 = r.ReadRaw(false);
            RawJson d3 = r.ReadRaw(false);
            Multiple(() =>
            {
                That(d1.Type, Is.EqualTo(JsonType.Num));
                That(d2.Type, Is.EqualTo(JsonType.Num));
                That(d3.Type, Is.EqualTo(JsonType.Undefined));
                That(d1.Value[0], Is.EqualTo(JsonConst.Number9Byte));
                That(d2.Value[0], Is.EqualTo(JsonConst.Number8Byte));
            });
        }

        [Test]
        public async Task ReadRaw_Throws_Error_If_Data_Has_Invalid_Format()
        {
            MemoryStream m = new();
            UTF8Encoding e = new(true);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.SecondOfHexDigitInStringByte });
            _ = m.Seek(0, SeekOrigin.Begin);
            using IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true);
            JsonException? err = Throws<JsonException>(() => r.ReadRaw(false));
            Multiple(() =>
            {
                That(err, Is.Not.Null);
                That(err.Message, Is.EqualTo("Invalid byte value for start of JSON element. Found = u, 0-Based Position = 3."));
            });
        }

        [Test]
        public async Task ReadRaw_Properly_Reads_Complex_Raw_Json()
        {
            MemoryStream m = new();
            UTF8Encoding e = new(true);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(TestHelper.ComplexRawJson());
            _ = m.Seek(0, SeekOrigin.Begin);
            using IJsonArrayReader r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true);
            RawJson raw = r.ReadRaw(false);
            That(raw.Type, Is.EqualTo(JsonType.Obj));
            TestHelper.ValidateObjectOfComplexRawJson(JsonSerializer.Deserialize<ExpandoObject>(raw.Value, new JsonSerializerOptions
            {
                ReadCommentHandling = JsonCommentHandling.Skip
            })!);
        }
    }
}