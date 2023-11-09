namespace DevFast.Net.Text.PerfRunner
{
    public static class SimpleArray
    {
        public static async Task RunInMemoryAsync()
        {
            await MemoryBigArrayOfInt();
            await MemoryBigArrayOfLongStrings();
            await MemoryBigArrayOfShortStrings();
        }

        public static async Task RunFromFileAsync()
        {
            await FileBigArrayOfInt();
            await FileBigArrayOfLongStrings();
            await FileBigArrayOfShortStrings();
        }

        static async Task MemoryBigArrayOfInt()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} INT --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Range(0, MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<int>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task MemoryBigArrayOfLongStrings()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} Big String <Len:{MeasurePerf.LongStr.Length}> --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(MeasurePerf.LongStr, MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<string>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task MemoryBigArrayOfShortStrings()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} Short String <Len:{MeasurePerf.ShortStr.Length}> --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(MeasurePerf.ShortStr, MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<string>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task FileBigArrayOfInt()
        {
            var name = Guid.NewGuid().ToString("N") + ".json";
            await using (var m = new FileStream(name,
                             FileMode.Create,
                             FileAccess.Write,
                             FileShare.None,
                             1024 * 1024,
                             FileOptions.Asynchronous))
            {
                await Console.Out.WriteLineAsync("----------------------------------------------------");
                await Console.Out.WriteLineAsync($"-- FILE Array of {MeasurePerf.TotalElements * MeasurePerf.TotalElements} INT --");
                await Console.Out.WriteLineAsync("----------------------------------------------------");
                var sw = Stopwatch.StartNew();
                await Enumerable.Range(0, MeasurePerf.TotalElements * MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
                sw.Stop();
                Console.WriteLine($"File-Size: {m.Position / 1024 / 1024} MB, WRITE-TIME: {sw.ElapsedMilliseconds} ms");
            }
            await using var mm = new FileStream(name,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                1024 * 1024,
                FileOptions.SequentialScan | FileOptions.Asynchronous | FileOptions.DeleteOnClose);
            await MeasurePerf.MeasureFile<int>(mm);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task FileBigArrayOfLongStrings()
        {
            var name = Guid.NewGuid().ToString("N") + ".json";
            await using (var m = new FileStream(name,
                             FileMode.Create,
                             FileAccess.Write,
                             FileShare.None,
                             1024 * 1024,
                             FileOptions.Asynchronous))
            {
                await Console.Out.WriteLineAsync("----------------------------------------------------");
                await Console.Out.WriteLineAsync($"-- FILE Array of {MeasurePerf.TotalElements * MeasurePerf.TotalElements} Big String <Len:{MeasurePerf.LongStr.Length}> --");
                await Console.Out.WriteLineAsync("----------------------------------------------------");
                var sw = Stopwatch.StartNew();
                await Enumerable.Repeat(MeasurePerf.LongStr, MeasurePerf.TotalElements * MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
                sw.Stop();
                Console.WriteLine($"File-Size: {m.Position / 1024 / 1024} MB, WRITE-TIME: {sw.ElapsedMilliseconds} ms");
            }
            await using var mm = new FileStream(name,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                1024 * 1024,
                FileOptions.SequentialScan | FileOptions.Asynchronous | FileOptions.DeleteOnClose);
            await MeasurePerf.MeasureFile<string>(mm);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task FileBigArrayOfShortStrings()
        {
            var name = Guid.NewGuid().ToString("N") + ".json";
            await using (var m = new FileStream(name,
                             FileMode.Create,
                             FileAccess.Write,
                             FileShare.None,
                             1024 * 1024,
                             FileOptions.Asynchronous))
            {
                await Console.Out.WriteLineAsync("----------------------------------------------------");
                await Console.Out.WriteLineAsync($"-- FILE Array of {MeasurePerf.TotalElements * MeasurePerf.TotalElements} Short String <Len:{MeasurePerf.ShortStr.Length}> --");
                await Console.Out.WriteLineAsync("----------------------------------------------------");
                var sw = Stopwatch.StartNew();
                await Enumerable.Repeat(MeasurePerf.ShortStr, MeasurePerf.TotalElements * MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
                sw.Stop();
                Console.WriteLine($"File-Size: {m.Position / 1024 / 1024} MB, WRITE-TIME: {sw.ElapsedMilliseconds} ms");
            }
            await using var mm = new FileStream(name,
                FileMode.Open,
                FileAccess.Read,
                FileShare.None,
                1024 * 1024,
                FileOptions.SequentialScan | FileOptions.Asynchronous | FileOptions.DeleteOnClose);
            await MeasurePerf.MeasureFile<string>(mm);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }
    }
}