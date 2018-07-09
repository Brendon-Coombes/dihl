using System.Linq;
using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class GameShootoutStatisticDTOMapper
    {
        public GameShootoutStatisticDTO ToDto(GameShootoutStatistic domain)
        {
            return new GameShootoutStatisticDTO
            {
                Id = domain.Id,
                GameId = domain.GameId,
                CreatedOnUtc = domain.CreatedOn,
                GoalieStatistics = domain.GoalieShootoutStatistics.Select(GoalieShootoutStatisticToDto).ToList(),
                SkaterStatistics = domain.SkaterShootoutStatistics.Select(SkaterShootoutStatisticToDto).ToList()
            };
        }

        private GoalieShootoutStatisticDTO GoalieShootoutStatisticToDto(GoalieShootoutStatistic domain)
        {
            return new GoalieShootoutStatisticDTO
            {
                Id = domain.Id,
                GameShootoutStatisticId = domain.GameShootoutStatisticId,
                TeamId = domain.TeamId,
                PlayerId = domain.PlayerId,
                ShotsAgainst = domain.ShotsAgainst,
                GoalsAllowed = domain.GoalsAllowed,
                WonShootout = domain.WonShootout,
                CreatedOnUtc = domain.CreatedOn
            };
        }

        private SkaterShootoutStatisticDTO SkaterShootoutStatisticToDto(SkaterShootoutStatistic domain)
        {
            return new SkaterShootoutStatisticDTO
            {
                Id = domain.Id,
                GameShootoutStatisticId = domain.GameShootoutStatisticId,
                TeamId = domain.TeamId,
                PlayerId = domain.PlayerId,
                ShotNumber = domain.ShotNumber,
                Successful = domain.Successful,
                CreatedOnUtc = domain.CreatedOn
            };
        }
    }
}
