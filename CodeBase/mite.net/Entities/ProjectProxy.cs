//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System.Diagnostics;
using System.Net;

namespace Mite
{
    /// <summary>
    /// Proxy for project class
    /// </summary>
    /// <remarks>
    /// Used for lazy loading of references
    /// </remarks>
    public class ProjectProxy : Project
    {
        private bool _customerLoaded;

        internal object CustomerId
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the customer of this project.
        /// </summary>
        /// <value>The customer.</value>
        public override Customer Customer
        {
            get
            {
                if ( !_customerLoaded )
                {
                    Trace.WriteLine("Loading customer", "Mapping");

                    IDataMapper<Customer> mapper = MiteDataMapperFactory.GetMapper<Customer>();

                    try
                    {
                        base.Customer = mapper.GetById(CustomerId);
                    }
                    catch (WebException webException)
                    {
                        HttpWebResponse response = (HttpWebResponse) webException.Response;
                        
                        if (response.StatusCode == HttpStatusCode.NotFound)
                        {
                            base.Customer = null;
                        }else

                        throw;
                    }

                    _customerLoaded = true;
                }

                return base.Customer;
            }
            set
            {
                base.Customer = value;
            }
        }

        /// <summary>
        /// Compares this instance with the object provided in the parameter
        /// </summary>
        /// <param name="obj">The object for comparism.</param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if ( this == obj )
            {
                return true;
            }

            Project project = obj as Project;

            if ( project == null )
            {
                return false;
            }

            return Id == project.Id;
        }

        /// <summary>
        /// Serves as a hash function for this class.
        /// </summary>
        /// <returns>
        /// A hash code for this class.
        /// </returns>
        public override int GetHashCode()
        {
            int hash = Id * 2009;

            return hash;
        }
    }
}