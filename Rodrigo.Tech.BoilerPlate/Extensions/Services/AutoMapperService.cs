using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Rodrigo.Tech.BoilerPlate.Services.Implementation;

namespace Rodrigo.Tech.BoilerPlate.Extensions.Services
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