using DevFast.Net.Extensions.SystemTypes;
using DevFast.Net.Text.Json.Utf8;
using Dot.Net.DevFast.Extensions.StreamPipeExt;
using System.Diagnostics;

namespace DevFast.Net.Text.Tests
{
    [TestFixture, Explicit]
    public class Utf8JsonPerformanceTests
    {
        [Test]
        public async Task BigArrayOfInt()
        {
            await using var m = new MemoryStream();
            await Enumerable.Range(0,10000).PushJson().AndWriteStreamAsync(m);
            m.Seek(0, SeekOrigin.Begin);
            var sw = Stopwatch.StartNew();
            var l = m.Pull(false).AndParseJsonArray<int>().Count();
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);

            m.Seek(0, SeekOrigin.Begin);
            sw.Restart();
            await using var r = await AsyncUtf8JsonArrayPartReader.CreateInstanceAsync(m, CancellationToken.None);
            l = await r.EnumerateRawJsonArrayElementAsync(true, CancellationToken.None)
                .SelectAsync((x, _) => Utf8Json.JsonSerializer.Deserialize<int>(x.Value))
                .CountAsync();
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);            
        }

        [Test]
        public async Task BigArrayOfStrings()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat("I am a JSON string for testing", 10000).PushJson().AndWriteStreamAsync(m);
            m.Seek(0, SeekOrigin.Begin);
            var sw = Stopwatch.StartNew();
            var l = m.Pull(false).AndParseJsonArray<string>().Count();
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);

            m.Seek(0, SeekOrigin.Begin);
            sw.Restart();
            await using var r = await AsyncUtf8JsonArrayPartReader.CreateInstanceAsync(m, CancellationToken.None);
            l = await r.EnumerateRawJsonArrayElementAsync(true, CancellationToken.None)
                .SelectAsync((x, _) => Utf8Json.JsonSerializer.Deserialize<string>(x.Value))
                .CountAsync();
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}