using System;
using System.Collections.Generic;
using System.Text;
using DIHL.Domain.Aggregates;
using DIHL.DTOs;

namespace DIHL.Application.Core.Mappers
{
    public class SeasonDTOMapper
    {
        public SeasonDTO ToDto(Season domain)
        {
            return new SeasonDTO
            {
                Id = domain.Id,
                Name = domain.Name,
                CreatedOn = domain.CreatedOn,
                Year = domain.Year,
                LeagueId = domain.LeagueId
            };
        }
    }
}
