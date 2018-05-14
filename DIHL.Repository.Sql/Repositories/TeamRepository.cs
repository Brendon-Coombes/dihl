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
    /// The team repository is responsible for operations that act on a team
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.ITeamRepository" />
    public class TeamRepository : RepositoryBase<Team, TeamDataModel>, ITeamRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="TeamRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="leagueMapper"></param>
        public TeamRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<Team, TeamDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<TeamRepository>();

        protected override IQueryable<TeamDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.Teams.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override TeamDataModel CreateNewDataModel()
        {
            return new TeamDataModel();
        }

        protected override bool IsCreate(TeamDataModel dataModel, Team domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
