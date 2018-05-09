using System.Threading.Tasks;
using DIHL.DTOs;

namespace DIHL.Client.Core.Managers.RepositoryAbstractions
{
    public interface ISettingsSource
    {
	    Task<SettingDTO> GetSetting(string key, string conditional = null);
	}
}
