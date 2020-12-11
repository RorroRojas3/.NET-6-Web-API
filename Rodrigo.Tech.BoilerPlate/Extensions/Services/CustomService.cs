using Microsoft.Extensions.DependencyInjection;
using Rodrigo.Tech.BoilerPlate.Services.Implementation;
using Rodrigo.Tech.BoilerPlate.Services.Interface;

namespace Rodrigo.Tech.BoilerPlate.Extensions.Services
{
    public static class CustomService
    {
        /// <summary>
        ///     Adds service for TestController
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAzureBlobStorageService, AzureBlobStorageService>();
        }

    }
}