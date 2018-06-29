using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DIHL.Application.Identity.Models;
using DIHL.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;

namespace DIHL.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _log = Log.ForContext<AccountController>();

        public AccountController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(WhoAmIDTO), 200)]
        public async Task<IActionResult> WhoAmI()
        {
            //TODO: This doesn't work -- find out how to get logged in user.
            _log.Information($"WhoAmI requested");

            var test = await _userManager.GetUserAsync(this.User);

            ClaimsPrincipal currentUser = this.User;
            Claim email = currentUser.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email);

            WhoAmIDTO dtoUser = new WhoAmIDTO()
            {
                UserName = currentUser.Identity.Name,
                Email = email != null ? email.Value : string.Empty
            };

            return Ok(dtoUser);           
        }
    }
}
