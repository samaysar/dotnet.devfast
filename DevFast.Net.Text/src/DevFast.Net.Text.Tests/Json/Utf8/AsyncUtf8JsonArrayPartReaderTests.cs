﻿using System.Text;
using DevFast.Net.Text.Json.Utf8;

namespace DevFast.Net.Text.Tests.Json.Utf8
{
    [TestFixture]
    public class AsyncUtf8JsonArrayPartReaderTests
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
            await using (var r = await AsyncUtf8JsonArrayPartReader.CreateInstanceAsync(m, CancellationToken.None, disposeStream: disposeInner))
            {
                That(await r.ReadIsBeginArrayAsync(default), Is.False);
                That(await r.ReadIsEndArrayAsync(false, default), Is.False);
                var current = await r.GetCurrentRawAsync(default);
                That(current.Value, Is.Empty);
                That(current.Type, Is.EqualTo(JsonType.Nothing));
                That(r.EoJ, Is.True);
                That(r.Current, Is.Null);
                That(r.Position, Is.EqualTo(withPreamble ? 3 : 0));
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
            await using (var r = await AsyncUtf8JsonArrayPartReader.CreateInstanceAsync(m, CancellationToken.None, disposeStream: disposeInner))
            {
                That(await r.ReadIsBeginArrayAsync(default), Is.True);
                That(await r.ReadIsBeginArrayAsync(default), Is.False);
                var current = await r.GetCurrentRawAsync(default);
                That(current.Value, Is.Empty);
                That(current.Type, Is.EqualTo(JsonType.Nothing));
                That(r.EoJ, Is.False);
                That(r.Current, Is.EqualTo(JsonConst.ArrayEndByte));
                That(await r.ReadIsEndArrayAsync(true, default), Is.True);
                That(r.Current, Is.Null);
                That(await r.ReadIsEndArrayAsync(false, default), Is.False);
                That(r.EoJ, Is.True);
                That(r.Position, Is.EqualTo(withPreamble ? 5 : 2));
            }
            if (disposeInner) Throws<ObjectDisposedException>(() => m.Write(new byte[] { 1 }));
            else That(m.Length, Is.EqualTo(withPreamble ? 5 : 2));
        }
    }
}