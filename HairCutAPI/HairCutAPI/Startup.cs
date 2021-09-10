using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using HairCutAPI.Data;
using HairCutAPI.Errors;
using HairCutAPI.Extensions;
using Microsoft.EntityFrameworkCore;

namespace HairCutAPI
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices(_config);

            services.AddControllers();
            
            services.AddSwaggerServices();

            //Use cross origin service
            services.AddCors();
            services.AddIdentityServices(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Middleware to handle errors
            app.UseMiddleware<ExceptionMiddleWare>();

            // if (env.IsDevelopment())
            // {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "HairCutAPI v1");
                });

            // }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Have to between UseRouting and UseEndpoints
            //Allow any methods from 4200 or the The web origin when deployed
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
           
            //After Cors and before UseAuthorization
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
