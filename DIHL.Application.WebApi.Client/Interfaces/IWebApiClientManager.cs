using DIHL.Client.WebApiRepository.Clients;

namespace DIHL.Client.WebApiRepository.Interfaces
{
    public interface IWebApiClientManager
    {
        ILeagueApi GetLeagueApiClient();

	    ISettingsApiClient GetSettingsApiClient();
    }
}
