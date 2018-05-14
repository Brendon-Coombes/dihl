using System.Security.Cryptography;
using DIHL.Domain.Aggregates;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Teason Mapper is responsible for mapping the Team Data model to the Teague Domain object and vice versa
    /// </summary>
    public class TeamMapper : IDomainDataMapper<Team, TeamDataModel>
    {
        public TeamDataModel ToDataModel(Team domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new TeamDataModel()
            {
                Id = domainModel.Id,
                Name = domainModel.Name,
                LeagueId = domainModel.LeagueId,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public Team ToDomainModel(TeamDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new Team(
                dataModel.Id,
                dataModel.Name,
                dataModel.LeagueId,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(TeamDataModel dataModel, Team domainModel)
        {
            dataModel.Name = domainModel.Name;
            dataModel.LeagueId = domainModel.LeagueId;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
