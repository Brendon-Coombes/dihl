using DIHL.Domain.Aggregates;
using DIHL.Repository.Sql.Models;
using DIHL.Repository.Sql.Repositories;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// League Mapper is responsible for mapping the League Data model to the League Domain object and vice versa
    /// </summary>
    public class LeagueMapper : IDomainDataMapper<League, LeagueDataModel>
    {
        public LeagueDataModel ToDataModel(League domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new LeagueDataModel()
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                Tier = (int)domainModel.Tier,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public League ToDomainModel(LeagueDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new League(
                dataModel.Id,
                dataModel.Name,
                dataModel.CreatedOnUtc,
                dataModel.Tier                
            );

            return dto;
        }

        public void UpdateDataModel(LeagueDataModel dataModel, League domainModel)
        {
            dataModel.Name = domainModel.Name;
            dataModel.Tier = (int)domainModel.Tier;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
