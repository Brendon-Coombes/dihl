using System;

namespace DIHL.Client.Core.Exceptions
{
    public class CustomException : Exception
    {
        public Guid CorrelationId { get; }

        public CustomException(string message = null, Exception innerException = null, Guid? correlationId = null) : base(message, innerException)
        {
            CorrelationId = correlationId ?? Guid.NewGuid();
        }
    }
}
