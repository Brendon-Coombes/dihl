using DIHL.Domain;
using DIHL.Domain.Aggregates;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class LeagueDTOMapper
    {
        public LeagueDTO ToDto(League domain)
        {
            return new LeagueDTO()
            {
                Id = domain.Id,
                Name = domain.Name,
                CreatedOn = domain.CreatedOn,
                Tier = domain.Tier
            };
        }
    }
}
