//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text;
using System.Xml;

namespace Mite
{
    internal class ProjectConverter : IEntityConverter<Project>
    {
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public string Convert(Project item)
        {
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriter xmlWriter = XmlWriter.Create(stringBuilder);

            xmlWriter.WriteStartElement("project");

            xmlWriter.WriteElementString("name", item.Name);
            xmlWriter.WriteElementString("note", item.Note);

            xmlWriter.WriteElementString("budget", item.Budget.ToString(CultureInfo.InvariantCulture));

            xmlWriter.WriteElementString("archived", item.Archived.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());

            if ( item.Customer != null )
            {
                xmlWriter.WriteElementString("customer-id", item.Customer.Id.ToString(CultureInfo.InvariantCulture));
            }

            if ( item.Id != 0 )
            {
                xmlWriter.WriteElementString("id", item.Id.ToString(CultureInfo.InvariantCulture));
            }

            if ( item.CreatedOn != DateTime.MinValue )
            {
                xmlWriter.WriteElementString("created-at", item.CreatedOn.ToString(CultureInfo.InvariantCulture));
            }

            if ( item.UpdatedOn != DateTime.MinValue )
            {
                xmlWriter.WriteElementString("updated-at", item.UpdatedOn.ToString(CultureInfo.InvariantCulture));
            }

            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            return stringBuilder.ToString();
        }

        public Project Convert(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            ProjectProxy project = new ProjectProxy
            {
                Id = int.Parse(xmlDocument.SelectSingleNode("/project/id").InnerText, CultureInfo.InvariantCulture),
                Archived = bool.Parse(xmlDocument.SelectSingleNode("/project/archived").InnerText),
                Budget = int.Parse(xmlDocument.SelectSingleNode("/project/budget").InnerText, CultureInfo.InvariantCulture),
                CreatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/project/created-at").InnerText, CultureInfo.InvariantCulture),
                Name = xmlDocument.SelectSingleNode("/project/name").InnerText,
                Note = xmlDocument.SelectSingleNode("/project/note").InnerText,
                UpdatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/project/updated-at").InnerText, CultureInfo.InvariantCulture),
                CustomerId = xmlDocument.SelectSingleNode("/project/customer-id").InnerText
            };

            return project;
        }

        public IList<Project> ConvertToList(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            XmlNodeList nodeList = xmlDocument.SelectNodes(@"/projects/project");

            IList<Project> projects = new List<Project>(nodeList.Count);

            foreach ( XmlNode node in nodeList )
            {
                projects.Add(Convert(node.OuterXml));
            }

            return projects;
        }
    }
}