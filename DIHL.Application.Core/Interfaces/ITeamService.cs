using DIHL.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DIHL.Application.Core.Interfaces
{
    /// <summary>
    /// Responsible for exposing functionality to allow CRUD operations of the player data store.
    /// </summary>
    public interface ITeamService : IService<TeamDTO>
    {
    }
}
