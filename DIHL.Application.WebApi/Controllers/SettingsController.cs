using System.Threading.Tasks;
using DIHL.Application.Core.Interfaces;
using DIHL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DIHL.Application.WebApi.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
    public class SettingsController : BaseApiController
    {
	    private readonly ILogger _logger = Log.ForContext<SettingsController>();
		private readonly ISettingsService _settingsService;

	    public SettingsController(ISettingsService settingsService)
	    {
		    _settingsService = settingsService;
	    }

		[HttpGet("{key}/{conditional?}")]
		[ProducesResponseType(typeof(SettingDTO), 200)]
	    public async Task<IActionResult> GetSetting(string key, string conditional = null)
	    {
		    return await Execute(_logger, () => _settingsService.GetSetting(key, conditional));
	    }
    }
}
