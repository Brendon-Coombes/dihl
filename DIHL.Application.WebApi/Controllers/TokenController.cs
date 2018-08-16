using DIHL.DTOs;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using DIHL.Application.Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace DIHL.Application.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Token")]
    public class TokenController : BaseApiController
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger _log = Log.ForContext<TokenController>();

        public TokenController(IConfiguration configuration, UserManager<ApplicationUser> userManager)
        {
            _configuration = configuration;
            _userManager = userManager;
        }

        /// <summary>
        /// Logs in a user and provides them with a token to use the authorized endpoints
        /// </summary>
        /// <param name="authenticationRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]        
        public async Task<IActionResult> Login([FromBody] AuthenticationRequestDTO authenticationRequest)
        {
            _log.Information($"Token requested for {authenticationRequest.UserName}");

            var user = await _userManager.FindByEmailAsync(authenticationRequest.UserName);

            if (user != null)
            {
                bool checkPassword = await _userManager.CheckPasswordAsync(user, authenticationRequest.Password);

                if (checkPassword)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Email, user.Email)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                        _configuration["Jwt:Issuer"],
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: credentials);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
            }

            return BadRequest("Could not create token");
        }
    }
}
