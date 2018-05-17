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
    /// The Penalty repository is responsible for operations that act on a Penalty
    /// </summary>
    /// <seealso cref="DIHL.Repository.Sql.Repositories.RepositoryBase" />
    /// <seealso cref="DIHL.Application.Abstractions.Repositories.IPenaltyRepository" />
    public class PenaltyRepository : SimpleRepositoryBase<Penalty, PenaltyDataModel>, IPenaltyRepository
    {
        /// <summary>
        /// Creates an instance of <see cref="PenaltyRepository"/>
        /// </summary>
        /// <param name="dbContext"></param>
        /// <param name="mapper"></param>
        public PenaltyRepository(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<Penalty, PenaltyDataModel> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        protected override ILogger Logger { get; } = Log.ForContext<PenaltyRepository>();

        protected override IQueryable<PenaltyDataModel> BaseQuery(Guid? id = null)
        {
            var query = Context.Penalties.AsQueryable();

            if (id != null)
            {
                query = query.Where(e => e.Id == id);
            }

            return query;
        }

        protected override PenaltyDataModel CreateNewDataModel()
        {
            return new PenaltyDataModel();
        }

        protected override bool IsCreate(PenaltyDataModel dataModel, Penalty domainModel)
        {
            return dataModel.Id == Guid.Empty;
        }
    }
}
