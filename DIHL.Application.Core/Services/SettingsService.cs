using System.Threading.Tasks;
using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Exceptions;
using DIHL.Application.Core.Interfaces;
using DIHL.Application.Core.Utilities;
using DIHL.DTOs;
using Serilog;

namespace DIHL.Application.Core.Services
{
    public class SettingsService : ServiceBase, ISettingsService
    {
	    private readonly ILogger _logger = Log.ForContext<SettingsService>();
	    private readonly ISettingsRepository _settingsRepository;

		public SettingsService(IActionHandler handler, ISettingsRepository settingsRepository) : base(handler)
		{
			_settingsRepository = settingsRepository;
		}

	    public async Task<SettingDTO> GetSetting(string key, string conditional = null)
	    {
		    return await Handler.Execute(_logger, async () =>
		    {
			    var result = await _settingsRepository.GetSetting(key, conditional);
			    return result ?? throw new RecordNotFoundException("Settings", $"{key} {conditional}");
			});
	    }
    }
}
