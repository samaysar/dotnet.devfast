using DevFast.Net.Extensions.SystemTypes;
using DevFast.Net.Text.Json.Utf8;
using Dot.Net.DevFast.Extensions.StreamPipeExt;
using System.Diagnostics;
using System.Dynamic;
using System.Text;
using System.Text.Unicode;

namespace DevFast.Net.Text.Tests
{
    [TestFixture, Explicit]
    public class Utf8JsonPerformanceTests
    {
        const int TotalLoop = 1000;
        const int TotalElements = 1000;
        const string ShortStr = "Short String";
        const string LongStr = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";

        [Test]
        public async Task BigArrayOfInt()
        {
            await using var m = new MemoryStream();
            await Enumerable.Range(0, TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<int>(m, nameof(BigArrayOfInt));
        }

        [Test]
        public async Task BigArrayOfLongStrings()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(LongStr, TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<string>(m, nameof(BigArrayOfLongStrings));
        }

        [Test]
        public async Task BigArrayOfShortStrings()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(ShortStr, TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<string>(m, nameof(BigArrayOfShortStrings));
        }

        [Test]
        public async Task BigArrayOfComplexObject()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new A(), TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<A>(m, nameof(BigArrayOfComplexObject));
        }

        [Test]
        public async Task BigArrayOfComplexExpandoObject()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new A(), TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<ExpandoObject>(m, nameof(BigArrayOfComplexExpandoObject));
        }

        [Test]
        public async Task BigArrayOfSimpleObject()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new B(), TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<B>(m, nameof(BigArrayOfSimpleObject));
        }

        [Test]
        public async Task BigArrayOfSimpleExpandoObject()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new B(), TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<ExpandoObject>(m, nameof(BigArrayOfSimpleExpandoObject));
        }

        [Test]
        public async Task BigArrayOfAvgComplexObject()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new C(), TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<C>(m, nameof(BigArrayOfAvgComplexObject));
        }

        [Test]
        public async Task BigArrayOfAvgComplexExpandoObject()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new C(), TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<ExpandoObject>(m, nameof(BigArrayOfAvgComplexExpandoObject));
        }

        private async Task MeasureNPrintAsync<T>(Stream m, string op)
        {
            var l = 0;
            var sw = Stopwatch.StartNew();
            for (var i = 0; i < TotalLoop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                l = m.Pull(false).AndParseJsonArray<T>().Count();
            }
            sw.Stop();
            Console.WriteLine($"[{op}] Count:{l}, Time:{sw.ElapsedMilliseconds}");

            int c = 0;
            sw.Restart();
            for (var i = 0; i < TotalLoop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                await using var r = await JsonReader.CreateAsync(m, CancellationToken.None);
                l = await r.EnumerateRawJsonArrayElementAsync(true, CancellationToken.None)
                    .SelectAsync((x, _) => Utf8Json.JsonSerializer.Deserialize<T>(x.Value))
                    .CountAsync();
                c = r.Capacity;
            }
            sw.Stop();
            Console.WriteLine($"[{op}] Count:{l}, Time:{sw.ElapsedMilliseconds}, Cap: {c}");
        }

        public class A
        {
            public object? No { get; set; } = null;
            public bool Ba { get; set; } = true;
            public decimal D { get; set; } = 123456789.12345m;
            public double Dd { get; set; } = 1.23456789e15;
            public long L { get; set; } = long.MaxValue;
            public int I { get; set; } = int.MaxValue;
            public string Ss { get; set; } = ShortStr;
            public string Bs { get; set; } = LongStr;
            public List<string> Ls { get; set; } = new() { "1", "2", "abcs", "something else" };
            public List<B> Lb { get; set; } = new() { new B(), new B(), new B() };
            public List<C> Lc { get; set; } = new() { new C(), new C(), new C() };
            public B Cb { get; set; } = new B();
            public C Cc { get; set; } = new C();
        }

        public class B
        {
            public bool Bb { get; set; } = true;
            public double Dd { get; set; } = 1.23456789e15;
            public long L { get; set; } = long.MaxValue;
            public int I { get; set; } = int.MaxValue;
        }

        public class C
        {
            public bool Bc { get; set; } = true;
            public string Ss { get; set; } = ShortStr;
            public List<B> Lb { get; set; } = new() { new B(), new B(), new B() };
            public B Cb { get; set; } = new B();
        }
    }
}