using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectKyzmat.Core.Entities.Common.Interfaces;
using TestProjectKyzmat.DAL.Repositories;

namespace TestProjectKyzmat.BAL.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<IPaymentRepository, PaymentRepository>();
        }
    }
}
