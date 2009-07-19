using NUnit.Framework;

namespace Mite.Tests
{
    [TestFixture]
    public class MiteExceptionTests
    {
        [Test]
        public void ConstructorShouldInitializeErrorsList()
        {
            MiteException miteException = new MiteException();

            Assert.IsNotNull(miteException.Errors);
        }
    }
}