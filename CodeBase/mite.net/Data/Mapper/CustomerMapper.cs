//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;
using System.Globalization;

namespace Mite
{
    internal class CustomerMapper : WebMapper, IDataMapper<Customer>
    {
        public IEntityConverter<Customer> Converter { get; set; }

        public virtual Customer Create(Customer item)
        {
            string data = Converter.Convert(item);

            string result = WebAdapter.SendPostRequest("customers.xml", data);

            return Converter.Convert(result);
        }

        public virtual Customer Update(Customer item)
        {
            string data = Converter.Convert(item);

            string result = WebAdapter.SendPutRequest(string.Format(CultureInfo.InvariantCulture,"customers/{0}.xml", item.Id), data);

            if ( string.IsNullOrEmpty(result.Trim()) )
            {
                return item;
            }

            return Converter.Convert(result);
        }

        public virtual void Delete(Customer item)
        {
            WebAdapter.SendDeleteRequest(string.Format(CultureInfo.InvariantCulture,"customers/{0}.xml", item.Id));
        }

        public virtual Customer GetById(object id)
        {
            string response = WebAdapter.SendGetRequest(string.Format(CultureInfo.InvariantCulture,"customers/{0}.xml", id));

            return Converter.Convert(response);
        }

        public IList<Customer> GetAll()
        {
            string result = WebAdapter.SendGetRequest("customers.xml");

            return Converter.ConvertToList(result);
        }

        public IList<string> CriteriaProperties {
            get
            {
                return new List<string> { "name" };
            }
        }

        public IList<Customer> GetByCriteria(QueryExpression queryExpression)
        {
            string query = new QueryTranslator(queryExpression).Translate();
            string result = WebAdapter.SendGetRequest(string.Format(CultureInfo.InvariantCulture,"customers.xml{0}", query));

            return Converter.ConvertToList(result);
        }        
    }
}