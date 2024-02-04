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
            var m = new MemoryStream();
            var e = new UTF8Encoding(withPreamble);
            await m.WriteAsync(e.GetPreamble());
            m.Seek(0, SeekOrigin.Begin);
            using (var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: disposeInner))
            {
                Multiple(() =>
                {
                    That(r.ReadIsBeginArray(), Is.False);
                    That(r.ReadIsEndArray(false), Is.False);
                    var current = r.ReadRaw(default);
                    That(current.Value, Is.Empty);
                    That(current.Type, Is.EqualTo(JsonType.Undefined));
                    That(r.EoJ, Is.True);
                    That(r.Current, Is.Null);
                    That(r.Position, Is.EqualTo(withPreamble ? 3 : 0));
                });
            }
            if (disposeInner) Throws<ObjectDisposedException>(() => m.Write(new byte[] { 1 }));
            else That(m.Length, Is.EqualTo(withPreamble ? 3 : 0));
        }

        [TestCase(true, false)]
        [TestCase(false, false)]
        [TestCase(true, true)]
        [TestCase(false, true)]
        public async Task Works_Well_When_Stream_Contains_Empty_Array(bool withPreamble, bool disposeInner)
        {
            var m = new MemoryStream();
            var e = new UTF8Encoding(withPreamble);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte, JsonConst.ArrayEndByte });
            m.Seek(0, SeekOrigin.Begin);
            using (var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: disposeInner))
            {
                That(r.Capacity, Is.EqualTo(m.Capacity));
                That(r.ReadIsBeginArray(), Is.True);
                That(r.ReadIsBeginArray(), Is.False);
                var current = r.ReadRaw(default);
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
            if (disposeInner) Throws<ObjectDisposedException>(() => m.Write(new byte[] { 1 }));
            else That(m.Length, Is.EqualTo(withPreamble ? 5 : 2));
        }

        [Test]
        public async Task EnumerateJsonArray_Has_No_Data_When_Stream_Contains_Empty_Array()
        {
            var m = new MemoryStream();
            var e = new UTF8Encoding(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte, JsonConst.ArrayEndByte });
            m.Seek(0, SeekOrigin.Begin);
            using (var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true))
            {
                That(r.EnumerateJsonArray(true).Count(), Is.EqualTo(0));
            }
            Throws<ObjectDisposedException>(() => m.Write(new byte[] { 1 }));
        }

        [Test]
        public async Task EnumerateJsonArray_Returns_Data_When_Stream_Contains_At_Least_One_Element()
        {
            var m = new MemoryStream();
            var e = new UTF8Encoding(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte, JsonConst.Number9Byte, JsonConst.ArrayEndByte });
            m.Seek(0, SeekOrigin.Begin);
            using (var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true))
            {
                var dataPoints = r.EnumerateJsonArray(true).ToList();
                That(dataPoints.Count, Is.EqualTo(1));
                That(dataPoints[0].Type, Is.EqualTo(JsonType.Num));
                That(dataPoints[0].Value.Length, Is.EqualTo(1));
                That(dataPoints[0].Value[0], Is.EqualTo(JsonConst.Number9Byte));
            }
        }

        [Test]
        public async Task EnumerateJsonArray_Throws_Error_For_Undefined_Types()
        {
            var m = new MemoryStream();
            var e = new UTF8Encoding(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(new[] { JsonConst.ArrayBeginByte });
            m.Seek(0, SeekOrigin.Begin);
            using (var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true))
            {
                var err = Throws<JsonException>(() => r.EnumerateJsonArray(true).ToList());
                That(err, Is.Not.Null);
                That(err.Message, Is.EqualTo("Expected a valid JSON element or end of JSON array. 0-Based Position = 1."));
            }
        }

        [Test]
        [TestCase(true)]
        [TestCase(false)]
        public async Task ReadIsBeginArrayWithVerify_Throws_Error_When_Current_Location_Is_Not_Begin_Array_Character(bool keepRange)
        {
            var m = new MemoryStream();
            var e = new UTF8Encoding(false);
            await m.WriteAsync(e.GetPreamble());
            await m.WriteAsync(keepRange ? new[] { JsonConst.ArrayBeginByte, JsonConst.ArrayEndByte } : new[] { JsonConst.ArrayBeginByte });
            m.Seek(0, SeekOrigin.Begin);
            using (var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, disposeStream: true))
            {
                r.ReadIsBeginArrayWithVerify();
                var err = Throws<JsonException>(() => r.ReadIsBeginArrayWithVerify());
                That(err, Is.Not.Null);
                That(err.Message, Is.EqualTo(keepRange ?
                    "Invalid byte value for JSON begin-array. Expected = 91, Found = ], 0-Based Position = 1." :
                    "Reached end, unable to find JSON begin-array. 0-Based Position = 1."));
            }
        }
    }
}