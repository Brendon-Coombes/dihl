using DIHL.Domain.Models;

namespace DIHL.Application.Core.Factory
{
    public class GamePlayedFactory
    {
        public GamePlayed CreateDomainObject(GamePlayedDTO dto)
        {
            return new GamePlayed(dto.PlayerId, dto.GameId, dto.TeamId, dto.CreatedOnUtc);
        }
    }
}
