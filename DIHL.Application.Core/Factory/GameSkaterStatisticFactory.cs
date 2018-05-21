using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class GameSkaterStatisticFactory
    {
        public GameSkaterStatistic CreateDomainObject(GameSkaterStatisticDTO dto)
        {
            return new GameSkaterStatistic(dto.Id, dto.GameId, dto.PlayerId, dto.TeamId, (int)dto.ScoreType, dto.PrimaryAssistPlayerId, dto.SecondaryAssistPlayerId, dto.Period, dto.Time, dto.CreatedOnUtc);
        }
    }
}
