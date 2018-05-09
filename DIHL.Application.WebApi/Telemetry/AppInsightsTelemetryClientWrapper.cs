using System.Collections.Generic;
using DIHL.Application.Core.Telemetry;
using Microsoft.ApplicationInsights;

namespace DIHL.Application.WebApi.Telemetry
{
    public class AppInsightsTelemetryClientWrapper : ITelemetryClient
    {
        private readonly TelemetryClient _appInsightsTelemetryClient;

        public AppInsightsTelemetryClientWrapper(TelemetryClient appInsightsTelemetryClient)
        {
            _appInsightsTelemetryClient = appInsightsTelemetryClient;
        }

        public void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null)
        {
            _appInsightsTelemetryClient.TrackEvent(eventName, properties, metrics);
        }
    }
}
