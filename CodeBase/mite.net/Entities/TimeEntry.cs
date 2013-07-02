//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace Mite
{
    /// <summary>
    /// A time entry
    /// </summary>
    public class TimeEntry : DomainObject
    {
        /// <summary>
        /// Gets or sets the date of the time entry.
        /// </summary>
        /// <value>The date.</value>
        public DateTime Date
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the amount of time in minutes.
        /// </summary>
        /// <value>The duration minutes.</value>
        public int Minutes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the revenue of this timespan.
        /// </summary>
        /// <value>The revenue.</value>
        public float Revenue
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
        /// Gets or sets the project.
        /// </summary>
        /// <value>The project.</value>
        public virtual Project Project
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the user.
        /// </summary>
        /// <value>The user.</value>
        public virtual User User
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the service.
        /// </summary>
        /// <value>The service.</value>
        public virtual Service Service
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this item was created.
        /// </summary>
        /// <value>The date of creation.</value>
        public DateTime CreatedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this item was updated.
        /// </summary>
        /// <value>The date of last update.</value>
        public DateTime UpdatedOn
        {
            get;
            set;
        }

        public bool Locked { get; set; }
    }
}