using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Routing;
using Microsoft.Net.Http.Headers;


namespace LibraryManagement.Fillter
{
    public class AuthorizeActionFilter : IAuthorizationFilter
    {
        private readonly string _role;
        public AuthorizeActionFilter(string role)
        {
            this._role = role;
        }
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.Request.Headers["Authorization"].Any())
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var token = context.HttpContext.Request.Headers["Authorization"].FirstOrDefault();
            if (string.IsNullOrEmpty(token))
            {
                context.Result = new UnauthorizedResult();
                return;
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(token);
            var tokenS = jsonToken as JwtSecurityToken;
            var role = tokenS.Claims.First(claim => claim.Type == "role").Value;
            var expiration = tokenS.Claims.First(claim => claim.Type == "exp").Value;

            if (DateTimeOffset.Now.ToUnixTimeSeconds() > long.Parse(expiration))
            {
                context.Result = new JsonResult(new { message = "Can't use token", status = 410 }) { StatusCode = 410 };
                return;
            }
            if (_role != role) {
                //context.Result = new ForbidResult();
                context.Result = new JsonResult( new { message = "You don't have permission to access !!!", status = 403 }) { StatusCode = (int)HttpStatusCode.Forbidden };

                return;
            }
        }
    }
}