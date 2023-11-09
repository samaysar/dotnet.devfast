namespace DevFast.Net.Text.PerfRunner
{
    public static class MeasurePerf
    {
        const int TotalLoop = 1000;
        const int TotalFileLoop = 3;
        public const int TotalElements = 1000;
        public const int BufferSize = 4*1024;
        public const string ShortStr = "Short String";
        public const string LongStr = "It is a long established fact that a reader will be distracted by the readable content of a page when looking at its layout. The point of using Lorem Ipsum is that it has a more-or-less normal distribution of letters, as opposed to using 'Content here, content here', making it look like readable English. Many desktop publishing packages and web page editors now use Lorem Ipsum as their default model text, and a search for 'lorem ipsum' will uncover many web sites still in their infancy. Various versions have evolved over the years, sometimes by accident, sometimes on purpose (injected humour and the like).";

        public static async Task MeasureInMemory<T>(MemoryStream m, int loop = TotalLoop, int ib = BufferSize)
        {
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            MeasurePerf.MeasureOnNewton<T>(m, loop, ib);
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            MeasurePerf.MeasureOnDevFastNewton<T>(m, loop, ib);
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            MeasurePerf.MeasureOnUtf8Json<T>(m, loop);
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            await MeasurePerf.MeasureOnDevFastUtf8Json<T>(m, loop, ib);
        }

        public static async Task MeasureFile<T>(Stream m, int loop = TotalFileLoop, int ib = BufferSize)
        {
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            MeasurePerf.MeasureOnDevFastNewton<T>(m, loop, ib);
            GC.Collect(2, GCCollectionMode.Forced, true, true);
            await MeasurePerf.MeasureOnDevFastUtf8Json<T>(m, loop, ib);
        }

        static void MeasureOnNewton<T>(MemoryStream m, int loop, int ib)
        {
            var l = 0;
            var sw = Stopwatch.StartNew();
            sw.Stop();
            sw.Reset();
            for (var i = 0; i < loop; i++)
            {
                m.Seek(0, SeekOrigin.Begin);
                sw.Start();
                l += new Newtonsoft.Json.JsonSerializer().Deserialize<T[]>(new Newtonsoft.Json.JsonTextReader(new StreamReader(m, System.Text.Encoding.UTF8, true, ib, true)))!.Length;
                sw.Stop();
            }
            Console.WriteLine($"NEWTONSOFT: Loop: {loop}, Array Len:{l / loop}, Time:{sw.Elapsed.TotalMilliseconds / loop} ms per loop");
        }

        static void MeasureOnDevFastNewton<T>(Stream m, int loop, int ib)
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
            Console.WriteLine($"DEVFAST+NEWTONSOFT: Loop: {loop}, Array Len:{l / loop}, Time:{sw.Elapsed.TotalMilliseconds / loop} ms per loop");
        }

        //DONT USE ANY GENERIC STREAM, WE NEITHER WANT TO TEST IN 64-BIT MODE NOR
        //WANT TO HAVE OOM!!!
        static void MeasureOnUtf8Json<T>(MemoryStream m, int loop)
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
            Console.WriteLine($"UTF8JSON: Loop: {loop}, Array Len:{l / loop}, Time:{sw.Elapsed.TotalMilliseconds / loop} ms per loop");
        }

        static async Task MeasureOnDevFastUtf8Json<T>(Stream m, int loop, int ib)
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
                c = Math.Max(c, r.Capacity);
            }
            Console.WriteLine($"DEVFAST+UTF8JSON: Loop: {loop}, Array Len:{l / loop}, Time:{sw.Elapsed.TotalMilliseconds / loop} ms per loop, Memory Consumed: {c} Bytes");
        }
    }
}