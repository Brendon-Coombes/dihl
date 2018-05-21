using DIHL.Application.Core.Utilities;
using DIHL.Repository.Sql.Database;
using DIHL.Repository.Sql.Models;
using Serilog;
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
    public abstract class RepositoryBase<T, TU>
        where T : IModelRoot
        where TU : class, IDataModel
    {
        protected IActionHandler Handler { get; private set; }
        protected abstract ILogger Logger { get; }

        protected DihlDbContext Context { get; private set; }
        protected IDomainDataMapper<T, TU> Mapper { get; private set; }

        protected RepositoryBase(IActionHandler handler, DihlDbContext dbContext, IDomainDataMapper<T, TU> mapper)
        {
            Handler = handler;
            Context = dbContext;
            Mapper = mapper;
        }

        /// <summary>
        /// Creates the specified dto.
        /// </summary>
        /// <param name="domainModel">The domainModel.</param>
        /// <returns></returns>
        public async Task<T> Create(T domainModel)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                var dataModel = CreateNewDataModel();
                return await UpsertAndSave(domainModel, dataModel);
            });
        }

        /// <summary>
        /// Deletes the model that matches the specified id.
        /// </summary>
        /// <param name="domainModel">The domain object to delete.</param>
        /// <returns>
        /// true if delete is successful
        /// </returns>
        public async Task<bool> Delete(T domainModel)
        {
            return await this.Handler.Execute(this.Logger, async () =>
            {
                return await Delete(domainModel);
            });
        }


        /// <summary>
        /// Upserts the entity and calls save changes.
        /// </summary>
        /// <param name="domainModel">The entity dto.</param>
        /// <param name="dataModel">The data model.</param>
        /// <returns></returns>
        private async Task<T> UpsertAndSave(T domainModel, TU dataModel)
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
        /// Creates the new empty data model.
        /// </summary>
        /// <returns></returns>
        protected abstract TU CreateNewDataModel();

        /// <summary>
        /// Determines if the Data Model is a create or update.
        /// </summary>
        /// <returns></returns>
        protected abstract bool IsCreate(TU dataModel, T domainModel);
    }
}
