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
    internal class ProjectConverter : IEntityConverter<Project>
    {
        [SuppressMessage("Microsoft.Globalization", "CA1308:NormalizeStringsToUppercase")]
        public string Convert(Project item)
        {
            MemoryStream memoryStream = new MemoryStream();

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                ConformanceLevel = ConformanceLevel.Document,
                Indent = true
            };

            XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);

            xmlWriter.WriteStartElement("project");

            xmlWriter.WriteElementString("name", item.Name);
            
            if (!string.IsNullOrEmpty(item.Note))
            {
                xmlWriter.WriteElementString("note", item.Note); 
            }

            xmlWriter.WriteElementString("budget", item.Budget.ToString(CultureInfo.InvariantCulture));

            xmlWriter.WriteElementString("archived", item.Archived.ToString(CultureInfo.InvariantCulture).ToLowerInvariant());

            if ( item.Customer != null )
            {
                xmlWriter.WriteElementString("customer-id", item.Customer.Id.ToString(CultureInfo.InvariantCulture));
            }

            xmlWriter.WriteElementString("budget-type", item.BudgetType.ToString());

            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        public Project Convert(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            ProjectProxy project = new ProjectProxy();

            project.Id = int.Parse(xmlDocument.SelectSingleNode("/project/id").InnerText, CultureInfo.InvariantCulture);
            project.Archived = bool.Parse(xmlDocument.SelectSingleNode("/project/archived").InnerText);

            // sometimes the budget is "" (empty string), so lets make sure it can be parsed
            // I think it depends on a users access rights in mite what kind of budget information is provided
            var budget = 0;
            int.TryParse(xmlDocument.SelectSingleNode("/project/budget").InnerText, NumberStyles.Any, CultureInfo.InvariantCulture, out budget);
            project.Budget = budget;

            project.CreatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/project/created-at").InnerText, CultureInfo.InvariantCulture);
            project.Note = xmlDocument.SelectSingleNode("/project/note").InnerText;
            project.UpdatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/project/updated-at").InnerText, CultureInfo.InvariantCulture);
            project.CustomerId = xmlDocument.SelectSingleNode("/project/customer-id").InnerText;
            project.Name = xmlDocument.SelectSingleNode("/project/name").InnerText;

            string budgetType = xmlDocument.SelectSingleNode("/project/budget-type").InnerText;
            if (!string.IsNullOrEmpty(budgetType))
            {
                project.BudgetType = (BudgetType) Enum.Parse(typeof (BudgetType), budgetType, true);
            }

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