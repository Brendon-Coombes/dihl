using DIHL.Application.Core.Utilities;

namespace DIHL.Application.Core.Services
{
    /// <summary>
    /// Provides base methods for Service classes
    /// </summary>
    public abstract class ServiceBase
    {
	    protected ServiceBase(IActionHandler handler)
        {
            Handler = handler;
        }

        protected IActionHandler Handler { get; }
    }
}
