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
            services.AddIdentity<AppUser, AppRole>(opt =>
                {
                    opt.Password.RequireNonAlphanumeric = false;
                })
                .AddRoles<AppRole>()
                .AddRoleManager<RoleManager<AppRole>>()
                .AddSignInManager<SignInManager<AppUser>>()
                .AddRoleValidator<RoleValidator<AppRole>>()
                .AddEntityFrameworkStores<HDBContext>()
                .AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);

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
                option.AddPolicy(GlobalVariables.RequireAdministratorRole,
                    policy => policy.RequireRole(GlobalVariables.AdministratorRole));
                option.AddPolicy(GlobalVariables.RequireCustomerRole,
                    policy => policy.RequireRole(GlobalVariables.CustomerRole));
                option.AddPolicy(GlobalVariables.RequireManagerRole,
                    policy => policy.RequireRole(GlobalVariables.ManagerRole));
                option.AddPolicy(GlobalVariables.RequireStaffRole,
                    policy => policy.RequireRole(GlobalVariables.StaffRole));
            });
            
            //Token generated will last for 1 hour
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
                opt.TokenLifespan = TimeSpan.FromHours(1));

            return services;
        }
    }
}