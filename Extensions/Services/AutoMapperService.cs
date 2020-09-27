using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using net_core_api_boiler_plate.Services.Implementation;

namespace net_core_api_boiler_plate.Extensions.Services
{
    public static class AutoMapperService
    {
        /// <summary>
        ///     Adds AutoMapper service
        /// </summary>
        /// <param name="services"></param>
        public static void AddAutoMapperService(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}