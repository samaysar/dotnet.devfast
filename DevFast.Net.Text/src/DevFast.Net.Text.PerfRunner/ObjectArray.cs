namespace DevFast.Net.Text.PerfRunner
{
    public static class ObjectArray
    {
        public static async Task RunInMemoryAsync()
        {
            await MemoryBigArrayOfSimpleObject();
            await MemoryBigArrayOfSimpleExpandoObject();
            await MemoryBigArrayOfAvgComplexObject();
            await MemoryBigArrayOfAvgComplexExpandoObject();
            await MemoryBigArrayOfComplexObject();
            await MemoryBigArrayOfComplexExpandoObject();
        }

        public static async Task RunFromFileAsync()
        {
            throw new NotImplementedException();
        }

        static async Task MemoryBigArrayOfSimpleObject()
        {
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(new B(), Newtonsoft.Json.Formatting.Indented));
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} SimpleObject --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new B(), MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<B>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task MemoryBigArrayOfSimpleExpandoObject()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} SimpleExpandoObject --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new B(), MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<ExpandoObject>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task MemoryBigArrayOfAvgComplexObject()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} AvgComplexObject --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new C(), MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<C>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task MemoryBigArrayOfAvgComplexExpandoObject()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} AvgComplexExpandoObject --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new C(), MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<ExpandoObject>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task MemoryBigArrayOfComplexObject()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} ComplexObject --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new A(), MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<A>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }

        static async Task MemoryBigArrayOfComplexExpandoObject()
        {
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync($"-- IN-Memory Array of {MeasurePerf.TotalElements} ComplexExpandoObject --");
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await using var m = new MemoryStream();
            await Enumerable.Repeat(new A(), MeasurePerf.TotalElements).PushJson().AndWriteStreamAsync(m);
            await MeasurePerf.MeasureInMemory<ExpandoObject>(m);
            await Console.Out.WriteLineAsync("----------------------------------------------------");
            await Console.Out.WriteLineAsync();
        }
    }
}