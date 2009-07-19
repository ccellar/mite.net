using System.Globalization;
using System.Xml;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace Mite.Tests
{
    [TestFixture]
    public class ProjectConverterTests
    {
        [Test]
        public void ProjectShouldBeConvertedToXml()
        {
            Project project = new Project
            {
                Archived = false,
                Budget = 1000,
                Customer = new Customer
                {
                    Name = "test"
                },
                Id = 2,
                Name = "Test project"
            };

            string xml = new ProjectConverter().Convert(project);

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(xml);

            string value = xmlDocument.SelectSingleNode("/project/id").InnerText;

            Assert.That(value, Is.EqualTo(project.Id.ToString(CultureInfo.InvariantCulture)));
        }
    }
}