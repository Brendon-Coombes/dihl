using System;

namespace DIHL.Application.Core.Exceptions
{
    public interface ICorrelationException
    {
        Guid CorrelationId { get; }
    }
}
