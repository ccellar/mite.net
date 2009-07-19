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

        public IList<TimeEntry> GetByCriteria(QueryExpression queryExpression)
        {
            throw new NotImplementedException();
        }
    }
}