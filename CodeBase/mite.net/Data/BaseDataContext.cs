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
    /// Base class for all data contexts
    /// </summary>
    public abstract class BaseDataContext : IDataContext
    {
        /// <summary>
        /// Gets a data mapper for a type.
        /// </summary>
        /// <typeparam name="T">The type for which a data mapper should be retrieved</typeparam>
        /// <returns>A data mapper for the type</returns>
        protected abstract IDataMapper<T> GetDataMapper<T>() where T : class, new ();

        /// <summary>
        /// Disposes the data context
        /// </summary>
        /// <remarks>
        /// Not disposing anything at the moment. Only syntactic sugar
        /// </remarks>
        public virtual void Dispose()
        {
           
        }

        /// <summary>
        /// Gets all items of the specified type.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <returns>List of items</returns>
        public virtual IList<T> GetAll<T>() where T : class, new()
        {
            return GetDataMapper<T>().GetAll();
        }

        /// <summary>
        /// Gets a list of items by criteria.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <param name="queryExpression">The query expression.</param>
        /// <returns>List of itmes which matches the query</returns>
        public virtual IList<T> GetByCriteria<T>(QueryExpression queryExpression) where T : class, new()
        {
            return GetDataMapper<T>().GetByCriteria(queryExpression);
        }

        /// <summary>
        /// Returns the item with the specified id.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <param name="id">The id.</param>
        /// <returns>The item</returns>
        public virtual T GetById<T>(object id) where T : class, new()
        {
            return GetDataMapper<T>().GetById(id);
        }

        /// <summary>
        /// Creates the specified item.
        /// </summary>
        /// <typeparam name="T">The type to create</typeparam>
        /// <param name="item">The item.</param>
        /// <returns>The created item</returns>
        public virtual T Create<T>(T item) where T : class, new()
        {
            return GetDataMapper<T>().Create(item);
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <typeparam name="T">The type to delete</typeparam>
        /// <param name="item">The item.</param>
        public virtual void Delete<T>(T item) where T : class, new()
        {
            GetDataMapper<T>().Delete(item);
        }

        /// <summary>
        /// Updates the specified item.
        /// </summary>
        /// <typeparam name="T">The type to retreive</typeparam>
        /// <param name="item">The item.</param>
        /// <returns>The updated item</returns>
        public virtual T Update<T>(T item) where T : class, new()
        {
            return GetDataMapper<T>().Update(item);
        }
    }
}