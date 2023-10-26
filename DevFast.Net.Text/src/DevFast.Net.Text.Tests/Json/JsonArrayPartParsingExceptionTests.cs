namespace DevFast.Net.Text.Tests.Json
{
    [TestFixture]
    public class JsonArrayPartParsingExceptionTests
    {
        [Test]
        public void TestArrayPartParsingException_Default_Ctor_DoesNot_Set_Message_N_InnerException()
        {
            var e = new JsonArrayPartParsingException();
            Multiple(() =>
            {
                That(e.Message, Is.EqualTo("Exception of type 'DevFast.Net.Text.Json.JsonArrayPartParsingException' was thrown."));
                That(e.InnerException, Is.Null);
            });
        }

        [Test]
        public void TestArrayPartParsingException_MessageBased_Ctor_DoesNot_Set_InnerException()
        {
            var e = new JsonArrayPartParsingException("Bogus");
            Multiple(() =>
            {
                That(e.Message, Is.EqualTo("Bogus"));
                That(e.InnerException, Is.Null);
            });
        }

        [Test]
        public void TestArrayPartParsingException_Full_Ctor_Sets_Message_N_InnerException()
        {
            var i = new Exception();
            var e = new JsonArrayPartParsingException("Bogus", i);
            Multiple(() =>
            {
                That(e.Message, Is.EqualTo("Bogus"));
                That(ReferenceEquals(e.InnerException, i), Is.True);
            });
        }
    }
}