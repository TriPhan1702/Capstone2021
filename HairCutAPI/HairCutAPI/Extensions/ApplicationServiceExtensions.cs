using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HairCutAPI.Data;
using HairCutAPI.Interfaces;
using HairCutAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HairCutAPI.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            //Inject dbcontext and add connection string
            services.AddDbContext<HDBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
