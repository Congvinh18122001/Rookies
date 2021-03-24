using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
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
            var sw = new Stopwatch();
            sw.Start();
            var name = httpContext.Request.Query["name"];

            if (!String.IsNullOrWhiteSpace(name) )
            {
                httpContext.Request.Headers.Add("name",name);
            }
            await httpContext.Response.WriteAsync($"<p>{httpContext.Request.Path} {httpContext.Request.QueryString}</p>");
            await httpContext.Response.WriteAsync($"<h1> {name} </h1><h2>{sw.ElapsedMilliseconds}</h2>");
            await _next(httpContext);
        }
    }


}