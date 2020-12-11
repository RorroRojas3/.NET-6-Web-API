using Microsoft.Extensions.DependencyInjection;
using Rodrigo.Tech.BoilerPlate.Helpers;

namespace Rodrigo.Tech.BoilerPlate.Extensions.Services
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