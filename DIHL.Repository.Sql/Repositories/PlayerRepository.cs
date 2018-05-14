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
    /// The player repository is responsible for operations that act on a player
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.IPlayerRepository" />
    public class PlayerRepository : RepositoryBase<Player, PlayerDataModel>, IPlayerRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="PlayerRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public PlayerRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<Player, PlayerDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<PlayerRepository>();

        protected override IQueryable<PlayerDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.Players.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override PlayerDataModel CreateNewDataModel()
        {
            return new PlayerDataModel();
        }

        protected override bool IsCreate(PlayerDataModel dataModel, Player domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
