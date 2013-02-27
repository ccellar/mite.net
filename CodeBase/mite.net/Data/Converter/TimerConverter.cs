//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace Mite
{
    internal class TimerConverter : IEntityConverter<Timer>
    {
        public string Convert(Timer item)
        {
            return string.Empty;
        }

        public Timer Convert(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            Timer timer = new Timer();

            if (xmlDocument.SelectSingleNode("/tracker/tracking-time-entry") != null)
            {
                timer.RunningTimer = new RunningTimer
                {
                    Start =
                        DateTime.Parse(
                        xmlDocument.SelectSingleNode("/tracker/tracking-time-entry/since").
                            InnerText, CultureInfo.InvariantCulture),
                    Id =
                        int.Parse(
                        xmlDocument.SelectSingleNode("/tracker/tracking-time-entry/id").
                            InnerText, CultureInfo.InvariantCulture),
                    Minutes =
                        int.Parse(
                        xmlDocument.SelectSingleNode("/tracker/tracking-time-entry/minutes").
                            InnerText, CultureInfo.InvariantCulture)
                };
            }
            if (xmlDocument.SelectSingleNode("/tracker/stopped-time-entry") != null)
            {
                timer.StoppedTimer = new StoppedTimer
                {
                    Id = int.Parse(
                        xmlDocument.SelectSingleNode("/tracker/stopped-time-entry/id").
                            InnerText, CultureInfo.InvariantCulture),
                    Minutes = int.Parse(
                        xmlDocument.SelectSingleNode("/tracker/stopped-time-entry/minutes").
                            InnerText, CultureInfo.InvariantCulture)
                };
            }

            return timer;
        }

        public IList<Timer> ConvertToList(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            XmlNodeList nodeList = xmlDocument.SelectNodes(@"/tracker");

            if (nodeList != null)
            {

                IList<Timer> timers = new List<Timer>(nodeList.Count);

                foreach (XmlNode node in nodeList)
                {
                    timers.Add(Convert(node.OuterXml));
                }

                return timers;
            }

            return null;
        }
    }
}