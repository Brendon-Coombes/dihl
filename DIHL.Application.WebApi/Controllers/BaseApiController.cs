using DIHL.Application.Core.Exceptions;
using DIHL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DIHL.Application.WebApi.Controllers
{
    public class BaseApiController : Controller
    {
        public BaseApiController()
        {
        }

        protected async Task<IActionResult> Execute<T>(ILogger log, Func<Task<T>> operation)
        {
            try
            {
                var result =  await operation();
                return Ok(result);
            }
            catch (RecordNotFoundException ex)
            {
                return StatusCode(404, JsonConvert.SerializeObject(BuildErrorObject(log, ex)));
            }
            catch (Exception ex)
            {
                return StatusCode(520, JsonConvert.SerializeObject(BuildErrorObject(log, ex)));
            }
        }

        private ApiErrorDTO BuildErrorObject(ILogger log, Exception ex)
        {
            ApiErrorDTO errorDto = new ApiErrorDTO();


            if (ex is IPassthroughException passThroughException)
            {
                errorDto.Message = passThroughException.DisplayMessage;
                log.Warning(ex, ex.Message);
                return errorDto;
            }

            errorDto.Message = ex.Message;

            if (ex is ICorrelationException correlationException)
            {
                errorDto.CorrelationId = correlationException.CorrelationId;
            }

            log.Error(ex, errorDto.Message);

#if DEBUG
            errorDto.StackTrace = ex.ToString();
#endif

            return errorDto;
        }
    }
}
