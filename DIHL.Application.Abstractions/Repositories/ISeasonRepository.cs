using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Domain;
using DIHL.Domain.Aggregates;

namespace DIHL.Application.Abstractions.Repositories
{
    /// <summary>
    /// The season repository is responsible for operations that act on an season
    /// </summary>
    public interface ISeasonRepository
    {
        /// <summary>
        /// Gets the season that matches the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching season</returns>
        Task<Season> Get(Guid id);

        /// <summary>
        /// Gets the seasons
        /// </summary>
        /// <returns>Seasons list</returns>
        Task<IList<Season>> List();

        /// <summary>
        /// Creates the specified season.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>the created season.</returns>
        Task<Season> Create(Season season);

        /// <summary>
        /// Updates the specified season.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>the updated season.</returns>
        Task<Season> Update(Season season);

        /// <summary>
        /// Upserts the specified season.
        /// If the season id is not set the operation is treated as a create, otherwise an update is performed.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>The updated season.</returns>
        Task<Season> Upsert(Season season);

        /// <summary>
        /// Deletes the specified season.
        /// </summary>
        /// <param name="season">The season.</param>
        /// <returns>true if delete is successful</returns>
        Task<bool> Delete(Season season);

        /// <summary>
        /// Deletes the season that matches the specified id.
        /// </summary>
        /// <param name="id">The id of the season to delete.</param>
        /// <returns>
        /// true if delete is successful
        /// </returns>
        Task<bool> Delete(Guid id);
    }
}
