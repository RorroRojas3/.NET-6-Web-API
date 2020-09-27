using Microsoft.Extensions.DependencyInjection;
using net_core_api_boiler_plate.Helpers;

namespace net_core_api_boiler_plate.Extensions.Services
{
    public static class HelperService
    {
        /// <summary>
        ///     Adds Helpers
        /// </summary>
        /// <param name="services"></param>
        public static void AddHelpersService(this IServiceCollection services)
        {
            services.AddScoped<CacheHelper>();
        }
    }
}