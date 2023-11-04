namespace DevFast.Net.Text.Tests.Json
{
    [TestFixture]
    public class JsonTypeTests
    {
        [Test]
        public void JsonType_Values_Are_Consistent()
        {
            var typeValues = Enum.GetValues(typeof(JsonType));
            Multiple(() =>
            {
                NotNull(typeValues);
                That(typeValues.Length, Is.EqualTo(7));
                var pos = 0;
                That(typeValues.GetValue(pos++)!.ToString(), Is.EqualTo("Nothing"));
                That(typeValues.GetValue(pos++)!.ToString(), Is.EqualTo("Object"));
                That(typeValues.GetValue(pos++)!.ToString(), Is.EqualTo("Array"));
                That(typeValues.GetValue(pos++)!.ToString(), Is.EqualTo("Number"));
                That(typeValues.GetValue(pos++)!.ToString(), Is.EqualTo("String"));
                That(typeValues.GetValue(pos++)!.ToString(), Is.EqualTo("Bool"));
                That(typeValues.GetValue(pos)!.ToString(), Is.EqualTo("Null"));
            });
        }
    }
}