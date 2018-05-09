using System.Threading.Tasks;
using DIHL.DTOs;
using Refit;

namespace DIHL.Client.WebApiRepository.Clients
{
    public interface ISettingsApiClient
    {
	    [Get("/settings/{key}/{conditional?}")]
	    Task<SettingDTO> GetSetting(string key, string conditional = null);
	}
}
