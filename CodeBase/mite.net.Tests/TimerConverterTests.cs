using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Mite.Tests
{
    [TestFixture]
    public class TimerConverterTests
    {
        [Test]
        public void CreateTimerFromXml()
        {
            IEntityConverter<Timer> converter = new TimerConverter();

            string data = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <tracker>
              <tracking-time-entry>
                <since type=""datetime"">2009-06-30T21:01:51+02:00</since>
                <minutes type=""integer"">0</minutes>
                <id type=""integer"">1895567</id>
              </tracking-time-entry>
              <stopped-time-entry>
                <minutes type=""integer"">1</minutes>
                <id type=""integer"">1895560</id>
              </stopped-time-entry>
            </tracker>";

            Timer timer = converter.Convert(data);

            Assert.That(timer.StoppedTimer.Minutes, Is.EqualTo(1));
        }
    }
}