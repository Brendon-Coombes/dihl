using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Season Mapper is responsible for mapping the Season Data model to the Season Domain object and vice versa
    /// </summary>
    public class SeasonMapper : IDomainDataMapper<Season, SeasonDataModel>
    {
        public SeasonDataModel ToDataModel(Season domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new SeasonDataModel()
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                Year = domainModel.Year,
                LeagueId = domainModel.LeagueId,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public Season ToDomainModel(SeasonDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new Season(
                dataModel.Id,
                dataModel.Name,
                dataModel.CreatedOnUtc,
                dataModel.Year,
                dataModel.LeagueId
            );

            return dto;
        }

        public void UpdateDataModel(SeasonDataModel dataModel, Season domainModel)
        {
            dataModel.Name = domainModel.Name;
            dataModel.Year = domainModel.Year;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
