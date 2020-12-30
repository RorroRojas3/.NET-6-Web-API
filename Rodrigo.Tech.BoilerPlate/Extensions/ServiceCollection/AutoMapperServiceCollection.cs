using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Rodrigo.Tech.BoilerPlate.Extensions.ServiceCollection
{
    public static class AutoMapperServiceCollection
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