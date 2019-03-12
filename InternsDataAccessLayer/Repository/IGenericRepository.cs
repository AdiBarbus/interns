using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace InternsDataAccessLayer.Repository
{
    public interface IGenericRepository<T> where T:class
    {
        /// <summary>
        ///     Gets a list of all T items
        /// </summary>
        /// <returns> 
        ///     Returns a list of all T items
        /// </returns>
        IList<T> GetAll(params Expression<Func<T, object>>[] predicate);

        /// <summary>
        ///     Gets the item with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> The item with the id passed as the parameter </returns>
        T GetById(Func<T, bool> where, params Expression<Func<T, object>>[] predicate);

        /// <summary>
        ///     Inserts a new object in the T table
        /// </summary>
        /// <param name="item"></param>
        void Insert(T item);
        /// <summary>
        ///     Deletes the item with the id passed as the parameter
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        ///     Updates the item with the new value passed as the parameter
        /// </summary>
        /// <param name="item"></param>
        void Update(T item);
        /// <summary>
        ///     Saves the modifications in the database
        /// </summary>
        //void Save();
    }
}
