using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Domain;
using DIHL.Domain.Aggregates;

namespace DIHL.Application.Abstractions.Repositories
{
    /// <summary>
    /// The league repository is responsible for operations that act on an league
    /// </summary>
    public interface ILeagueRepository
    {
        /// <summary>
        /// Gets the league that matches the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching league</returns>
        Task<League> Get(Guid id);

        /// <summary>
        /// Gets the leagues
        /// </summary>
        /// <returns>Leagues list</returns>
        Task<IList<League>> List();

        /// <summary>
        /// Creates the specified league.
        /// </summary>
        /// <param name="league">The league.</param>
        /// <returns>the created league.</returns>
        Task<League> Create(League league);

        /// <summary>
        /// Updates the specified league.
        /// </summary>
        /// <param name="league">The league.</param>
        /// <returns>the updated league.</returns>
        Task<League> Update(League league);

        /// <summary>
        /// Upserts the specified league.
        /// If the league id is not set the operation is treated as a create, otherwise an update is performed.
        /// </summary>
        /// <param name="league">The league.</param>
        /// <returns>The updated league.</returns>
        Task<League> Upsert(League league);

        /// <summary>
        /// Deletes the specified league.
        /// </summary>
        /// <param name="league">The league.</param>
        /// <returns>true if delete is successful</returns>
        Task<bool> Delete(League league);

        /// <summary>
        /// Deletes the league that matches the specified id.
        /// </summary>
        /// <param name="id">The id of the league to delete.</param>
        /// <returns>
        /// true if delete is successful
        /// </returns>
        Task<bool> Delete(Guid id);
    }
}
