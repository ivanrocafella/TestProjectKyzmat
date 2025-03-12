using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.BAL.Extensions
{
    public class TokenValidationMiddleware(RequestDelegate next, IServiceProvider services)
    {
        private readonly RequestDelegate _next = next;
        private readonly IServiceProvider _services = services;
        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                using var scope = _services.CreateScope();
                var tokenRepository = scope.ServiceProvider.GetRequiredService<ITokenRepository>();
                var tokenValue = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                var tokenEntity = await tokenRepository.GetByValueAsyncForRead(tokenValue);
                if (tokenEntity == null || tokenEntity.ExpiresAt < DateTime.UtcNow)
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("Token is invalid or expired");
                    return;
                }
            }
            await _next(context);
        }
    }
}
