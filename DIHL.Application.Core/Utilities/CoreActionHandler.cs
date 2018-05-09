using DIHL.Application.Core.Exceptions;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DIHL.Application.Core.Utilities
{
    public class CoreActionHandler : IActionHandler
    {
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
            catch (ConnectedServiceException ex)
            {
                log.Error(ex, ex.Message);
                throw;
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

            //todo confirm that this still returns the inner exceptions stack trace.
            var wrappedException = new CoreApplicationException(ex);
            log.Error(wrappedException, ex.Message);

            throw wrappedException;
        }
    }
}
