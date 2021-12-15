using System;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace HairCutAppAPI.Utilities.Errors
{
    public class ExceptionMiddleWare
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleWare> _logger;
        private readonly IHostEnvironment _env;

        public ExceptionMiddleWare(RequestDelegate next, ILogger<ExceptionMiddleWare> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                //If there's not exception this will pass on to the next thing
                await _next(context);
            }
            catch (HttpStatusCodeException e)
            {
                _logger.LogError(e, e.Message);
                //Write out error to the response
                context.Response.ContentType = "apllication/json";
                //If is in development mode, send stack trace
                var response = new CustomHttpCodeResponse((int) e.StatusCode, e.Message, e.StackTrace?.ToString());

                //Make sure Json in response is sent back is in camel case
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                //Write out error to the response
                context.Response.ContentType = "apllication/json";
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //If is in development mode, send stack trace
                var response = _env.IsDevelopment()
                    ? new CustomHttpCodeResponse(context.Response.StatusCode, e.Message, e.StackTrace?.ToString())
                    : new CustomHttpCodeResponse(context.Response.StatusCode, "Internal Server Error");

                //Make sure Json in response is sent back is in camel case
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };

                var json = JsonSerializer.Serialize(response, options);

                await context.Response.WriteAsync(json);
            }
        }
    }
}