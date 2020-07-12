using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace net_core_api_boiler_plate.Extensions.Applications
{
    /// <summary>
    ///     Static ExceptionApplicaton class
    /// </summary>
    public static class ExceptionApplication
    {
        /// <summary>
        ///     Adds Exception middleware
        /// </summary>
        /// <param name="application"></param>
        public static void UseExceptionMiddleware(this IApplicationBuilder application)
        {
            application.UseMiddleware<ExceptionMiddleware>();
        }
    }

    /// <summary>
    ///     ExceptionMiddleware class
    /// </summary>
    public class ExceptionMiddleware
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        /// <summary>
        ///     ExceptionMiddelware constructor with DI
        /// </summary>
        /// <param name="next"></param>
        /// <param name="logger"></param>
        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        /// <summary>
        ///     Invokes exception on API call
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next.Invoke(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex).ConfigureAwait(false);
            }
        }

        /// <summary>
        ///     Handles exceptions
        /// </summary>
        /// <param name="context"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            int statusCode = (int)HttpStatusCode.InternalServerError;
            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = statusCode,
                ErrorMessage = "Internal server error"
            });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = statusCode;
            return context.Response.WriteAsync(result);
        }
    }
}