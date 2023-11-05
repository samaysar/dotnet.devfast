using DevFast.Net.Extensions.SystemTypes;
using DevFast.Net.Text.Json.Utf8;
using Dot.Net.DevFast.Extensions.StreamPipeExt;
using System.Diagnostics;

namespace DevFast.Net.Text.Tests
{
    [TestFixture, Explicit]
    public class Utf8JsonPerformanceTests
    {
        const int TotalLoop = 100;

        [Test]
        public async Task BigArrayOfInt()
        {
            await using var m = new MemoryStream();
            await Enumerable.Range(0,10000).PushJson().AndWriteStreamAsync(m);
            var sw = Stopwatch.StartNew();
            var l = 0;
            for (var i = 0; i < TotalLoop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                l = m.Pull(false).AndParseJsonArray<int>().Count();
            }
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < TotalLoop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                await using var r = await JsonReader.CreateAsync(m, CancellationToken.None);
                l = await r.EnumerateRawJsonArrayElementAsync(true, CancellationToken.None)
                    .SelectAsync((x, _) => Utf8Json.JsonSerializer.Deserialize<int>(x.Value))
                    .CountAsync();
            }
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);            
        }

        [Test]
        public async Task BigArrayOfStrings()
        {
            const string str = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";
            await using var m = new MemoryStream();
            await Enumerable.Repeat(str, 10000).PushJson().AndWriteStreamAsync(m);
            var sw = Stopwatch.StartNew();
            var l = 0;
            for (var i = 0; i < TotalLoop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                l = m.Pull(false).AndParseJsonArray<string>().Count();
            }
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);

            sw.Restart();
            for (var i = 0; i < TotalLoop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                await using var r = await JsonReader.CreateAsync(m, CancellationToken.None);
                l = await r.EnumerateRawJsonArrayElementAsync(true, CancellationToken.None)
                    .SelectAsync((x, _) => Utf8Json.JsonSerializer.Deserialize<string>(x.Value))
                    .CountAsync();
            }
            sw.Stop();
            Console.WriteLine(l);
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
}