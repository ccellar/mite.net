//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Diagnostics;

namespace Mite
{
    /// <summary>
    /// A customer
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Customer : DomainObject
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the note.
        /// </summary>
        /// <value>The note.</value>
        public string Note
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Customer"/> is archived.
        /// </summary>
        /// <value><c>true</c> if archived; otherwise, <c>false</c>.</value>
        public bool Archived
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the date on which this <see cref="Customer"/> was created
        /// </summary>
        /// <value>The created on.</value>
        public DateTime CreatedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this <see cref="Customer"/> was updated
        /// </summary>
        /// <value>The updated on.</value>
        public DateTime UpdatedOn
        {
            get;
            set;
        }
    }
}