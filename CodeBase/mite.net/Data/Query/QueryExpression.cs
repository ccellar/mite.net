//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Mite
{
    /// <summary>
    /// Query for data selection
    /// </summary>
    public class QueryExpression
    {
        /// <summary>
        /// Gets or sets the list of conditions.
        /// </summary>
        /// <value>The conditions.</value>
        public IList<Condition> Conditions { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryExpression"/> class.
        /// </summary>
        public QueryExpression()
        {
            Conditions = new List<Condition>();
        }
    }
}