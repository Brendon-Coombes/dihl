using DIHL.Client.WebApiRepository.Clients;
using DIHL.Client.WebApiRepository.Interfaces;
using Refit;

namespace DIHL.Client.WebApiRepository
{
    public class WebApiClientManager : IWebApiClientManager
    {
        private readonly string _apiBaseEndpoint;

        public WebApiClientManager(string apiBaseEndpoint)
        {
            _apiBaseEndpoint = apiBaseEndpoint;
        }

        public ILeagueApi GetLeagueApiClient()
        {
            return RestService.For<ILeagueApi>(_apiBaseEndpoint);
        }

	    public ISettingsApiClient GetSettingsApiClient()
	    {
		    return RestService.For<ISettingsApiClient>(_apiBaseEndpoint);
	    }
    }
}
