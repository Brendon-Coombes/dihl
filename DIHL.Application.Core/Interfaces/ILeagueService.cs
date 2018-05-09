using DIHL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIHL.Application.Core.Interfaces
{
    /// <summary>
    /// Responsible for exposing functionality to allow CRUD operations of the league data store.
    /// </summary>
    public interface ILeagueService
    {
        /// <summary>
        /// Gets a list of leagues.
        /// </summary>
        /// <returns>List of leagues</returns>
        Task<IList<LeagueDTO>> List();

        /// <summary>
        /// Gets a single record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching league</returns>
        Task<LeagueDTO> Get(Guid id);

        /// <summary>
        /// Creates the specified league.
        /// </summary>
        /// <param name="leagueDto">The entity.</param>
        /// <returns>The league that was created.</returns>
        Task<LeagueDTO> Create(LeagueDTO leagueDto);

        /// <summary>
        /// Updates the specified league.
        /// </summary>
        /// <param name="leagueDto">The value.</param>
        /// <returns>The league that was updated.</returns>
        Task<LeagueDTO> Update(LeagueDTO leagueDto);

        /// <summary>
        /// Upserts the specified league. If an ID value is not defined a create operation is performed, otherwise an Update is attempted.
        /// </summary>
        /// <param name="leagueDto">The entity.</param>
        /// <returns>The league that was created or updated.</returns>
        Task<LeagueDTO> Upsert(LeagueDTO leagueDto);

        /// <summary>
        /// Deletes the record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        Task<bool> Delete(Guid id);
    }
}
