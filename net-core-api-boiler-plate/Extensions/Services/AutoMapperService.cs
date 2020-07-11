using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace net_core_api_boiler_plate.Extensions.Services
{
    /// <summary>
    ///     Static AutoMapperService class  
    /// </summary>
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