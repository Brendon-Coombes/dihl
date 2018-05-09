using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Akavache;
using DIHL.Client.Core.Configuration;
using DIHL.Client.Core.Services.Contracts;
using Serilog;

namespace DIHL.Client.Core.Services
{
    public class CacheService : ICacheService
    {
	    private readonly ILogger _logger = Log.ForContext<CacheService>();

		private ISecureBlobCache Cache => BlobCache.InMemory;

	    public CacheService(IPlatformSettings platformSettings)
	    {
		    BlobCache.ApplicationName = platformSettings.AppName;
	    }

		public async Task<T> GetObject<T>(string key)
	    {
		    try
		    {
			    return await Cache.GetObject<T>(key);
		    }
		    catch (KeyNotFoundException error)
		    {
			    _logger.Error(error, "An error occurred during GetObject");
			    throw;
		    }
		}

	    public async Task<T> GetObjectOrNull<T>(string key) where T : class
	    {
			try
			{
				return await Cache.GetObject<T>(key);
			}
			catch (KeyNotFoundException)
			{
				return null;
			}
		}

	    public async Task<T> GetOrFetchObject<T>(string key, Func<Task<T>> fetchFunc, TimeSpan? expiration = null)
	    {
		    var expirationTime = expiration == null ? null : DateTimeOffset.Now + expiration;
			return await Cache.GetOrFetchObject(key, fetchFunc, expirationTime);
	    }

	    public async Task InsertObject<T>(string key, T value, TimeSpan? expiration = null)
	    {
		    if (expiration == null) await Cache.InsertObject(key, value);
		    else await Cache.InsertObject(key, value, expiration.Value);
	    }

	    public async Task RemoveObject(string key)
	    {
		    await Cache.Invalidate(key);
	    }

	    public async Task Clear()
	    {
		    await Cache.InvalidateAll();
	    }
    }
}
