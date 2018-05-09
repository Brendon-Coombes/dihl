using DIHL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIHL.Application.Core.Interfaces
{
    /// <summary>
    /// Responsible for exposing functionality to allow CRUD operations of the season data store.
    /// </summary>
    public interface ISeasonService
    {
        /// <summary>
        /// Gets a list of leagues.
        /// </summary>
        /// <returns>List of leagues</returns>
        Task<IList<SeasonDTO>> List();

        /// <summary>
        /// Gets a single record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The matching season</returns>
        Task<SeasonDTO> Get(Guid id);

        /// <summary>
        /// Creates the specified season.
        /// </summary>
        /// <param name="seasonDto">The entity.</param>
        /// <returns>The season that was created.</returns>
        Task<SeasonDTO> Create(SeasonDTO seasonDto);

        /// <summary>
        /// Updates the specified season.
        /// </summary>
        /// <param name="seasonDto">The value.</param>
        /// <returns>The season that was updated.</returns>
        Task<SeasonDTO> Update(SeasonDTO seasonDto);

        /// <summary>
        /// Upserts the specified season. If an ID value is not defined a create operation is performed, otherwise an update is attempted.
        /// </summary>
        /// <param name="seasonDto">The entity.</param>
        /// <returns>The season that was created or updated.</returns>
        Task<SeasonDTO> Upsert(SeasonDTO seasonDto);

        /// <summary>
        /// Deletes the record matching the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>true if successful</returns>
        Task<bool> Delete(Guid id);
    }
}
