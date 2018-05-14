using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class PenaltyFactory
    {
        public Penalty CreateDomainObject(PenaltyDTO dto)
        {
            return new Penalty(dto.Id, dto.PlayerId, dto.TeamId, dto.GameId, dto.Period, dto.Time, (int)dto.PenaltyType, dto.Length, dto.PowerPlaySuccessful, dto.CreatedOn);
        }
    }
}
