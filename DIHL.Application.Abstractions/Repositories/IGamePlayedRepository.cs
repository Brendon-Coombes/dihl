using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Domain.Models;

namespace DIHL.Application.Abstractions.Repositories
{
    /// <summary>
    /// The repository is responsible for operations that act on a Gane Played
    /// </summary>
    public interface IGamePlayedRepository
    {
        /// <summary>
        /// Gets the game played that matches the specified player and game ids.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>The matching game played</returns>
        Task<GamePlayed> Get(Guid playerId, Guid gameId);

        /// <summary>
        /// Gets the IModelRoots
        /// </summary>
        /// <returns>IModelRoot list</returns>
        Task<IList<GamePlayed>> List();

        /// <summary>
        /// Gets the Games Played for a given player Id
        /// </summary>
        /// <returns>Games played list</returns>
        Task<IList<GamePlayed>> GetGamesPlayedForPlayer(Guid playerId);

        /// <summary>
        /// Gets the Games played for a given game Id
        /// </summary>
        /// <returns>IModelRoot list</returns>
        Task<IList<GamePlayed>> GetGamesPlayedForGame(Guid gameId);

        /// <summary>
        /// Creates the specified game played.
        /// </summary>
        /// <param name="model">The game played model.</param>
        /// <returns>The created game played model.</returns>
        Task<GamePlayed> Create(GamePlayed model);

        /// <summary>
        /// Updates the specified game played model.
        /// </summary>
        /// <param name="model">The game played model.</param>
        /// <returns>the updated game played model</returns>
        Task<GamePlayed> Update(GamePlayed model);

        /// <summary>
        /// Upserts the specified game played model.
        /// </summary>
        /// <param name="model">The game played model.</param>
        /// <returns>The updated game played model.</returns>
        Task<GamePlayed> Upsert(GamePlayed model);

        /// <summary>
        /// Deletes the specified model.
        /// </summary>
        /// <param name="model">The game played model</param>
        /// <returns>true if delete is successful</returns>
        Task<bool> Delete(GamePlayed model);

        /// <summary>
        /// Deletes the game played model that matches the specified ids.
        /// </summary>
        /// <param name="playerId">The id of the player on the game played model to delete.</param>
        /// <param name="gameId">The id of the game on the game played model to delete.</param>
        /// <returns>
        /// true if delete is successful
        /// </returns>
        Task<bool> Delete(Guid playerId, Guid gameId);
    }
}
