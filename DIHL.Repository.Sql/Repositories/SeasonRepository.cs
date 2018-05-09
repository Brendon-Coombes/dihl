using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Utilities;
using DIHL.Repository.Sql.Database;
using DIHL.Repository.Sql.Models;
using DIHL.Domain.Aggregates;
using Serilog;
using System;
using System.Linq;
using DIHL.Repository.Sql.Mappers;

namespace DIHL.Repository.Sql.Repositories
{
    /// <summary>
    /// The season repository is responsible for operations that act on a season
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.ISeasonRepository" />
    public class SeasonRepository : RepositoryBase<Season, SeasonDataModel>, ISeasonRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="SeasonRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="seasonMapper"></param>
        public SeasonRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<Season, SeasonDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<SeasonRepository>();

        protected override IQueryable<SeasonDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.Seasons.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override SeasonDataModel CreateNewDataModel()
        {
            return new SeasonDataModel();
        }

        protected override bool IsCreate(SeasonDataModel dataModel, Season domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
