using System.Threading.Tasks;
using DIHL.Client.Core.Managers.RepositoryAbstractions;
using DIHL.Client.WebApiRepository.Clients;
using DIHL.Client.WebApiRepository.Interfaces;
using DIHL.DTOs;

namespace DIHL.Client.WebApiRepository.Wrappers
{
    public class SettingsWrapper : ISettingsSource
    {
	    private readonly ISettingsApiClient _settingsApiClient;

		public SettingsWrapper(IWebApiClientManager webApiClientManager)
		{
			_settingsApiClient = webApiClientManager.GetSettingsApiClient();
		}

		public async Task<SettingDTO> GetSetting(string key, string conditional = null)
		{
			return await _settingsApiClient.GetSetting(key, conditional);
		}
	}
}
