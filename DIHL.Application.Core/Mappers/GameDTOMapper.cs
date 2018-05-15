using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class GameDTOMapper
    {
        public GameDTO ToDto(Game domain)
        {
            return new GameDTO()
            {
                Id = domain.Id,
                Time = domain.Time,
                Location = domain.Location,
                HomeTeamId = domain.HomeTeamId,
                AwayTeamId = domain.AwayTeamId,
                SeasonId = domain.SeasonId,
                Date = domain.Date,
                CreatedOnUtc = domain.CreatedOn
            };
        }
    }
}
