using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Interfaces
{
    /// <summary>
    /// Responsible for exposing functionality to allow CRUD operations of the game data store.
    /// </summary>
    public interface IGamePlayedService
    {
        /// <summary>
        /// Gets a list of GamePlayedDTO.
        /// </summary>
        /// <returns>List of GamePlayedDTO</returns>
        Task<IList<GamePlayedDTO>> List();

        /// <summary>
        /// Gets a single record matching the specified id.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The matching GamePlayedDTO</returns>
        Task<GamePlayedDTO> Get(Guid playerId, Guid gameId);

        /// <summary>
        /// Gets the Games Played for a given player Id
        /// </summary>
        /// <returns>Games played list</returns>
        Task<IList<GamePlayedDTO>> GetGamesPlayedForPlayer(Guid playerId);

        /// <summary>
        /// Gets the Games played for a given game Id
        /// </summary>
        /// <returns>IModelRoot list</returns>
        Task<IList<GamePlayedDTO>> GetGamesPlayedForGame(Guid gameId);

        /// <summary>
        /// Creates the specified GamePlayedDTO.
        /// </summary>
        /// <param name="dto">The entity.</param>
        /// <returns>The GamePlayedDTO that was created.</returns>
        Task<GamePlayedDTO> Create(GamePlayedDTO dto);

        /// <summary>
        /// Updates the specified GamePlayedDTO.
        /// </summary>
        /// <param name="dto">The value.</param>
        /// <returns>The GamePlayedDTO that was updated.</returns>
        Task<GamePlayedDTO> Update(GamePlayedDTO dto);

        /// <summary>
        /// Upserts the specified GamePlayedDTO. If an ID value is not defined a create operation is performed, otherwise an update is attempted.
        /// </summary>
        /// <param name="dto">The entity.</param>
        /// <returns>The GamePlayedDTO that was created or updated.</returns>
        Task<GamePlayedDTO> Upsert(GamePlayedDTO dto);

        /// <summary>
        /// Deletes the record matching the specified id.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>true if successful</returns>
        Task<bool> Delete(Guid playerId, Guid gameId);
    }
}
