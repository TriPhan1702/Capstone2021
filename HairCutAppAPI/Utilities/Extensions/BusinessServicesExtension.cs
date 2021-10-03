﻿using HairCutAppAPI.Services;
using HairCutAppAPI.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HairCutAppAPI.Utilities.Extensions
{
    public static class BusinessServicesExtension
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IStaffService, StaffService>();
            services.AddScoped<ISalonService, SalonService>();
            services.AddScoped<IServiceService, ServiceService>();
            services.AddScoped<IComboService, ComboService>();
            services.AddScoped<IReviewService, ReviewService>();
            return services;
        }
    }
}