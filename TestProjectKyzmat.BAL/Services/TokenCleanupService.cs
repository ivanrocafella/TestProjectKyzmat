using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;
using TestProjectKyzmat.DAL;

namespace TestProjectKyzmat.BAL.Services
{
    public class TokenCleanupService(IServiceProvider services) : BackgroundService
    {
        private readonly IServiceProvider _services = services;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _services.CreateScope();
                var tokenRepository = scope.ServiceProvider.GetRequiredService<ITokenRepository>();
                var expiredTokens = await tokenRepository.GetRange(e => e.ExpiresAt < DateTime.UtcNow).ToListAsync(stoppingToken);

                if (expiredTokens.Count > 0)
                {
                    tokenRepository.RemoveRange(expiredTokens);
                    await tokenRepository.SaveChangesAsync();
                }
                await Task.Delay(TimeSpan.FromMinutes(10), stoppingToken);
            }
        }
    }
}
