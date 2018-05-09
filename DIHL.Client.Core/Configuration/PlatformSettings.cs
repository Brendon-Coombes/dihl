namespace DIHL.Client.Core.Configuration
{
	public interface IPlatformSettings
	{
		string AppName { get; }
		string AppVersion { get; }
		string ApiBaseAddress { get; }
		int RetryCount { get; }
	}

    public class PlatformSettings : IPlatformSettings
    {
	    public string AppName { get; }
	    public string AppVersion { get; }
	    public string ApiBaseAddress { get; }
	    public int RetryCount { get; }

	    public PlatformSettings(string appName, string appVersion, string apiBaseAddress, int retryCount)
	    {
		    AppName = appName;
		    AppVersion = appVersion;
		    ApiBaseAddress = apiBaseAddress;
		    RetryCount = retryCount;
	    }
    }
}
