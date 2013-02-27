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
    /// A user of mite
    /// </summary>
    [DebuggerDisplay("Name: {Name}, Email: {Email} ")]
    public class User : DomainObject
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
        /// Gets or sets the email.
        /// </summary>
        /// <value>The email.</value>
        public string Email
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
        /// Gets or sets a value indicating whether this <see cref="User"/> is archived.
        /// </summary>
        /// <value><c>true</c> if archived; otherwise, <c>false</c>.</value>
        public bool Archived
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this <see cref="User"/> was created.
        /// </summary>
        /// <value>The createdon.</value>
        public DateTime Createdon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this <see cref="User"/> was updated. 
        /// </summary>
        /// <value>The updated on.</value>
        public DateTime UpdatedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the role of the user.
        /// </summary>
        /// <value>The role.</value>
        public Role Role { get; set; }

    }
}