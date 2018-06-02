using System.Threading.Tasks;
using DIHL.Data.Dataloader.Models;

namespace DIHL.Data.Dataloader.Facade
{
    public interface IServiceFacade
    {
        Task SaveGameInformation(GamePageInformation gameInfo);
    }
}
