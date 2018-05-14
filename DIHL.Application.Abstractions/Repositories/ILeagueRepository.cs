using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Domain;
using DIHL.Domain.Aggregates;
using DIHL.Domain.Models;

namespace DIHL.Application.Abstractions.Repositories
{
    /// <summary>
    /// The league repository is responsible for operations that act on an league
    /// </summary>
    public interface ILeagueRepository : IRepository<League>
    {
       
    }
}
