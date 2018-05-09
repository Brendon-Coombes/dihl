
namespace DIHL.Application.Core.Telemetry
{
    public interface ITelemetryEventService
    {
        void StartListLeaguesTimer();
        void CompleteListLeaguesTimer(int? recordCount = null);
    }
}
