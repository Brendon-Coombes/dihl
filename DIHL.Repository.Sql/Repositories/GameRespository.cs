using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Utilities;
using DIHL.Repository.Sql.Database;
using DIHL.Repository.Sql.Models;
using Serilog;
using System;
using System.Linq;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Mappers;

namespace DIHL.Repository.Sql.Repositories
{
    /// <summary>
    /// The Game repository is responsible for operations that act on a Game
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.IGameRepository" />
    public class GameRepository : RepositoryBase<Game, GameDataModel>, IGameRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="GameRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public GameRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<Game, GameDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<GameRepository>();

        protected override IQueryable<GameDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.Games.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override GameDataModel CreateNewDataModel()
        {
            return new GameDataModel();
        }

        protected override bool IsCreate(GameDataModel dataModel, Game domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
