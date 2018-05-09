using System;
using System.Threading.Tasks;
using DIHL.Client.Core.Configuration;
using DIHL.Client.Core.Exceptions;
using DIHL.Client.Core.Services.Contracts;
using DIHL.DTOs;
using Polly;
using Refit;
using Serilog;

namespace DIHL.Client.Core.Managers
{
    public abstract class ManagerBase
    {
	    private readonly IPlatformSettings _platformSettings;
	    private readonly IConnectionService _connectionService;
	    private readonly ICacheService _cacheService;

		protected ManagerBase(IPlatformSettings platformSettings, IConnectionService connectionService, ICacheService cacheService)
		{
			_platformSettings = platformSettings;
			_connectionService = connectionService;
			_cacheService = cacheService;
		}

	    protected async Task<T> ExecuteGet<T>(ILogger logger, string key, Func<Task<T>> operation, TimeSpan? expiry = null, bool forceRefresh = false) where T : new()
	    {
		    if (!_connectionService.IsConnected)
		    {
			    logger.Error("No Active Connection");
			    throw new Exception("No Internet Connection available, check settings and retry");
		    }

		    try
		    {
			    async Task<T> FetchFunc() => await Policy
				    .Handle<ApiException>()
				    .RetryAsync(_platformSettings.RetryCount, (exception, retryCount) => logger.Error(exception, $"Retry failed {retryCount}"))
				    .ExecuteAsync(async () => await operation());

				if (forceRefresh) await _cacheService.RemoveObject(key);
				return await _cacheService.GetOrFetchObject(key, FetchFunc, expiry);
		    }
		    catch (ApiException e)
		    {
			    var statusCode = (int) e.StatusCode;
			    if (statusCode == 404 || statusCode == 520)
			    {
				    var errorDto = e.GetContentAs<ApiErrorDTO>();
				    throw new CustomException(errorDto.Message, correlationId: errorDto.CorrelationId);
			    }
			    throw new CustomException(e.Message);
		    }
	    }

	    protected async Task<bool> ExecutePost(ILogger logger, Func<Task<bool>> operation)
	    {
		    if (!_connectionService.IsConnected)
		    {
			    logger.Error("No Active Connection");
			    throw new Exception("No Internet Connection available, check settings and retry");
		    }

		    try
		    {
			    return await Policy
				    .Handle<ApiException>()
				    .RetryAsync(_platformSettings.RetryCount, (exception, retryCount) => logger.Error(exception, $"Retry failed {retryCount}"))
				    .ExecuteAsync(async () => await operation());
		    }
		    catch (ApiException e)
		    {
			    var statusCode = (int)e.StatusCode;
			    if (statusCode == 404 || statusCode == 520)
			    {
				    var errorDto = e.GetContentAs<ApiErrorDTO>();
				    throw new CustomException(errorDto.Message, correlationId: errorDto.CorrelationId);
			    }
			    throw new CustomException(e.Message);
		    }
	    }
	}
}
