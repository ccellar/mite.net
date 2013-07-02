//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Mite
{
    /// <summary>
    /// Service
    /// </summary>
    public class Service : DomainObject
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
        /// Gets or sets a value indicating whether this <see cref="Service"/> is billable.
        /// </summary>
        /// <value><c>true</c> if billable; otherwise, <c>false</c>.</value>
        public bool Billable
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets the hourly rate.
        /// </summary>
        /// <value>The hourly rate.</value>
        public int HourlyRate
        {
            get;
            set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Service"/> is archived.
        /// </summary>
        /// <value><c>true</c> if archived; otherwise, <c>false</c>.</value>
        public bool Archived
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this <see cref="Service"/>  was created.
        /// </summary>
        /// <value>The created on.</value>
        public DateTime CreatedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this <see cref="Service"/> was updated.
        /// </summary>
        /// <value>The modified on.</value>
        public DateTime UpdatedOn
        {
            get;
            set;
        }
    }
}