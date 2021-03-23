using Microsoft.AspNetCore.Builder;

namespace Middleware
{

    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustommiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Custommiddleware>();
        }
      
    }
}