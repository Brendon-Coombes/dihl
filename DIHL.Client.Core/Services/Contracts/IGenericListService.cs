using System.Collections.Generic;
using System.Threading.Tasks;
using DIHL.Client.Core.Domain;

namespace DIHL.Client.Core.Services.Contracts
{
    public interface IGenericListService
    {
        Task<IEnumerable<ChristmasPresent>> GetChristmasPresentsAsync();
    }
}
