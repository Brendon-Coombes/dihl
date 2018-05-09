using DIHL.Domain;
using DIHL.Domain.Aggregates;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class LeagueFactory
    {
        public League CreateDomainObject(LeagueDTO dto)
        {
            return new League(dto.Id, dto.Name, dto.CreatedOn, (int)dto.Tier);
        }
    }
}
