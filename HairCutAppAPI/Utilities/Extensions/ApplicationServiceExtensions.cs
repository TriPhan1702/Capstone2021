using AutoMapper;
using CorePush.Google;
using HairCutAppAPI.Data;
using HairCutAppAPI.Repositories;
using HairCutAppAPI.Repositories.Interfaces;
using HairCutAppAPI.Services;
using HairCutAppAPI.Services.Interfaces;
using HairCutAppAPI.Utilities.Email;
using HairCutAppAPI.Utilities.JWTToken;
using Hangfire;
using Hangfire.MemoryStorage;
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
            
            //For sending Firebase notification
            services.AddHttpClient<FcmSender>();
            
            //For running background tasks
            services.AddHangfire(configuration =>
                configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
                    .UseSimpleAssemblyNameTypeSerializer().UseDefaultTypeSerializer().UseMemoryStorage());

            services.AddHangfireServer();

            services.AddScoped<IBackgroundJobService, BackgroundJobService>();

            return services;
        }
    }
}