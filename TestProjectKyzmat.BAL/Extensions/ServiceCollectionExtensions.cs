using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.BAL.Services;
using TestProjectKyzmat.BAL.Services.Interfaces;
using TestProjectKyzmat.BAL.Services.JwtFeatures;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;
using TestProjectKyzmat.DAL;
using TestProjectKyzmat.DAL.Repositories;

namespace TestProjectKyzmat.BAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDatabaseContext(configuration);
            services.AddRepositories();
            services.AddScoped<JwtHandler>();
            services.AddServices();
            return services;
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }

        public static void AddDatabaseContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"));
            });
        }

        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddHostedService<TokenCleanupService>();
        }
    }
}
