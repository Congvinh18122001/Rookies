using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
namespace Middleware
{

    public class Custommiddleware
    {
        private readonly RequestDelegate _next;
        public Custommiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await httpContext.Response.WriteAsync("<h1> Welcome !</h1>");
            await _next(httpContext);
        }
    }


}