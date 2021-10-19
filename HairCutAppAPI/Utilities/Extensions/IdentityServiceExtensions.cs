using System;
using System.Text;
using HairCutAppAPI.Data;
using HairCutAppAPI.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HairCutAppAPI.Utilities.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {

            //Authentication middleware
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    };
                });

            // //Add authorization policies
            // services.AddAuthorization(option =>
            // {
            //     option.AddPolicy(GlobalVariables.RequireAdministratorRole,
            //         policy => policy.RequireRole(GlobalVariables.AdministratorRole));
            //     option.AddPolicy(GlobalVariables.RequireCustomerRole,
            //         policy => policy.RequireRole(GlobalVariables.CustomerRole));
            //     option.AddPolicy(GlobalVariables.RequireManagerRole,
            //         policy => policy.RequireRole(GlobalVariables.ManagerRole));
            //     option.AddPolicy(GlobalVariables.RequireStylistRole,
            //         policy => policy.RequireRole(GlobalVariables.StylistRole));
            //     option.AddPolicy(GlobalVariables.RequireBeauticianRole,
            //         policy => policy.RequireRole(GlobalVariables.BeauticianRole));
            // });
            
            //Token generated will last for 1 hour
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(1));

            return services;
        }
    }
}