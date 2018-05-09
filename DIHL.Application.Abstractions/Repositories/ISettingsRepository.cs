using System.Threading.Tasks;
using DIHL.DTOs;

namespace DIHL.Application.Abstractions.Repositories
{
    public interface ISettingsRepository
    {
	    Task<SettingDTO> GetSetting(string key, string conditional = null);
	}
}
