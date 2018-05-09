using Serilog;
using System;
using System.Threading.Tasks;

namespace DIHL.Application.Core.Utilities
{
    public interface IActionHandler
    {
        Task<T> Execute<T>(ILogger log, Func<Task<T>> operation);

        Task Execute(ILogger log, Func<Task> operation);
    }
}
