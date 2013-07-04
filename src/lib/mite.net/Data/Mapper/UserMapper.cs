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
    internal class UserMapper : WebMapper, IDataMapper<User>
    {
        public IEntityConverter<User> Converter { get; set; }

        public virtual User Create(User item)
        {
            throw new NotSupportedException();
        }

        public virtual User Update(User item)
        {
            throw new NotSupportedException();
        }

        public virtual void Delete(User item)
        {
            throw new NotSupportedException();
        }

        public virtual User GetById(object id)
        {
            string result = WebAdapter.SendGetRequest(string.Format(CultureInfo.InvariantCulture,"users/{0}.xml", id));

            return Converter.Convert(result);
        }

        public IList<User> GetAll()
        {
            string result = WebAdapter.SendGetRequest("users.xml");

            return Converter.ConvertToList(result);
        }

        public IList<string> CriteriaProperties {
            get
            {
                return new List<string>();
            }
        }

        public IList<User> GetByCriteria(QueryExpression queryExpression)
        {
            throw new NotImplementedException();
        }
    }
}