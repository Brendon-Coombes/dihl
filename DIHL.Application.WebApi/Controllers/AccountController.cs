using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DIHL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace DIHL.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : BaseApiController
    {
        private readonly ILogger _log = Log.ForContext<AccountController>();

        /// <summary>
        /// Returns the currently logged in user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(WhoAmIDTO), 200)]
        public async Task<IActionResult> WhoAmI()
        {
            _log.Information($"WhoAmI requested");

            ClaimsPrincipal currentUser = this.User;
            Claim email = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            WhoAmIDTO dtoUser = new WhoAmIDTO()
            {
                UserName = currentUser.Identity.Name,
                Email = email?.Value
            };

            return Ok(dtoUser);           
        }
    }
}
