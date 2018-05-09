using System;

namespace DIHL.Application.Core.Exceptions
{
    public class CoreApplicationException : Exception, ICorrelationException
    {
        public CoreApplicationException(Exception ex)
            : base($"An unexpected internal application error occurred.", ex)
        {
            CorrelationId = ex is ICorrelationException correlationException
                ? correlationException.CorrelationId
                : Guid.NewGuid();
        }

        public Guid CorrelationId { get; }
    }    
}
