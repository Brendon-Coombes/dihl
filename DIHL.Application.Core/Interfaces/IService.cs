using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIHL.Application.Core.Interfaces
{
    /// <summary>
    /// Responsible for exposing functionality to allow CRUD operations of the data store.
    /// </summary>
    public interface IService<T>
    {
        /// <summary>
        /// Gets a list of T.
        /// </summary>
        /// <returns>List of T</returns>
        Task<IList<T>> List();

        /// <summary>
        /// Gets a single record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching T</returns>
        Task<T> Get(Guid id);

        /// <summary>
        /// Creates the specified T.
        /// </summary>
        /// <param name="dto">The entity.</param>
        /// <returns>The T that was created.</returns>
        Task<T> Create(T dto);

        /// <summary>
        /// Updates the specified T.
        /// </summary>
        /// <param name="dto">The value.</param>
        /// <returns>The T that was updated.</returns>
        Task<T> Update(T dto);

        /// <summary>
        /// Upserts the specified T. If an ID value is not defined a create operation is performed, otherwise an update is attempted.
        /// </summary>
        /// <param name="dto">The entity.</param>
        /// <returns>The T that was created or updated.</returns>
        Task<T> Upsert(T dto);

        /// <summary>
        /// Deletes the record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        Task<bool> Delete(Guid id);
    }
}
