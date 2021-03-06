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
    /// The league repository is responsible for operations that act on a league
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.ILeagueRepository" />
    public class LeagueRepository : SimpleRepositoryBase<League, LeagueDataModel>, ILeagueRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="LeagueRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="leagueMapper"></param>
        public LeagueRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<League, LeagueDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<LeagueRepository>();

        protected override IQueryable<LeagueDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.Leagues.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override LeagueDataModel CreateNewDataModel()
        {
            return new LeagueDataModel();
        }

        protected override bool IsCreate(LeagueDataModel dataModel, League domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
