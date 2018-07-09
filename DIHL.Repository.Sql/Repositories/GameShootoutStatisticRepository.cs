using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Utilities;
using DIHL.Repository.Sql.Database;
using DIHL.Repository.Sql.Models;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Mappers;
using Microsoft.EntityFrameworkCore;

namespace DIHL.Repository.Sql.Repositories
{
    /// <summary>
    /// The GameShootoutStatistic repository is responsible for operations that act on a GameShootoutStatistic
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.IGameGoalieStatisticRepository" />
    public class GameShootoutStatisticRepository : SimpleRepositoryBase<GameShootoutStatistic, GameShootoutStatisticDataModel>, IGameShootoutStatisticRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="GameGoalieStatisticRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public GameShootoutStatisticRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<GameShootoutStatistic, GameShootoutStatisticDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<GameShootoutStatisticRepository>();

        protected override IQueryable<GameShootoutStatisticDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.GameShootoutStatistics
                .Include(s => s.GoalieShootoutStatistics)
                .Include(s => s.SkaterShootoutStatistics)
                .AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        //public new async Task<GameShootoutStatistic> Upsert(GameShootoutStatistic domainModel)
        //{
        //    return await this.Handler.Execute(this.Logger, async () =>
        //    {
        //        GameShootoutStatisticDataModel dataModel = await BaseQuery(domainModel.Id).FirstOrDefaultAsync();
        //        if (dataModel == null)
        //        {
        //            dataModel = CreateNewDataModel();
        //        }

        //        return await UpsertAndSave(domainModel, dataModel);
        //    });
        //}

        protected override GameShootoutStatisticDataModel CreateNewDataModel()
        {
            return new GameShootoutStatisticDataModel();
        }

        protected override bool IsCreate(GameShootoutStatisticDataModel dataModel, GameShootoutStatistic domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
