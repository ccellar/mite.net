using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

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