using System;
using Mite;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace mite.Tests.Converter
{
    [TestFixture]
    public class TimeEntryConverterTests
    {
        [Test]
        public void TimeEntry_Should_Be_Converted_From_Xml_String()
        {
            string input = @"<?xml version=""1.0"" encoding=""UTF-8""?>
                                <time-entry>
                                   <id type=""integer"">5</id>
                                   <date-at type=""date"">2009-2-13</date-at>
                                   <minutes type=""integer"">185</minutes>
                                   <revenue type=""float"" nil=""true""></revenue>
                                   <billable type=""boolean"">true</billable>
                                   <note></note>
                                   <user-id type=""integer"">2</user-id>
                                   <user-name>Fridolin Fremd</user-name>
                                   <project-id type=""integer"">3</project-id>
                                   <project-name>API 2.0</project-name>
                                   <service-id type=""integer"">2</service-id>
                                   <service-name>Dokumentation</service-name>
                                   <customer-id type=""integer"">13</customer-id>
                                   <customer-name>König</customer-name>
                                   <locked type=""boolean"">false</locked>
                                   <created-at type=""datetime"">2009-02-11T18:54:45+01:00</created-at>
                                   <updated-at type=""datetime"">2009-02-11T18:54:45+01:00</updated-at>
                                </time-entry>";

            var timeEntry = new TimeEntryConverter().Convert(input);

            Assert.That(timeEntry, Is.InstanceOfType(typeof(TimeEntry)));
            Assert.AreEqual(timeEntry.Date, new DateTime(2009, 2, 13));
        }

        [Test]
        public void TimeEntry_Should_Be_Converted_Into_Xml_String()
        {
            //Todo create full test

            var timeEntry = new TimeEntry
            {
                Project = new Project { Id = 1 },
                CreatedOn = DateTime.UtcNow,
                Note = "Test",
                Revenue = 100,
                Minutes = 200,
                Date = new DateTime(2013,12,3,0,0,0,DateTimeKind.Utc)
            };

            var result = new TimeEntryConverter().Convert(timeEntry);

            Assert.IsTrue(result.Contains("project-id"));
            Assert.IsTrue(result.Contains(@"<revenue>100</revenue>"));
            Assert.IsTrue(result.Contains(@"<minutes>200</minutes>"));
            Assert.IsTrue(result.Contains(@"<date-at>2013-12-3</date-at>"));
        }
    }
}