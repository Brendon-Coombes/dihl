using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class TeamFactory
    {
        public Team CreateDomainObject(TeamDTO dto)
        {
            return new Team(dto.Id, dto.Name, dto.ShortCode, dto.LeagueId, dto.CreatedOn);
        }
    }
}
