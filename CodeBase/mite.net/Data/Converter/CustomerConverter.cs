//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace Mite
{
    internal class CustomerConverter : IEntityConverter<Customer>
    {
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public string Convert(Customer item)
        {
            MemoryStream memoryStream = new MemoryStream();

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                ConformanceLevel = ConformanceLevel.Document,
                Indent = true
            };

            XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);

            xmlWriter.WriteStartElement("customer");

            xmlWriter.WriteElementString("name", item.Name);
            xmlWriter.WriteElementString("note", item.Note);

            xmlWriter.WriteElementString("archived", item.Archived.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());

            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        public Customer Convert(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            Customer customer = new Customer
            {
                Id = int.Parse(xmlDocument.SelectSingleNode("/customer/id").InnerText, CultureInfo.InvariantCulture),
                Name = xmlDocument.SelectSingleNode("/customer/name").InnerText,
                Note = xmlDocument.SelectSingleNode("/customer/note").InnerText,
                Archived = bool.Parse(xmlDocument.SelectSingleNode("/customer/archived").InnerText),
                CreatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/customer/created-at").InnerText, CultureInfo.InvariantCulture),
                UpdatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/customer/updated-at").InnerText, CultureInfo.InvariantCulture)
            };

            return customer;
        }

        public IList<Customer> ConvertToList(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            XmlNodeList nodeList = xmlDocument.SelectNodes(@"/customers/customer");

            IList<Customer> customers = new List<Customer>(nodeList.Count);

            foreach (XmlNode node in nodeList)
            {
                customers.Add(Convert(node.OuterXml));
            }

            return customers;
        }
    }
}