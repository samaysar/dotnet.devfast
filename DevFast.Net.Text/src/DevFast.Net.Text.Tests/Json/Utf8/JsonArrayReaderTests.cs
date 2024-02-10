namespace DevFast.Net.Text.Tests.Json.Utf8
{
    internal class JsonArrayReaderTests
    {
        [TestCase(true, false)]
        [TestCase(false, false)]
        [TestCase(true, true)]
        [TestCase(false, true)]
        public async Task Works_Well_When_Stream_Is_Empty(bool withPreamble, bool disposeInner)
        {
            await using Stream m = TestHelper.GetReadableStreamWith("", withPreamble);
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
    }
}
