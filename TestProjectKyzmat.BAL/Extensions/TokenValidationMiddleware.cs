using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;

namespace TestProjectKyzmat.BAL.Extensions
{
    public class TokenValidationMiddleware(RequestDelegate next, ITokenRepository tokenRepository)
    {
        private readonly RequestDelegate _next = next;
        private readonly ITokenRepository _tokenRepository = tokenRepository;

        public async Task InvokeAsync(HttpContext context)
        {
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var tokenValue = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", string.Empty);
                var tokenEntity = await _tokenRepository.GetByValueAsync(tokenValue);
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
