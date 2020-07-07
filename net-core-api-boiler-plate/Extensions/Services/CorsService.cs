using Microsoft.Extensions.DependencyInjection;

namespace net_core_api_boiler_plate.Extensions.Services
{
    public static class CorsService
    {
        private static readonly string _defaultCorsPolicy = "DefaultCorsPolicy";

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