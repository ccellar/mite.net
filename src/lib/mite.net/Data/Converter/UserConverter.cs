//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Xml;
using System.Globalization;

namespace Mite
{
    internal class UserConverter : IEntityConverter<User>
    {
        public string Convert(User item)
        {
            throw new NotSupportedException();
        }

        public User Convert(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            User user = new User
            {
                Id = int.Parse(xmlDocument.SelectSingleNode("/user/id").InnerText, CultureInfo.InvariantCulture),
                Archived = bool.Parse(xmlDocument.SelectSingleNode("/user/archived").InnerText),
                Createdon = DateTime.Parse(xmlDocument.SelectSingleNode("/user/created-at").InnerText, CultureInfo.InvariantCulture),
                Email = xmlDocument.SelectSingleNode("/user/email").InnerText,
                Name = xmlDocument.SelectSingleNode("/user/name").InnerText,
                Note = xmlDocument.SelectSingleNode("/user/note").InnerText,
                Role = (Role) Enum.Parse(typeof(Role),xmlDocument.SelectSingleNode("/user/role").InnerText,true),
                UpdatedOn = DateTime.Parse(xmlDocument.SelectSingleNode("/user/updated-at").InnerText, CultureInfo.InvariantCulture)
            };

            return user;
        }

        public IList<User> ConvertToList(string data)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(data);

            XmlNodeList nodeList = xmlDocument.SelectNodes(@"/users/user");

            IList<User> users = new List<User>(nodeList.Count);

            foreach (XmlNode node in nodeList)
            {
                users.Add(Convert(node.OuterXml));
            }

            return users;
        }
    }
}