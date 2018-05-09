using Serilog.Events;

namespace DIHL.Application.WebApi.Config
{
    public class SerilogConfig
    {
        public LogEventLevel MinimumLevel { get; set; }
        public RollingFileConfig RollingFile { get; set; }
        public TraceConfig Trace { get; set; }
        public AppInsightsConfig AppInsights { get; set; }
    }

    public abstract class LogConfigBase
    {
        public bool IsEnabled { get; set; }
        public LogEventLevel Level { get; set; }
    }

    public class RollingFileConfig : LogConfigBase
    {
        public string Folder { get; set; }
    }

    public class TraceConfig : LogConfigBase
    {
    }

    public class AppInsightsConfig : LogConfigBase
    {
        public string Key { get; set; }
    }

}
