using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class GameGoalieStatisticFactory
    {
        public GameGoalieStatistic CreateDomainObject(GameGoalieStatisticDTO dto)
        {
            return new GameGoalieStatistic(dto.Id, dto.GameId, dto.PlayerId, dto.TeamId, dto.ShotsAgainst, dto.GoalsAllowed, dto.Saves, dto.Result, dto.CreatedOnUtc);
        }
    }
}
