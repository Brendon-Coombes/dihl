using System;

namespace DIHL.Domain.Aggregates
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}
