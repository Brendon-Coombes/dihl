using System;
using System.Threading.Tasks;

namespace DIHL.Client.Core.Services.Contracts
{
    public interface ICacheService
    {
	    Task<T> GetObject<T>(string key);

	    Task<T> GetObjectOrNull<T>(string key) where T : class;

	    Task<T> GetOrFetchObject<T>(string key, Func<Task<T>> fetchFunc, TimeSpan? expiration = null);

	    Task InsertObject<T>(string key, T value, TimeSpan? expiration = null);

	    Task RemoveObject(string key);

		Task Clear();
	}
}
