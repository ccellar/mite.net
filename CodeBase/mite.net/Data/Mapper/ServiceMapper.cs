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
    internal class ServiceMapper : WebMapper, IDataMapper<Service>
    {
        public IEntityConverter<Service> Converter { get; set; }

        public Service Create(Service item)
        {
            string result = WebAdapter.SendPostRequest("services.xml", Converter.Convert(item));

            return Converter.Convert(result);
        }

        public Service Update(Service item)
        {
            string result = WebAdapter.SendPutRequest(string.Format(CultureInfo.InvariantCulture,"services/{0}.xml", item.Id), Converter.Convert(item));

            if (string.IsNullOrEmpty(result.Trim()))
            {
                return item;
            }

            return Converter.Convert(result);
        }

        public void Delete(Service item)
        {
            WebAdapter.SendDeleteRequest(string.Format(CultureInfo.InvariantCulture,"services/{0}.xml", item.Id));
        }

        public Service GetById(object id)
        {
            string result = WebAdapter.SendGetRequest(string.Format(CultureInfo.InvariantCulture,"services/{0}.xml", id));

            return Converter.Convert(result);
        }

        public IList<Service> GetAll()
        {
            string result = WebAdapter.SendGetRequest("services.xml");

            return Converter.ConvertToList(result);
        }

        public IList<string> CriteriaProperties 
        {
            get
            {
                return new List<string>();
            }
        }

        public IList<Service> GetByCriteria(QueryExpression queryExpression)
        {
            throw new NotImplementedException();
        }
    }
}