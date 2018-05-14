using DIHL.Domain;
using DIHL.Domain.Aggregates;
using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class PlayerDTOMapper
    {
        public PlayerDTO ToDto(Player domain)
        {
            return new PlayerDTO()
            {
                Id = domain.Id,
                FirstName = domain.FirstName,
                LastName = domain.LastName,
                CreatedOn = domain.CreatedOn,
            };
        }
    }
}
