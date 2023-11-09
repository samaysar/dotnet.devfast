namespace DevFast.Net.Text.PerfRunner
{
    public class A
    {
        public object? No { get; set; } = null;
        public bool Ba { get; set; } = true;
        public decimal D { get; set; } = 123456789.12345m;
        public double Dd { get; set; } = 1.23456789e15;
        public long L { get; set; } = long.MaxValue;
        public int I { get; set; } = int.MaxValue;
        public string Ss { get; set; } = MeasurePerf.ShortStr;
        public string Bs { get; set; } = MeasurePerf.LongStr;
        public List<string> Ls { get; set; } = new() { "1", "2", MeasurePerf.ShortStr, MeasurePerf.LongStr };
        public List<B> Lb { get; set; } = new() { new B(), new B(), new B() };
        public List<C> Lc { get; set; } = new() { new C(), new C(), new C() };
        public B Cb { get; set; } = new B();
        public C Cc { get; set; } = new C();
        public DateTime Dt { get; set; } = DateTime.UtcNow;
    }

    public class B
    {
        public object? No { get; set; } = null;
        public bool Bb { get; set; } = true;
        public double Dd { get; set; } = 1.23456789e15;
        public long L { get; set; } = long.MaxValue;
        public int I { get; set; } = int.MaxValue;
        public string Ss { get; set; } = MeasurePerf.ShortStr;
        public DateTime Dt { get; set; } = DateTime.UtcNow;
    }

    public class C
    {
        public object? No { get; set; } = null;
        public bool Bc { get; set; } = true;
        public string Ss { get; set; } = MeasurePerf.LongStr;
        public List<B> Lb { get; set; } = new() { new B(), new B(), new B() };
        public B Cb { get; set; } = new B();
        public DateTime Dt { get; set; } = DateTime.UtcNow;
    }
}