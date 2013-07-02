using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Mite.Tests
{
    [TestFixture]
    public class MiteDataContextTests
    {
        [Test]
        public void ConstructorShouldSetConfiguration()
        {
            MiteConfiguration miteConfiguration = new MiteConfiguration(new Uri("https://test"),"sdfsdf" );

            IDataContext miteDataContext = new MiteDataContext(miteConfiguration);

            Assert.That(miteConfiguration, Is.EqualTo(MiteConfiguration.CurrentConfiguration));
        }

        [Test]
        [Ignore("app.config is not used by external nant runner")]
        public void DefaultConstructorShouldReadConfiguration()
        {
            MiteConfiguration.CurrentConfiguration = null;

            IDataContext context = new MiteDataContext();

            Assert.IsNotNull(MiteConfiguration.CurrentConfiguration);
        }
    }
}