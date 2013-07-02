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
    /// Project
    /// </summary>
    [DebuggerDisplay("{Name}")]
    public class Project : DomainObject
    {
        ///<summary>
        /// Gets or sets the type of budget.
        ///</summary>
        /// <value>The budget type.</value>
        public BudgetType BudgetType
        {
            get; 
            set;
        }

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
        /// Gets or sets the budget.
        /// </summary>
        /// <value>The budget.</value>
        public int Budget
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="Project"/> is archived.
        /// </summary>
        /// <value><c>true</c> if archived; otherwise, <c>false</c>.</value>
        public bool Archived
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the customer.
        /// </summary>
        /// <value>The customer.</value>
        public virtual Customer Customer
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this <see cref="Project"/> was created.
        /// </summary>
        /// <value>The created on.</value>
        public DateTime CreatedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the date on which this <see cref="Project"/> was updated.
        /// </summary>
        /// <value>The updated on.</value>
        public DateTime UpdatedOn
        {
            get;
            set;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="Project"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="Project"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="Project"/>; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (this == obj)
            {
                return true;
            }

            Project p = obj as Project;

            if (p != null)
            {
                return p.Id == Id;
            }

            ProjectProxy proxy = obj as ProjectProxy;

            if (proxy != null)
            {
                return proxy.Id == Id;
            }

            return false;
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="Project"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int id = Id*1000;

            return id;
        }
    }
}