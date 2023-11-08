using System.Diagnostics;
using DevFast.Net.Text.Json;
using Dot.Net.DevFast.Extensions.StreamPipeExt;

namespace DevFast.Net.Text.PerfRunner
{
    public static class MeasurePerf
    {
        public static void MeasureOnNewton<T>(Stream m, string op, int loop = 1000, int ib = 512)
        {
            var l = 0;
            var sw = Stopwatch.StartNew();
            sw.Stop();
            sw.Reset();
            for (var i = 0; i < loop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                sw.Start();
                l += m.Pull(false).AndParseJsonArray<T>(bufferSize: ib).Count();
                sw.Stop();
            }
            Console.WriteLine($"[{op}] NEWTONSOFT Count:{l / loop}, Time:{sw.ElapsedMilliseconds}");
        }

        //DONT USE ANY GENERIC STREAM, WE NEITHER WANT TO TEST IN 64-BIT MODE NOR
        //WANT TO HAVE OOM!!!
        public static void MeasureOnUtf8Json<T>(MemoryStream m, string op, int loop = 1000)
        {
            var l = 0;
            var sw = Stopwatch.StartNew();
            sw.Stop();
            sw.Reset();
            for (var i = 0; i < loop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                sw.Start();
                l += Utf8Json.JsonSerializer.Deserialize<T[]>(m).Length;
                sw.Stop();
            }
            Console.WriteLine($"[{op}] UTF8JSON Count:{l / loop}, Time:{sw.ElapsedMilliseconds}");
        }

        public static async Task MeasureOnDevFastUtf8Json<T>(Stream m, string op, int loop = 1000, int ib = 512)
        {
            var l = 0;
            var sw = Stopwatch.StartNew();
            int c = 0;

            sw.Stop();
            sw.Reset();
            for (var i = 0; i < loop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                sw.Start();
                using var r = await JsonReader.CreateUtf8ArrayReaderAsync(m, CancellationToken.None, ib);
                l += r.EnumerateJsonArray(true, CancellationToken.None)
                    .Select((x, _) => Utf8Json.JsonSerializer.Deserialize<T>(x.Value))
                    .Count();
                sw.Stop();
                c = r.Capacity;
            }
            Console.WriteLine($"[{op}] DEVFAST+UTF8JSON Count:{l / loop}, Time:{sw.ElapsedMilliseconds}, Cap: {c}");
        }
    }
}