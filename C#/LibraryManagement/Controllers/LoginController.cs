using System.Text;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
namespace LibraryManagement.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILoginService _service;
        private readonly IConfiguration _configuration;
        public LoginController(ILoginService service,IConfiguration configuration)
        {
            _service = service;
            _configuration=configuration;
        }

        [Route("/loginFail")]
        public IActionResult Unauthorize()
        {
            return Unauthorized();
        }
        [HttpPost]
        public ActionResult Post([FromBody] AccountVM userLoginRequest)
        {
            if (userLoginRequest == null)
            {
                return BadRequest("Request is not valid !");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Validation Error !");
            }
            User getUserLogin = _service.Login(userLoginRequest.Username, userLoginRequest.Password);
            if (getUserLogin != null)
            {
                var authClaims = new List<Claim>
                {
                    new Claim("username", getUserLogin.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("role", getUserLogin.Role.Name),
                };

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])) ;
                var token = new JwtSecurityToken(
                    issuer : _configuration["JWT:ValidIssuer"],
                    audience : _configuration["JWT:ValidAudience"],
                    expires : DateTime.Now.AddHours(1),
                    claims : authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey,SecurityAlgorithms.HmacSha256)
                );
                AccountVM accountReturn = new AccountVM{
                     ID = getUserLogin.ID,
                     Username=getUserLogin.Username,
                     RoleID = getUserLogin.RoleID
                };
                return Ok(new {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo,
                    user = accountReturn
                });
            }
            return NotFound("Username or Password is incorrect !");
        }

        [HttpPost]
        [Route("/api/logout")]
        public IActionResult Logout()
        {
            return Ok();
        }

    }
}