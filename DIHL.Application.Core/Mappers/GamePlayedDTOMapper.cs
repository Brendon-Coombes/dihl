using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class GamePlayedDTOMapper
    {
        public GamePlayedDTO ToDto(GamePlayed domain)
        {
            return new GamePlayedDTO()
            {
                PlayerId = domain.PlayerId,
                GameId = domain.GameId,
                TeamId = domain.TeamId,
                CreatedOnUtc = domain.CreatedOn
            };
        }
    }
}
