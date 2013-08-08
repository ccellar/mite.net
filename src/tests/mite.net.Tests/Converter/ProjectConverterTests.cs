using System.Globalization;
using System.Xml;
using Mite;
using NUnit.Framework;


namespace mite.Tests.Converter
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

            string value = xmlDocument.SelectSingleNode("/project/name").InnerText;

            Assert.That(value, Is.EqualTo(project.Name.ToString(CultureInfo.InvariantCulture)));
        }

        [Test]
        public void Time_Budget_Type_Should_Be_Mapped_From_Xml()
        {
            string input = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                        <project>
                           <id type=""integer"">123</id>
                           <name>Website Konzeption</name>
                           <note></note>
                           <budget type=""integer"">0</budget>
                           <budget-type>minutes</budget-type>
                           <archived type=""boolean"">false</archived>
                           <customer-id type=""integer"">2</customer-id>
                           <customer-name>LilaLaune GmbH</customer-name>
                           <updated-at type=""datetime"">2007-12-13T12:12:00+01:00</updated-at>
                           <created-at type=""datetime"">2007-12-13T12:12:00+01:00</created-at>
                        </project>
                        ";

            ProjectConverter projectConverter = new ProjectConverter();
            Project project = projectConverter.Convert(input);

            Assert.That(project.BudgetType, Is.EqualTo(BudgetType.minutes));
        }

        [Test]
        public void Money_Budget_Type_Should_Be_Mapped_From_Xml()
        {
            string input = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                        <project>
                           <id type=""integer"">123</id>
                           <name>Website Konzeption</name>
                           <note></note>
                           <budget type=""integer"">0</budget>
                           <budget-type>cents</budget-type>
                           <archived type=""boolean"">false</archived>
                           <customer-id type=""integer"">2</customer-id>
                           <customer-name>LilaLaune GmbH</customer-name>
                           <updated-at type=""datetime"">2007-12-13T12:12:00+01:00</updated-at>
                           <created-at type=""datetime"">2007-12-13T12:12:00+01:00</created-at>
                        </project>
                        ";

            ProjectConverter projectConverter = new ProjectConverter();
            Project project = projectConverter.Convert(input);

            Assert.That(project.BudgetType, Is.EqualTo(BudgetType.cents));
        }

        [Test]
        public void Money_Budget_Type_Should_Be_Written_To_Xml()
        {
            Project project = new Project();
           // project.Name = "test";
            project.BudgetType = BudgetType.cents;

            ProjectConverter projectConverter = new ProjectConverter();
            string xml = projectConverter.Convert(project);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(xml);

            XmlNode value = xmlDocument.SelectSingleNode("/project/budget-type");

            Assert.That(value.InnerText, Is.EqualTo("cents"));
        }
    }
}