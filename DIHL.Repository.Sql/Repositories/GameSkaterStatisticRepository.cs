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
    /// The GameSkaterStatistic repository is responsible for operations that act on a GameSkaterStatistic
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.IGameSkaterStatisticRepository" />
    public class GameSkaterStatisticRepository : SimpleRepositoryBase<GameSkaterStatistic, GameSkaterStatisticDataModel>, IGameSkaterStatisticRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="GameSkaterStatisticRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public GameSkaterStatisticRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<GameSkaterStatistic, GameSkaterStatisticDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<GameSkaterStatisticRepository>();

        protected override IQueryable<GameSkaterStatisticDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.SkaterStatistics.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override GameSkaterStatisticDataModel CreateNewDataModel()
        {
            return new GameSkaterStatisticDataModel();
        }

        protected override bool IsCreate(GameSkaterStatisticDataModel dataModel, GameSkaterStatistic domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
