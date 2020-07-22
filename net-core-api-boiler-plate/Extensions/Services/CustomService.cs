using Microsoft.Extensions.DependencyInjection;
using net_core_api_boiler_plate.Services.Implementation;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Extensions.Services
{
    /// <summary>
    ///     Static AddCustomServices class
    /// </summary>
    public static class CustomService
    {
        /// <summary>
        ///     Adds service for TestController
        /// </summary>
        /// <param name="services"></param>
        public static void AddCustomService(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IFileService, FileService>();
            services.AddTransient<IAzureBlobStorageService, AzureBloblStorageService>();
        }

    }
}