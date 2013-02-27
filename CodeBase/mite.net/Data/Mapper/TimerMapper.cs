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
    internal class TimerMapper : WebMapper, IDataMapper<Timer>
    {
        public IEntityConverter<Timer> Converter { get; set; }

        public Timer Create(Timer item)
        {
            string result = WebAdapter.SendPutRequest(string.Format(CultureInfo.InvariantCulture,"tracker/{0}.xml",item.TimeEntry.Id), Converter.Convert(item));

            return Converter.Convert(result);
        }

        public Timer Update(Timer item)
        {
            throw new NotImplementedException();
        }

        public void Delete(Timer item)
        {
            string result = WebAdapter.SendDeleteRequest(string.Format(CultureInfo.InvariantCulture,"tracker/{0}.xml", item.TimeEntry.Id));


            //TODO return value?
            //return Converter.Convert(result);
        }

        public Timer GetById(object id)
        {
            throw new NotSupportedException();
        }

        public IList<Timer> GetAll()
        {
            string result = WebAdapter.SendGetRequest("tracker.xml");
           
            return Converter.ConvertToList(result);
        }

        public IList<string> CriteriaProperties
        {
            get
            {
                return new List<string>();
            }
        }

        public IList<Timer> GetByCriteria(QueryExpression queryExpression)
        {
            throw new NotSupportedException();
        }
    }
}