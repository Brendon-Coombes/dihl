using System;

namespace DIHL.Application.Core.Exceptions
{
    public class ConnectedServiceException : Exception, ICorrelationException
    {
        public ConnectedServiceException(string serviceName, Exception exception)
            : base($"An unexpected error occurred in '{serviceName}'.", exception)
        {
            ServiceName = serviceName;

            CorrelationId = exception is ICorrelationException correlationException
                ? correlationException.CorrelationId
                : Guid.NewGuid();
        }

        public string ServiceName { get; }

        public Guid CorrelationId { get; }
    }
}
