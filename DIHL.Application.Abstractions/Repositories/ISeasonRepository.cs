using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Domain;
using DIHL.Domain.Aggregates;

namespace DIHL.Application.Abstractions.Repositories
{
    /// <summary>
    /// The season repository is responsible for operations that act on an season
    /// </summary>
    public interface ISeasonRepository : IRepository<Season>
    {
        
    }
}
