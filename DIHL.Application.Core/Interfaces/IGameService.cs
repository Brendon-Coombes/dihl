using DIHL.DTOs;

namespace DIHL.Application.Core.Interfaces
{
    /// <summary>
    /// Responsible for exposing functionality to allow CRUD operations of the game data store.
    /// </summary>
    public interface IGameService : IService<GameDTO>
    {        
    }
}
