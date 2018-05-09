using System.Threading.Tasks;
using DIHL.DTOs;

namespace DIHL.Application.Core.Interfaces
{
    public interface ISettingsService
    {
	    Task<SettingDTO> GetSetting(string key, string conditional = null);
    }
}
