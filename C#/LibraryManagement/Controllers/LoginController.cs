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
namespace LibraryManagement.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        static readonly HttpClient client = new HttpClient();
        private readonly ILoginService _service;
        public LoginController(ILoginService service)
        {
            _service = service;
        }

        [Route("/loginFail")]
        public IActionResult Unauthorize()
        {
            return Unauthorized();
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AccountVM userLoginRequest)
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
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, getUserLogin.Username),
                    new Claim("Password", getUserLogin.Password),
                    new Claim(ClaimTypes.Role, getUserLogin.Role.Name),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddHours(24),
                    IsPersistent = true,

                };

                HttpContext.Request.Headers.Add("cookies", CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return Ok(getUserLogin);
            }
            return NotFound("Username or Password is incorrect !");
        }

        [HttpPost]
        [Route("/api/logout")]
        public async System.Threading.Tasks.Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

    }
}