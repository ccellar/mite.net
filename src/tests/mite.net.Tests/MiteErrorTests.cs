using NUnit.Framework;

namespace Mite.Tests
{
    [TestFixture]
    public class MiteErrorTests
    {
        [Test]
        public void ToStringShouldReturnMessage()
        {
            string message = "fooBar";
            MiteError miteError = new MiteError(message);

            Assert.That(message, Is.EqualTo(miteError.ToString()));
        }
    }
}