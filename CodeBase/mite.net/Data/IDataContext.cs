//-----------------------------------------------------------------------
// <copyright>
// This software is licensed as Microsoft Public License (Ms-PL).
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;

namespace Mite
{
    /// <summary>
    /// Context for persistence
    /// </summary>
    public interface IDataContext : IDisposable
    {
        /// <summary>
        /// Gets all items of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <returns>List of items</returns>
        IList<T> GetAll<T>() where T : class, new();

        /// <summary>
        /// Gets a list of items by criteria.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <param name="queryExpression">The query expression.</param>
        /// <returns>List of itmes which matches the query</returns>
        IList<T> GetByCriteria<T>(QueryExpression queryExpression) where T : class, new();

        /// <summary>
        /// Returns the item with the specified id.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The item</returns>
        T GetById<T>(object id) where T : class, new();

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <typeparam name="T">The type to create</typeparam>
        /// <param name="item">The item.</param>
        /// <returns>The created item</returns>
        T Create<T>(T item) where T : class, new();

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <typeparam name="T">The type to delete</typeparam>
        /// <param name="item">The item.</param>
        void Delete<T>(T item) where T : class, new();

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <param name="item">The item.</param>
        /// <returns>The updated item</returns>
        T Update<T>(T item) where T : class, new();
    }
}