using Serilog.Events;

namespace DIHL.Client.Core.Configuration
{
	public abstract class BaseLogSinkSettings
	{
		public bool IsEnabled { get; set; }
		public LogEventLevel MinimumEventLevel { get; set; }

		protected BaseLogSinkSettings(bool isEnabled, LogEventLevel logMinimumEventLevel)
		{
			IsEnabled = isEnabled;
			MinimumEventLevel = logMinimumEventLevel;
		}
	}

	public class RollingFileSettings : BaseLogSinkSettings
	{
		public string PathFormat { get; set; }

		public RollingFileSettings(bool isEnabled, LogEventLevel minimumEventLevel, string pathFormat) : base(isEnabled, minimumEventLevel)
		{
			PathFormat = pathFormat;
		}
	}

	public class TraceSettings : BaseLogSinkSettings
	{
		public TraceSettings(bool isEnabled, LogEventLevel logLevel) : base(isEnabled, logLevel)
		{
		}
	}
}
