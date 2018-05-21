using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class GameSkaterStatisticDTOMapper
    {
        public GameSkaterStatisticDTO ToDto(GameSkaterStatistic domain)
        {
            return new GameSkaterStatisticDTO()
            {
                Id = domain.Id,
                GameId = domain.GameId,
                PlayerId = domain.PlayerId,
                TeamId = domain.TeamId,
                ScoreType = domain.ScoreType,
                PrimaryAssistPlayerId = domain.PrimaryAssistPlayerId,
                SecondaryAssistPlayerId = domain.SecondaryAssistPlayerId,
                Period = domain.Period,
                Time = domain.Time,
                CreatedOnUtc = domain.CreatedOn
            };
        }
    }
}
