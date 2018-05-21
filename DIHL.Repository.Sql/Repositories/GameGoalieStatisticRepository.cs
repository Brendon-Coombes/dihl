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
    /// The GameGoalieStatistic repository is responsible for operations that act on a GameGoalieStatistic
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.IGameGoalieStatisticRepository" />
    public class GameGoalieStatisticRepository : SimpleRepositoryBase<GameGoalieStatistic, GameGoalieStatisticDataModel>, IGameGoalieStatisticRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="GameGoalieStatisticRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public GameGoalieStatisticRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<GameGoalieStatistic, GameGoalieStatisticDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<GameGoalieStatisticRepository>();

        protected override IQueryable<GameGoalieStatisticDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.GoalieStatistics.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override GameGoalieStatisticDataModel CreateNewDataModel()
        {
            return new GameGoalieStatisticDataModel();
        }

        protected override bool IsCreate(GameGoalieStatisticDataModel dataModel, GameGoalieStatistic domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
