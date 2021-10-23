using AutoMapper;
using CorePush.Google;
using HairCutAppAPI.Data;
using HairCutAppAPI.Repositories;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Utilities.Email;
using HairCutAppAPI.Utilities.JWTToken;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HairCutAppAPI.Utilities.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped<ITokenService, TokenService>();
            //Add dbcontext and add connection string
            services.AddDbContext<HDBContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"));
            });

            //Add Repository Wrapper
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

            //Add AutoMapper
            services.AddAutoMapper(typeof(AutoMapperProfiles));
            
            //Add Email Configuration
            var emailConfig = config
                .GetSection("EmailConfiguration")
                .Get<EmailConfiguration>();
            services.AddSingleton(emailConfig);
            services.AddScoped<IEmailSender, EmailSender>();
            
            //For getting the current User Id
            services.AddHttpContextAccessor();
            
            services.AddHttpClient<FcmSender>();

            return services;
        }
    }
}