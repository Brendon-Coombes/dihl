using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Utilities;
using DIHL.Repository.Sql.Database;
using DIHL.Repository.Sql.Models;
using Serilog;
using System;
using System.Linq;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Mappers;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DIHL.Repository.Sql.Repositories
{
    /// <summary>
    /// The GamePlayed repository is responsible for operations that act on a GamePlayed
    /// </summary>
    /// <seealso cref="CompositeRepositoryBase{T,TU}" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.IGamePlayedRepository" />
    public class GamePlayedRepository : CompositeRepositoryBase<GamePlayed, GamePlayedDataModel>, IGamePlayedRepository
    {
        protected override ILogger Logger { get; } = Log.ForContext<GamePlayedRepository>();

        /// <summary>
        /// Creates an instance of <see cref="GamePlayedRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public GamePlayedRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<GamePlayed, GamePlayedDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        /// <summary>
        /// Gets the game played that matches the specified player id and game id.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>
        /// The matching entity
        /// </returns>
        public async Task<GamePlayed> Get(Guid playerId, Guid gameId)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                var dataModel = await BaseQuery().Where(gp => gp.GameId == gameId && gp.PlayerId == playerId).FirstOrDefaultAsync();
                return Mapper.ToDomainModel(dataModel);
            });
        }

        /// <summary>
        /// Gets the games played that matches the specified game id.
        /// </summary>
        /// <param name="gameId">The game identifier.</param>
        /// <returns>
        /// The matching entity
        /// </returns>
        public async Task<IList<GamePlayed>> GetGamesPlayedForGame(Guid gameId)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                return await BaseQuery()
                    .Where(x => x.GameId == gameId)
                    .Select(x => Mapper.ToDomainModel(x))
                    .ToListAsync();
            });
        }

        /// <summary>
        /// Gets the games played that matches the specified player id.
        /// </summary>
        /// <param name="playerId">The player identifier.</param>
        /// <returns>
        /// The matching entity
        /// </returns>
        public async Task<IList<GamePlayed>> GetGamesPlayedForPlayer(Guid playerId)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                return await BaseQuery()
                    .Where(x => x.PlayerId == playerId)
                    .Select(x => Mapper.ToDomainModel(x))
                    .ToListAsync();
            });
        }

        /// <summary>
        /// Deletes the model that matches the specified player id and game id.
        /// </summary>
        /// <param name="gameId">The game id of the domain object to delete.</param>
        /// <param name="playerId">The player id of the domain object to delete.</param>
        /// <returns>
        /// true if delete is successful
        /// </returns>
        public async Task<bool> Delete(Guid playerId, Guid gameId)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                var model = await BaseQuery().Where(gp => gp.GameId == gameId && gp.PlayerId == playerId).FirstAsync();

                Context.Remove(model);
                await Context.SaveChangesAsync();

                return true;
            });
        }

        protected override IQueryable<GamePlayedDataModel> BaseQuery(GamePlayed? model = null)
        {
            var query = Context.GamesPlayed.AsQueryable();

            if (model != null)
            {
                query = query.Where(e => e.GameId == model.Value.GameId && e.PlayerId == model.Value.PlayerId);
            }

            return query;
        }

        protected override GamePlayedDataModel CreateNewDataModel()
        {
            return new GamePlayedDataModel();
        }

        protected override bool IsCreate(GamePlayedDataModel dataModel, GamePlayed domainModel)
        {
            return dataModel.CreatedOnUtc == default(DateTime);
        }
    }
}
