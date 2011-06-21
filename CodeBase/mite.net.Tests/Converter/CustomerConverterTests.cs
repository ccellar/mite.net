using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using Mite;
using NUnit.Framework;
using NUnit.Framework.SyntaxHelpers;

namespace mite.Tests.Converter
{
    [TestFixture]
    public class CustomerConverterTests
    {
        [Test]
        public void CustomerShouldBeConvertedCorrect()
        {
            Customer customer = new Customer
                                    {
                Archived = false,
                CreatedOn = DateTime.Now,
                Id = 1,
                Name = "ConstructorShouldSetConfiguration",
                UpdatedOn = DateTime.Now
            };

            XmlDocument xmlDocument = new XmlDocument();

            xmlDocument.LoadXml(new CustomerConverter().Convert(customer));

            string value = xmlDocument.SelectSingleNode("/customer/id").InnerText;

            Assert.That(value, Is.EqualTo(customer.Id.ToString(CultureInfo.InvariantCulture)));
        }

        [Test]
        public void CustomerShouldBeLoadedFromXml()
        {
            string input =
                @"<customer>
                              <created-at type=""datetime"">2009-06-26T18:36:11+02:00</created-at>
                              <id type=""integer"">52917</id>
                              <name>Test</name>
                              <note nil=""true""></note>
                              <updated-at type=""datetime"">2009-06-26T18:36:11+02:00</updated-at>
                              <archived type=""boolean"">false</archived>
                            </customer>";

            Customer customer = new CustomerConverter().Convert(input);

            Assert.That(customer.Id, Is.EqualTo(52917));
            Assert.That(customer.Archived, Is.EqualTo(false));
            Assert.That(customer.Name, Is.EqualTo("Test"));                
        }

        [Test]
        public void CustomerListShouldBeLoadedFromXml()
        {
            string input =
           @"<customers><customer>
                              <created-at type=""datetime"">2009-06-26T18:36:11+02:00</created-at>
                              <id type=""integer"">52917</id>
                              <name>Test</name>
                              <note nil=""true""></note>
                              <updated-at type=""datetime"">2009-06-26T18:36:11+02:00</updated-at>
                              <archived type=""boolean"">false</archived>
                            </customer>
                            <customer>
                              <created-at type=""datetime"">2009-06-26T18:36:11+02:00</created-at>
                              <id type=""integer"">52917</id>
                              <name>Test</name>
                              <note nil=""true""></note>
                              <updated-at type=""datetime"">2009-06-26T18:36:11+02:00</updated-at>
                              <archived type=""boolean"">false</archived>
                            </customer>
             </customers>";

            IList<Customer> customers = new CustomerConverter().ConvertToList(input);

            Assert.That(customers.Count, Is.EqualTo(2));
        }
    }
}