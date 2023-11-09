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

        [Test]
        public async Task BigArrayOfSimpleObjectArray()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new[] { new B(), new B(), new B() }, TotalElements / 3).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<B[]>(m, nameof(BigArrayOfSimpleObjectArray));
        }

        [Test]
        public async Task BigArrayOfSimpleExpandoObjectArray()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new[] { new B(), new B(), new B() }, TotalElements / 3).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<ExpandoObject[]>(m, nameof(BigArrayOfSimpleExpandoObjectArray));
        }

        [Test]
        public async Task BigArrayOfAvgComplexObjectArray()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new[] { new C(), new C(), new C() }, TotalElements / 3).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<C[]>(m, nameof(BigArrayOfAvgComplexObjectArray));
        }

        [Test]
        public async Task BigArrayOfAvgComplexExpandoObjectArray()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new[] { new C(), new C(), new C() }, TotalElements / 3).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<ExpandoObject[]>(m, nameof(BigArrayOfAvgComplexExpandoObjectArray));
        }

        [Test]
        public async Task BigArrayOfComplexObjectArray()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new[] { new A(), new A(), new A() }, TotalElements / 3).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<A[]>(m, nameof(BigArrayOfComplexObjectArray));
        }

        [Test]
        public async Task BigArrayOfComplexExpandoObjectArray()
        {
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new[] { new A(), new A(), new A() }, TotalElements / 3).PushJson().AndWriteStreamAsync(m);
            await MeasureNPrintAsync<ExpandoObject[]>(m, nameof(BigArrayOfComplexExpandoObjectArray));
        }

        [Test]
        public async Task FileBasedOneMillionSimpleObjectArray()
        {
            var name = Guid.NewGuid().ToString("N") + ".json";
            await using (var m = new FileStream(name,
                FileMode.Create,
                FileAccess.Write,
                FileShare.None,
                4 * 1024 * 1024,
                FileOptions.WriteThrough | FileOptions.Asynchronous))
            {
                await Enumerable.Repeat(new B(), 1_000_000).PushJson().AndWriteStreamAsync(m);
                Console.WriteLine($"Size: {m.Position / 1024 / 1024}MB");
            }
            await using var mm = new FileStream(name,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                8 * 1024,
                FileOptions.SequentialScan | FileOptions.Asynchronous | FileOptions.DeleteOnClose);
            await MeasureNPrintAsync<B>(mm, nameof(FileBasedOneMillionSimpleObjectArray), 3, 8 * 1024);
        }

        [Test]
        public async Task FileBasedOneMillionAvgComplexObjectArray()
        {
            var name = Guid.NewGuid().ToString("N") + ".json";
            await using (var m = new FileStream(name,
                             FileMode.Create,
                             FileAccess.Write,
                             FileShare.None,
                             4 * 1024 * 1024,
                             FileOptions.WriteThrough | FileOptions.Asynchronous))
            {
                await Enumerable.Repeat(new C(), 1_000_000).PushJson().AndWriteStreamAsync(m);
                Console.WriteLine($"Size: {m.Position / 1024 / 1024}MB");
            }
            await using var mm = new FileStream(name,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                8 * 1024,
                FileOptions.SequentialScan | FileOptions.Asynchronous | FileOptions.DeleteOnClose);
            await MeasureNPrintAsync<C>(mm, nameof(FileBasedOneMillionAvgComplexObjectArray), 1, 8 * 1024);
        }

        [Test]
        public async Task FileBasedOneMillionComplexObjectArray()
        {
            var name = Guid.NewGuid().ToString("N") + ".json";
            await using (var m = new FileStream(name,
                             FileMode.Create,
                             FileAccess.Write,
                             FileShare.None,
                             4 * 1024 * 1024,
                             FileOptions.Asynchronous))
            {
                await Enumerable.Repeat(new A(), 1_000_000).PushJson().AndWriteStreamAsync(m);
                Console.WriteLine($"Size: {m.Position / 1024 / 1024}MB");
            }
            await using var mm = new FileStream(name,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                1024 * 1024,
                FileOptions.SequentialScan | FileOptions.Asynchronous );
            await MeasureNPrintAsync<A>(mm, nameof(FileBasedOneMillionComplexObjectArray), 3);
        }

        private async Task MeasureNPrintAsync<T>(Stream m, string op, int loop = TotalLoop, int ib = 512)
        {
            var l = 0;
            var sw = Stopwatch.StartNew();
            //sw.Stop();
            //sw.Reset();
            //for (var i = 0; i < loop; i++)
            //{
            //    m.Seek(0, SeekOrigin.Begin);
            //    sw.Start();
            //    l = m.Pull(false).AndParseJsonArray<T>(bufferSize:ib).Count();
            //    sw.Stop();
            //}
            //Console.WriteLine($"[{op}] Count:{l}, Time:{sw.ElapsedMilliseconds}");

            int c = 0;
            sw.Reset();
            for (var i = 0; i < loop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                sw.Start();
                using var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, ib);
                l = r.EnumerateJsonArray(true, CancellationToken.None)
                    .Select((x, _) => Utf8Json.JsonSerializer.Deserialize<T>(x.Value))
                    .Count();
                sw.Stop();
                c = r.Capacity;
            }
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