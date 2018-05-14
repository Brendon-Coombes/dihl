using System.Security.Cryptography;
using DIHL.Domain.Aggregates;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Season Mapper is responsible for mapping the League Data model to the League Domain object and vice versa
    /// </summary>
    public class PlayerMapper : IDomainDataMapper<Player, PlayerDataModel>
    {
        public PlayerDataModel ToDataModel(Player domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new PlayerDataModel()
            {
                Id = domainModel.Id,
                FirstName = domainModel.FirstName,
                LastName = domainModel.LastName,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public Player ToDomainModel(PlayerDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new Player(
                dataModel.Id,
                dataModel.FirstName,
                dataModel.LastName,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(PlayerDataModel dataModel, Player domainModel)
        {
            dataModel.FirstName = domainModel.FirstName;
            dataModel.LastName = domainModel.LastName;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
