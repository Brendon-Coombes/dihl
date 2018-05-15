using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class GameFactory
    {
        public Game CreateDomainObject(GameDTO dto)
        {
            return new Game(dto.Id, dto.Location, dto.Date, dto.Time, dto.HomeTeamId, dto.AwayTeamId, dto.SeasonId, dto.CreatedOnUtc);
        }
    }
}
