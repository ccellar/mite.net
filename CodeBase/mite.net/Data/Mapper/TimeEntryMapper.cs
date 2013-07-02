//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;

namespace Mite
{
    internal class TimeEntryMapper : WebMapper, IDataMapper<TimeEntry>
    {
        public IEntityConverter<TimeEntry> Converter { get; set; }

        public TimeEntry Create(TimeEntry item)
        {
            string result = WebAdapter.SendPostRequest("time_entries.xml", Converter.Convert(item));

            return Converter.Convert(result);
        }

        public TimeEntry Update(TimeEntry item)
        {
            string result = WebAdapter.SendPutRequest(string.Format(CultureInfo.InvariantCulture,"time_entries/{0}.xml", item.Id), Converter.Convert(item));

            if (string.IsNullOrEmpty(result.Trim()))
            {
                return item;
            }

            return Converter.Convert(result);
        }

        public void Delete(TimeEntry item)
        {
            WebAdapter.SendDeleteRequest(string.Format(CultureInfo.InvariantCulture,"time_entries/{0}.xml", item.Id));
        }

        public TimeEntry GetById(object id)
        {
            string result = WebAdapter.SendGetRequest(string.Format(CultureInfo.InvariantCulture,"time_entries/{0}.xml", id));

            return Converter.Convert(result);
        }

        public IList<TimeEntry> GetAll()
        {
            string result = WebAdapter.SendGetRequest("time_entries.xml");

            return Converter.ConvertToList(result);
        }

        public IList<string> CriteriaProperties {
            get
            {
                return new List<string>
                           {
                               "customer_id",
                               "project_id",
                               "service_id",
                               "user_id",
                               "billable",
                               "note",
                               "at",
                               "from", 
                               "to",
                               "locked"
                           };
            }
        }

        public IList<TimeEntry> GetByCriteria(QueryExpression queryExpression)
        {
            var query = new QueryTranslator(queryExpression).Translate();
            var result = WebAdapter.SendGetRequest(string.Format(CultureInfo.InvariantCulture, "time_entries.xml{0}", query));

            return Converter.ConvertToList(result);
        }
    }
}