using System;

namespace DIHL.Domain.Models
{
    public interface ISimpleModel : IModelRoot
    {
        Guid Id { get; }
    }
}
