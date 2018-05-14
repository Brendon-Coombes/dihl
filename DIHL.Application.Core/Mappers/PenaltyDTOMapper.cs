using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class PenaltyDTOMapper
    {
        public PenaltyDTO ToDto(Penalty domain)
        {
            return new PenaltyDTO()
            {
                Id = domain.Id,
                GameId = domain.GameId,
                PlayerId = domain.PlayerId,
                TeamId = domain.TeamId,
                PenaltyType = domain.PenaltyType,
                Period = domain.Period,
                Length = domain.Length,
                PowerPlaySuccessful = domain.PowerPlaySuccessful,
                Time = domain.Time,
                CreatedOn = domain.CreatedOn,
            };
        }
    }
}
