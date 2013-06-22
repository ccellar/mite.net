//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;

namespace Mite
{
    internal class TimeEntryConverter : IEntityConverter<TimeEntry>
    {
        public string Convert(TimeEntry item)
        {

            MemoryStream memoryStream = new MemoryStream();

            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
            {
                Encoding = new UTF8Encoding(false),
                ConformanceLevel = ConformanceLevel.Document,
                Indent = true
            };

            XmlWriter xmlWriter = XmlWriter.Create(memoryStream, xmlWriterSettings);

            xmlWriter.WriteStartElement("time-entry");

            xmlWriter.WriteElementString("note", item.Note);
            xmlWriter.WriteElementString("revenue", item.Revenue.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteElementString("minutes", item.Minutes.ToString(CultureInfo.InvariantCulture));
            xmlWriter.WriteElementString("locked", item.Locked.ToString(CultureInfo.InvariantCulture));

            if ( item.User != null )
            {
                xmlWriter.WriteElementString("user-id", item.User.Id.ToString(CultureInfo.InvariantCulture));
            }

            if (item.Project != null)
            {
                xmlWriter.WriteElementString("project-id", item.Project.Id.ToString(CultureInfo.InvariantCulture));
            }

            if ( item.Service != null )
            {
                xmlWriter.WriteElementString("service-id", item.Service.Id.ToString(CultureInfo.InvariantCulture));
            }

            if (item.Date != DateTime.MinValue)
            {
                xmlWriter.WriteElementString("date-at", item.Date.ToString(CultureInfo.InvariantCulture));
            }

            xmlWriter.WriteEndElement();

            xmlWriter.Close();

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        public TimeEntry Convert(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            TimeEntryProxy timeEntry = new TimeEntryProxy
            {
                Id = int.Parse(xmlDocument.SelectSingleNode("/time-entry/id").InnerText, CultureInfo.InvariantCulture),
                CreatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/time-entry/created-at").InnerText, CultureInfo.InvariantCulture),
                Note = xmlDocument.SelectSingleNode("/time-entry/note").InnerText,
                UpdatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/time-entry/updated-at").InnerText, CultureInfo.InvariantCulture),
                ProjectId = xmlDocument.SelectSingleNode("/time-entry/project-id").InnerText,
                ServiceId = xmlDocument.SelectSingleNode("/time-entry/service-id").InnerText,
                UserId = xmlDocument.SelectSingleNode("/time-entry/user-id").InnerText,
                Date = DateTime.Parse(xmlDocument.SelectSingleNode("/time-entry/date-at").InnerText, CultureInfo.InvariantCulture),
                Locked = bool.Parse(xmlDocument.SelectSingleNode("/time-entry/locked").InnerText)
            };

            float revenue;

            float.TryParse(xmlDocument.SelectSingleNode("/time-entry/revenue").InnerText, out revenue);

            timeEntry.Revenue = revenue;

            int minutes;

            int.TryParse(xmlDocument.SelectSingleNode("/time-entry/minutes").InnerText, out minutes);

            timeEntry.Minutes = minutes;

            return timeEntry;
        }

        public IList<TimeEntry> ConvertToList(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            XmlNodeList nodeList = xmlDocument.SelectNodes(@"/time-entries/time-entry");

            IList<TimeEntry> timeEntries = new List<TimeEntry>(nodeList.Count);

            foreach ( XmlNode node in nodeList )
            {
                timeEntries.Add(Convert(node.OuterXml));
            }

            return timeEntries;
        }
    }
}