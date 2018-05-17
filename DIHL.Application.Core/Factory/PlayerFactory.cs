using DIHL.Domain.Models;
using DIHL.DTOs;

namespace DIHL.Application.Core.Factory
{
    public class PlayerFactory
    {
        public Player CreateDomainObject(PlayerDTO dto)
        {
            return new Player(dto.Id, dto.FirstName, dto.LastName, dto.CreatedOn);
        }
    }
}
