using Mite;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace mite.Tests.Converter
{
    [TestFixture]
    public class UserConverterTests
    {
        [Test]
        public void User_Should_Be_Converted_From_Xml_String()
        {
            string input = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <user>
                                   <id type=""integer"">1</id>
                                   <name>Sebastian Munz</name>
                                   <email>sebastian@email.com</email>
                                   <note></note>
                                   <archived type=""boolean"">false</archived>
                                   <role>coworker</role>
                                   <language>de</language>
                                   <created-at type=""datetime"">2007-06-23T23:00:58+02:00</created-at>
                                   <updated-at type=""datetime"">2009-02-14T00:33:26+01:00</updated-at>
                                </user>
                                ";

            User user = new UserConverter().Convert(input);

            Assert.That(user.Role, Is.EqualTo(Role.coworker));
        }
    }
}