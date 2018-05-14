using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class TeamDTOMapper
    {
        public TeamDTO ToDto(Team domain)
        {
            return new TeamDTO
            {
                Id = domain.Id,
                Name = domain.Name,
                LeagueId = domain.LeagueId,
                CreatedOn = domain.CreatedOn,
            };
        }
    }
}
