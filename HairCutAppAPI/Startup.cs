

using HairCutAppAPI.Utilities.Email;
using HairCutAppAPI.Utilities.Errors;
using HairCutAppAPI.Utilities.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HairCutAppAPI
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
            
            //Use services that handle user authentication and authorization
            services.AddIdentityServices(_config);
            
            //Use services that handle business logic
            services.AddBusinessServices();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Middleware to handle errors
            app.UseMiddleware<ExceptionMiddleWare>();

            // if (env.IsDevelopment())
            // {
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "HairCutAPI v1"); });

            // }

            app.UseHttpsRedirection();

            app.UseRouting();

            //Have to between UseRouting and UseEndpoints
            //Allow any methods from 4200 or the The web origin when deployed
            // app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:4200"));
            app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod());

            //After Cors and before UseAuthorization
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}