using System.Threading.Tasks;
using DIHL.Client.Core.Configuration;
using DIHL.Client.Core.Managers.RepositoryAbstractions;
using DIHL.Client.Core.Services.Contracts;
using Newtonsoft.Json;
using Serilog;

namespace DIHL.Client.Core.Managers
{
	public interface ISettingsManager
	{
		Task<string> GetSetting(string key, string conditional = null);

		Task<T> GetSettingAs<T>(string key, string conditional = null);
	}

	public class SettingsManager : ManagerBase, ISettingsManager
	{
		private readonly ILogger _logger = Log.ForContext<SettingsManager>();
		private readonly ISettingsSource _settingsSource;

		public SettingsManager(IPlatformSettings platformSettings, IConnectionService connectionService, ICacheService cacheService, ISettingsSource settingsSource) : base(platformSettings, connectionService, cacheService)
		{
			_settingsSource = settingsSource;
		}

		public async Task<string> GetSetting(string key, string conditional = null)
		{
			var setting = await ExecuteGet(_logger, key, async () => await _settingsSource.GetSetting(key, conditional));
			return setting?.Value;
		}

		public async Task<T> GetSettingAs<T>(string key, string conditional = null)
		{
			var value = await GetSetting(key, conditional);
			if (value == null) return default(T);
			return JsonConvert.DeserializeObject<T>(value);
		}
	}
}
