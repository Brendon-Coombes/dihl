using DIHL.Domain;
using DIHL.Domain.Aggregates;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class SeasonFactory
    {
        public Season CreateDomainObject(SeasonDTO dto)
        {
            return new Season(dto.Id, dto.Name, dto.CreatedOn, dto.Year, dto.LeagueId);
        }
    }
}
