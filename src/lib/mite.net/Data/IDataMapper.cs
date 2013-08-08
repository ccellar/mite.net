//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace Mite
{
    /// <summary>
    /// Defines generic interface for data mapping
    /// </summary>
    /// <typeparam name="T">Type which should be mapped</typeparam>
    public interface IDataMapper<T> where T : class , new ()
    {
        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The created item.</returns>
        T Create(T item);

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>The updated item.</returns>
        T Update(T item);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Delete(T item);

        /// <summary>
        /// Returns the item with the specified id
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>The requested item</returns>
        T GetById(object id);

        /// <summary>
        /// Returns all items of the type
        /// </summary>
        /// <returns>List of items</returns>
        IList<T> GetAll();


        /// <summary>
        /// Gets the available criteria properties.
        /// </summary>
        /// <value>
        /// The criteria properties.
        /// </value>
        IList<string> CriteriaProperties { get; }

        /// <summary>
        /// Gets all items matching the criteria.
        /// </summary>
        /// <param name="queryExpression">The query expression.</param>
        /// <returns>List of items which matched the criteria</returns>
        IList<T> GetByCriteria(QueryExpression queryExpression);
    }
}