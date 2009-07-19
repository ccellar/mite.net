using System;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Mite.Tests
{
    [TestFixture]
    [Category("Configuration")]
    public class ConfigurationTests
    {
        [Test]
        public void ValidateApiKeyConstructor()
        {
            MiteConfiguration miteConfiguration = new MiteConfiguration(new Uri("http://test.de"),"test");

            Assert.That(miteConfiguration.ApiKey, Is.EqualTo("test"));
            Assert.That(miteConfiguration.Domain, Is.EqualTo(new Uri("http://test.de")));
        }

        [Test]
        public void ValidateUserAndPasswordConstructor()
        {
            MiteConfiguration miteConfiguration = new MiteConfiguration(new Uri("http://test.de"), "test", "secret");

            Assert.That(miteConfiguration.Domain, Is.EqualTo(new Uri("http://test.de")));
            Assert.That(miteConfiguration.User, Is.EqualTo("test"));
            Assert.That(miteConfiguration.Password, Is.EqualTo("secret"));
        }

        [Test]
        public void ValidUriSchemasShouldBeAccepted()
        {
            MiteConfiguration miteConfiguration = new MiteConfiguration(new Uri("https://test.mite.yo.lk"),"wer");
        }

        [Test]
        [ExpectedException(typeof(ArgumentException))]
        public void InvalidUriSchemaShouldNotBeAccepted()
        {
            MiteConfiguration miteConfiguration = new MiteConfiguration(new Uri("ftp://test.de"),"4545");
        }
    }
}