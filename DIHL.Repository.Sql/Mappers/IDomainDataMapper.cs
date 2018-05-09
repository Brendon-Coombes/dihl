namespace DIHL.Repository.Sql.Repositories
{
    public interface IDomainDataMapper<T, TU>
    {
        T ToDomainModel(TU dataModel);

        TU ToDataModel(T domainModel);

        void UpdateDataModel(TU dataModel, T domainModel);
    }
}
