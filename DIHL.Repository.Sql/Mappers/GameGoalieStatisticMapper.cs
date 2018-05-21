using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Game Mapper is responsible for mapping the GameGoalieStatistic Data model to the GameGoalieStatistic Domain object and vice versa
    /// </summary>
    public class GameGoalieStatisticMapper : IDomainDataMapper<GameGoalieStatistic, GameGoalieStatisticDataModel>
    {
        public GameGoalieStatisticDataModel ToDataModel(GameGoalieStatistic domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new GameGoalieStatisticDataModel()
            {
                Id = domainModel.Id,
                GameId = domainModel.GameId,
                PlayerId = domainModel.PlayerId,
                TeamId = domainModel.TeamId,
                ShotsAgainst = domainModel.ShotsAgainst,
                GoalsAllowed = domainModel.GoalsAllowed,
                Saves = domainModel.Saves,
                Result = domainModel.Result,
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        public GameGoalieStatistic ToDomainModel(GameGoalieStatisticDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new GameGoalieStatistic(
                dataModel.Id,
                dataModel.GameId,
                dataModel.PlayerId,
                dataModel.TeamId,
                dataModel.ShotsAgainst,
                dataModel.GoalsAllowed,
                dataModel.Saves,
                dataModel.Result,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(GameGoalieStatisticDataModel dataModel, GameGoalieStatistic domainModel)
        {
            dataModel.GameId = domainModel.GameId;
            dataModel.PlayerId = domainModel.PlayerId;
            dataModel.TeamId = domainModel.TeamId;
            dataModel.ShotsAgainst = domainModel.ShotsAgainst;
            dataModel.GoalsAllowed = domainModel.GoalsAllowed;
            dataModel.Saves = domainModel.Saves;
            dataModel.Result = domainModel.Result;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
        }
    }
}
