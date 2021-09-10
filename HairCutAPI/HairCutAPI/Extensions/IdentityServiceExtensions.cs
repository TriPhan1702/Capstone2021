﻿using System.Text;
using HairCutAPI.Data;
using HairCutAPI.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
namespace HairCutAPI.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<AppUser>(opt =>
            {
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<HDBContext>();

            //Authentication middleware
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["TokenKey"])),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            //Add authorization policies
            services.AddAuthorization(option =>
            {
                option.AddPolicy("RequireAdminRole", 
                    policy=>policy.RequireRole("Administrator"));
                option.AddPolicy("RequireCustomerRole",
                    policy => policy.RequireRole("Customer"));
                option.AddPolicy("RequireManagerRole",
                    policy => policy.RequireRole("Manager"));
                option.AddPolicy("RequireEmployeeRole",
                    policy => policy.RequireRole("Manager"));
            });

            return services;
        }
    }
}
