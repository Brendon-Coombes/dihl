using System.Linq;
using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class GameShootoutStatisticFactory
    {
        public GameShootoutStatistic CreateDomainObject(GameShootoutStatisticDTO dto)
        {
            return new GameShootoutStatistic(dto.Id, dto.GameId, dto.CreatedOnUtc, dto.SkaterStatistics.Select(CreateSkaterShootoutStatisticDomainObject).ToList(), dto.GoalieStatistics.Select(CreateGoalieShootoutStatisticDomainObject).ToList());
        }

        private SkaterShootoutStatistic CreateSkaterShootoutStatisticDomainObject(SkaterShootoutStatisticDTO dto)
        {
            return new SkaterShootoutStatistic(dto.Id, dto.GameShootoutStatisticId, dto.TeamId, dto.PlayerId, dto.ShotNumber, dto.Successful, dto.CreatedOnUtc);
        }

        private GoalieShootoutStatistic CreateGoalieShootoutStatisticDomainObject(GoalieShootoutStatisticDTO dto)
        {
            return new GoalieShootoutStatistic(dto.Id, dto.GameShootoutStatisticId, dto.TeamId, dto.PlayerId, dto.ShotsAgainst, dto.GoalsAllowed, dto.WonShootout, dto.CreatedOnUtc);
        }
    }
}
