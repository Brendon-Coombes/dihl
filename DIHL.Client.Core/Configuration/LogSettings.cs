using Serilog.Events;

namespace DIHL.Client.Core.Configuration
{
	public interface ILogSettings
	{
		RollingFileSettings RollingFile { get; }
		TraceSettings Trace { get; }
		LogEventLevel MinimumEventLevel { get; }
	}

	public class LogSettings : ILogSettings
    {
	    public RollingFileSettings RollingFile { get; }
		public TraceSettings Trace { get; }
		public LogEventLevel MinimumEventLevel { get; }

	    public LogSettings(LogEventLevel minimumEventLevel, RollingFileSettings rollingFileSettings, TraceSettings traceSettings)
	    {
		    MinimumEventLevel = minimumEventLevel;
		    RollingFile = rollingFileSettings;
		    Trace = traceSettings;
	    }
	}
}
