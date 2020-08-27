using Microsoft.Extensions.DependencyInjection;

namespace net_core_api_boiler_plate.Extensions.Services
{
    /// <summary>
    ///     Static CorsService class
    /// </summary>
    public static class CorsService
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private static readonly string _defaultCorsPolicy = "DefaultCorsPolicy";

        /// <summary>
        ///     Adds CORS services
        /// </summary>
        /// <param name="services"></param>
        public static void AddCorsService(this IServiceCollection services)
        {
            services.AddCors(x => x.AddPolicy(_defaultCorsPolicy,
                options =>
                {
                    options.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                ;
                }));
        }
    }
}