using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// GamePlayed Mapper is responsible for mapping the GamePlayed Data model to the GamePlayed Domain object and vice versa
    /// </summary>
    public class GamePlayedMapper : IDomainDataMapper<GamePlayed, GamePlayedDataModel>
    {
        public GamePlayedDataModel ToDataModel(GamePlayed domainModel)
        {
            var dto = new GamePlayedDataModel()
            {
                PlayerId = domainModel.PlayerId,
                GameId = domainModel.GameId,
                TeamId = domainModel.TeamId,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public GamePlayed ToDomainModel(GamePlayedDataModel dataModel)
        {
            var dto = new GamePlayed(
                dataModel.PlayerId,
                dataModel.GameId,
                dataModel.TeamId,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(GamePlayedDataModel dataModel, GamePlayed domainModel)
        {
            dataModel.PlayerId = domainModel.PlayerId;
            dataModel.GameId = domainModel.GameId;
            dataModel.TeamId = domainModel.TeamId;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
