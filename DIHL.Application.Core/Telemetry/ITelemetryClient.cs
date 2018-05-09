using System.Collections.Generic;

namespace DIHL.Application.Core.Telemetry
{
    public interface ITelemetryClient
    {
        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);
    }
}
