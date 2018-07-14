using System.Linq;
using DIHL.Domain.Models;
using DIHL.Repository.Sql.Models;

namespace DIHL.Repository.Sql.Mappers
{
    /// <summary>
    /// Game Shootout Statistic Mapper is responsible for mapping the Game Shootout Statistic Data model to the Game Shootout Statistic Domain object and vice versa
    /// </summary>
    public class GameShootoutStatisticMapper : IDomainDataMapper<GameShootoutStatistic, GameShootoutStatisticDataModel>
    {
        public GameShootoutStatisticDataModel ToDataModel(GameShootoutStatistic domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new GameShootoutStatisticDataModel()
            {
                Id = domainModel.Id,
                GameId = domainModel.GameId,
                GoalieShootoutStatistics = domainModel.GoalieShootoutStatistics.Select(GoalieStatisticsToDataModel).ToList(),
                SkaterShootoutStatistics = domainModel.SkaterShootoutStatistics.Select(SkaterStatisticsToDataModel).ToList(),
                CreatedOnUtc = domainModel.CreatedOn
            };

            return dto;
        }

        private GoalieShootoutStatisticDataModel GoalieStatisticsToDataModel(GoalieShootoutStatistic domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new GoalieShootoutStatisticDataModel
            {
                Id = domainModel.Id,
                TeamId = domainModel.TeamId,
                PlayerId = domainModel.PlayerId,
                GameShootoutStatisticId = domainModel.GameShootoutStatisticId,
                ShotsAgainst = domainModel.ShotsAgainst,
                GoalsAllowed = domainModel.GoalsAllowed,
                WonShootout = domainModel.WonShootout
            };

            return dto;
        }

        private SkaterShootoutStatisticDataModel SkaterStatisticsToDataModel(SkaterShootoutStatistic domainModel)
        {
            if (domainModel == null)
            {
                return null;
            }

            var dto = new SkaterShootoutStatisticDataModel
            {
                Id = domainModel.Id,
                TeamId = domainModel.TeamId,
                PlayerId = domainModel.PlayerId,
                GameShootoutStatisticId = domainModel.GameShootoutStatisticId,
                ShotNumber = domainModel.ShotNumber,
                Successful= domainModel.Successful
            };

            return dto;
        }

        public GameShootoutStatistic ToDomainModel(GameShootoutStatisticDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new GameShootoutStatistic(
                dataModel.Id,
                dataModel.GameId,
                dataModel.CreatedOnUtc,
                dataModel.SkaterShootoutStatistics.Select(SkaterStatisticsToDomainModel).ToList(),
                dataModel.GoalieShootoutStatistics.Select(GoalieStatisticsToDomainModel).ToList()
            );

            return dto;
        }

        public GoalieShootoutStatistic GoalieStatisticsToDomainModel(GoalieShootoutStatisticDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new GoalieShootoutStatistic(
                dataModel.Id,
                dataModel.GameShootoutStatisticId,
                dataModel.TeamId,
                dataModel.PlayerId,
                dataModel.ShotsAgainst,
                dataModel.GoalsAllowed,
                dataModel.WonShootout,
                dataModel.CreatedOnUtc
            );

            return dto;
        }


        public SkaterShootoutStatistic SkaterStatisticsToDomainModel(SkaterShootoutStatisticDataModel dataModel)
        {
            if (dataModel == null)
            {
                return null;
            }

            var dto = new SkaterShootoutStatistic(
                dataModel.Id,
                dataModel.GameShootoutStatisticId,
                dataModel.TeamId,
                dataModel.PlayerId,
                dataModel.ShotNumber,
                dataModel.Successful,
                dataModel.CreatedOnUtc
            );

            return dto;
        }

        public void UpdateDataModel(GameShootoutStatisticDataModel dataModel, GameShootoutStatistic domainModel)
        {
            dataModel.GameId = domainModel.GameId;
            dataModel.CreatedOnUtc = domainModel.CreatedOn;
            dataModel.GoalieShootoutStatistics = domainModel.GoalieShootoutStatistics.Select(GoalieStatisticsToDataModel).ToList();
            dataModel.SkaterShootoutStatistics = domainModel.SkaterShootoutStatistics.Select(SkaterStatisticsToDataModel).ToList();
        }
    }
}
