using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Domain.Models;

namespace DIHL.Application.Abstractions.Repositories
{
    /// <summary>
    /// The repository is responsible for operations that act on an IModelRoot
    /// </summary>
    public interface IRepository<T> where T : IModelRoot
    {
        /// <summary>
        /// Gets the IModelRoot that matches the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching IModelRoot</returns>
        Task<T> Get(Guid id);

        /// <summary>
        /// Gets the IModelRoots
        /// </summary>
        /// <returns>IModelRoot list</returns>
        Task<IList<T>> List();

        /// <summary>
        /// Creates the specified IModelRoot.
        /// </summary>
        /// <param name="model">The IModelRoot.</param>
        /// <returns>the created IModelRoot.</returns>
        Task<T> Create(T model);

        /// <summary>
        /// Updates the specified IModelRoot.
        /// </summary>
        /// <param name="model">The IModelRoot.</param>
        /// <returns>the updated IModelRoot.</returns>
        Task<T> Update(T model);

        /// <summary>
        /// Upserts the specified IModelRoot.
        /// If the IModelRoot id is not set the operation is treated as a create, otherwise an update is performed.
        /// </summary>
        /// <param name="model">The IModelRoot.</param>
        /// <returns>The updated IModelRoot.</returns>
        Task<T> Upsert(T model);

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The IModelRoot.</param>
        /// <returns>true if delete is successful</returns>
        Task<bool> Delete(T model);

        /// <summary>
        /// Deletes the IModelRoot that matches the specified id.
        /// </summary>
        /// <param name="id">The id of the IModelRoot to delete.</param>
        /// <returns>
        /// true if delete is successful
        /// </returns>
        Task<bool> Delete(Guid id);
    }
}
