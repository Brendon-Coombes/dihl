using DIHL.Client.Core.Services.Contracts;
using Plugin.Connectivity;

namespace DIHL.Client.Core.Services
{
    public class ConnectionService : IConnectionService
    {
	    public bool IsConnected => CrossConnectivity.Current.IsConnected;
    }
}
