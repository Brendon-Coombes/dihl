using System;
using System.Linq;
using System.Threading.Tasks;
using DIHL.Application.Abstractions.Repositories;
using DIHL.Application.Core.Utilities;
using DIHL.DTOs;
using DIHL.Repository.Sql.Database;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace DIHL.Repository.Sql.Repositories
{
    public class SettingsRepository : ISettingsRepository
    {
		private readonly ILogger _logger = Log.ForContext<SettingsRepository>();
		private readonly IActionHandler _handler;
	    private readonly DihlDbContext _context;

	    public SettingsRepository(IActionHandler handler, DihlDbContext dbContext)
	    {
		    _handler = handler;
		    _context = dbContext;
	    }

	    public async Task<SettingDTO> GetSetting(string key, string conditional = null)
	    {
		    conditional = conditional ?? string.Empty;

		    var query = _context.Settings.AsQueryable();
		    var result = await _handler.Execute(_logger, () => query.Where(s =>
					s.Key.Equals(key, StringComparison.OrdinalIgnoreCase) &&
					(s.Conditional.Equals(conditional, StringComparison.OrdinalIgnoreCase) || s.Conditional.Equals(string.Empty)))
					.OrderByDescending(_ => _.Conditional).FirstOrDefaultAsync());

			return new SettingDTO
			{
				Key = result.Key,
				Value = result.Value
			};
		}
    }
}
