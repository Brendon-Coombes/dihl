using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class GameGoalieStatisticDTOMapper
    {
        public GameGoalieStatisticDTO ToDto(GameGoalieStatistic domain)
        {
            return new GameGoalieStatisticDTO()
            {
                Id = domain.Id,
                GameId = domain.GameId,
                PlayerId = domain.PlayerId,
                TeamId = domain.TeamId,
                GoalsAllowed = domain.GoalsAllowed,
                ShotsAgainst = domain.ShotsAgainst,
                Saves = domain.Saves,
                Result = domain.Result,
                CreatedOnUtc = domain.CreatedOn
            };
        }
    }
}
