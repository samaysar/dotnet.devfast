using DevFast.Net.Extensions.SystemTypes;
using Dot.Net.DevFast.Extensions;
using Dot.Net.DevFast.Extensions.StringExt;
using System.Text;

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
                Assert.Multiple(() =>
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
                That(r.ReadIsBeginArray(), Is.True);
                That(r.ReadIsBeginArray(), Is.False);
                var current = r.ReadRaw(default);
                Assert.Multiple(() =>
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
    }
}