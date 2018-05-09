using DIHL.Application.Core.Exceptions;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DIHL.Application.Core.Utilities
{
    //todo unit test.

    public class ConnectedServiceActionHandler : IActionHandler
    {
        public string ServiceName { get; }

        public ConnectedServiceActionHandler(string serviceName)
        {
            ServiceName = serviceName;
        }

        /// <summary>
        /// Executes a given operation, wraps or passes through exceptions based on their type
        /// </summary>
        /// <param name="log"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public async Task<T> Execute<T>(ILogger log, Func<Task<T>> operation)
        {
            try
            {
                return await operation();
            }
            catch (Exception ex)
            {
                RethrowWrappedException(log, ex);

                throw;
            }
        }

        public async Task Execute(ILogger log, Func<Task> operation)
        {
            //route this through ExecutionAsync<T> with a boolean result.
            await this.Execute(log, async () =>
            {
                await operation();
                return true;
            });
        }

        private void RethrowWrappedException(ILogger log, Exception ex)
        {
            if (ex is IPassthroughException)
                return;

            var wrappedException = new ConnectedServiceException(ServiceName, ex);
            log.Error(wrappedException, ex.Message);

            throw wrappedException;
        }
    }
}
