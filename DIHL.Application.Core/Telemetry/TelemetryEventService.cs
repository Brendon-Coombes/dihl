using System.Collections.Generic;
using System.Diagnostics;

namespace DIHL.Application.Core.Telemetry
{
    public class TelemetryEventService : ITelemetryEventService
    {
        private Dictionary<string, Stopwatch> _timers;
        private readonly ITelemetryClient _telemetryClient;

        private enum EventNames
        {
            LeaguesListTiming
        }

        public TelemetryEventService(ITelemetryClient telemetryClient)
        {
            _timers = new Dictionary<string, Stopwatch>();
            _telemetryClient = telemetryClient;

        }

        public void StartListLeaguesTimer()
        {
            this.RestartTimer(EventNames.LeaguesListTiming.ToString());
        }

        public void CompleteListLeaguesTimer(int? recordCount = null)
        {
            var elapsed = this.GetElapsedMilliseconds(EventNames.LeaguesListTiming.ToString());

            var properties = BuildProperties();

            var metrics = BuildMetrics(elapsed);
            if (recordCount.HasValue)
                metrics.Add("Records Found", recordCount.Value);

            _telemetryClient.TrackEvent(EventNames.LeaguesListTiming.ToString(), properties, metrics);
        }

        private Stopwatch GetTimer(string key)
        {
            if (_timers.TryGetValue(key, out var stopwatch))
            {
                return stopwatch;
            }
            else
            {
                Stopwatch newTimer = new Stopwatch();
                _timers.Add(key, newTimer);
                return newTimer;
            }
        }

        private void RestartTimer(string key)
        {
            var stopwatch = GetTimer(key);
            stopwatch.Restart();
        }

        private double GetElapsedMilliseconds(string key)
        {
            var stopwatch = GetTimer(key);
            stopwatch.Stop();
            return stopwatch.ElapsedMilliseconds;
        }

        private Dictionary<string, string> BuildProperties()
        {
            var properties = new Dictionary<string, string>();
            properties.Add("DIHL-event", "DIHL-event");
            return properties;
        }

        private Dictionary<string, double> BuildMetrics(double? elapsedMilliseconds = null)
        {
            var metrics = new Dictionary<string, double>();
            if (elapsedMilliseconds != null)
                metrics.Add("Elapsed Milliseconds", elapsedMilliseconds.Value);
            return metrics;
        }
    }
}
