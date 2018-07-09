using DIHL.Application.Core.Utilities;
using DIHL.Repository.Sql.Database;
using DIHL.Repository.Sql.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Mappers;

namespace DIHL.Repository.Sql.Repositories
{
    /// <summary>
    /// Base repository class providing access to a database context.
    /// </summary>
    /// <typeparam name="T">The root domain object</typeparam>
    /// <typeparam name="TU">The root data model</typeparam>
    public abstract class SimpleRepositoryBase<T, TU> : RepositoryBase<T, TU>
        where T : ISimpleModel
        where TU : class, IDataModel
    {
        public SimpleRepositoryBase(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<T, TU> mapper)
            : base(handler, dbContext, mapper)
        {
        }

        /// <summary>
        /// Gets the league that matches the specified id.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        /// The matching entity
        /// </returns>
        public async Task<T> Get(Guid id)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                TU dataModel = await BaseQuery(id).FirstOrDefaultAsync();
                return Mapper.ToDomainModel(dataModel);
            });
        }

        /// <summary>
        /// Gets the entities
        /// </summary>
        /// <returns>Entities list</returns>
        public async Task<IList<T>> List()
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                return await BaseQuery()
                .Select(x => Mapper.ToDomainModel(x))
                .ToListAsync();
            });
        }

        /// <summary>
        /// Updates the specified domainModel.
        /// </summary>
        /// <param name="domainModel">The dto.</param>
        /// <returns></returns>
        public async Task<T> Update(T domainModel)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                TU dataModel = await BaseQuery(domainModel.Id).FirstAsync();
                return await UpsertAndSave(domainModel, dataModel);
            });
        }

        /// <summary>
        /// Upserts the specified dto.
        /// </summary>
        /// <param name="domainModel">The dto.</param>
        /// <returns></returns>
        public async Task<T> Upsert(T domainModel)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                TU dataModel = await BaseQuery(domainModel.Id).FirstOrDefaultAsync();
                if (dataModel == null)
                {
                    dataModel = CreateNewDataModel();
                }

                return await UpsertAndSave(domainModel, dataModel);
            });
        }

        /// <summary>
        /// Deletes the model that matches the specified id.
        /// </summary>
        /// <param name="id">The id of the domain objected to delete.</param>
        /// <returns>
        /// true if delete is successful
        /// </returns>
        public async Task<bool> Delete(Guid id)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                TU model = await BaseQuery(id).FirstAsync();

                Context.Remove(model);
                await Context.SaveChangesAsync();

                return true;
            });
        }

        /// <summary>
        /// Upserts the entity and calls save changes.
        /// </summary>
        /// <param name="domainModel">The entity dto.</param>
        /// <param name="dataModel">The data model.</param>
        /// <returns></returns>
        protected async Task<T> UpsertAndSave(T domainModel, TU dataModel)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                bool isCreate = IsCreate(dataModel, domainModel);

                Mapper.UpdateDataModel(dataModel, domainModel);

                if (isCreate)
                {
                    Context.Add(dataModel);
                }
                else
                {
                    Context.Update(dataModel);
                }

                await Context.SaveChangesAsync();

                return Mapper.ToDomainModel(dataModel);
            });
        }

        /// <summary>
        /// The base query for retrieving data.
        /// Applies a base filter for model id.
        /// </summary>
        /// <param name="id">The identifier to filter on (optional)</param>
        /// <returns>An IQueryable entity data query to add further filters onto. </returns>
        protected abstract IQueryable<TU> BaseQuery(Guid? id = null);
    }
}
