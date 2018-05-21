using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Game Mapper is responsible for mapping the GameSkaterStatistic Data model to the GameSkaterStatistic Domain object and vice versa
    /// </summary>
    public class GameSkaterStatisticMapper : IDomainDataMapper<GameSkaterStatistic, GameSkaterStatisticDataModel>
    {
        public GameSkaterStatisticDataModel ToDataModel(GameSkaterStatistic domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new GameSkaterStatisticDataModel()
            {
                Id = domainModel.Id,
                GameId = domainModel.GameId,
                PlayerId = domainModel.PlayerId,
                TeamId = domainModel.TeamId,
                ScoreType = (int)domainModel.ScoreType,
                PrimaryAssistPlayerId = domainModel.PrimaryAssistPlayerId,
                SecondaryAssistPlayerId = domainModel.SecondaryAssistPlayerId,
                Period = domainModel.Period,
                Time = domainModel.Time,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public GameSkaterStatistic ToDomainModel(GameSkaterStatisticDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new GameSkaterStatistic(
                dataModel.Id,
                dataModel.GameId,
                dataModel.PlayerId,
                dataModel.TeamId,
                dataModel.ScoreType,
                dataModel.PrimaryAssistPlayerId,
                dataModel.SecondaryAssistPlayerId,
                dataModel.Period,
                dataModel.Time,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(GameSkaterStatisticDataModel dataModel, GameSkaterStatistic domainModel)
        {
            dataModel.GameId = domainModel.GameId;
            dataModel.PlayerId = domainModel.PlayerId;
            dataModel.TeamId = domainModel.TeamId;
            dataModel.ScoreType = (int)domainModel.ScoreType;
            dataModel.PrimaryAssistPlayerId = domainModel.PrimaryAssistPlayerId;
            dataModel.SecondaryAssistPlayerId = domainModel.SecondaryAssistPlayerId;
            dataModel.Period = domainModel.Period;
            dataModel.Time = domainModel.Time;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
