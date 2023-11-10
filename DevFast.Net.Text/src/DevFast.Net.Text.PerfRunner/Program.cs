namespace DevFast.Net.Text.PerfRunner
{
    internal static class Program
    {
        private static async Task Main(string[] args)
        {
#if DEBUG
            await Console.Out.WriteLineAsync("Run this project in RELEASE mode! Press ENTER to quit...");
#else
            try
            {
                await RunAsync();
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(e.ToString());
            }
            finally
            {
                await Console.Out.WriteLineAsync("Press ENTER to quit...");
            }
#endif
            await Console.In.ReadLineAsync();
        }

        private static async Task RunAsync()
        {
            //await SimpleArray.RunInMemoryAsync();
            //await ObjectArray.RunInMemoryAsync();
            //await ArrayOfArray.RunInMemoryAsync();
            await SimpleArray.RunFromFileAsync();
            //await ObjectArray.RunFromFileAsync();
            //await ArrayOfArray.RunFromFileAsync();
        }
    }
}