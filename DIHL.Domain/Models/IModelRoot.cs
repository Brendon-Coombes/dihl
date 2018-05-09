using System;

namespace DIHL.Domain.Aggregates
{
    public interface IModelRoot
    {
        Guid Id { get; }
    }
}
