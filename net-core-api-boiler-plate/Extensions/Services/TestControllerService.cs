using Microsoft.Extensions.DependencyInjection;
using net_core_api_boiler_plate.Services.Implementation;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Extensions.Services
{
    /// <summary>
    ///     Static TestControllerService class
    /// </summary>
    public static class TestControllerService
    {
        /// <summary>
        ///     Adds service for TestController
        /// </summary>
        /// <param name="services"></param>
        public static void AddTestControllerService(this IServiceCollection services)
        {
            services.AddTransient<IItemService, ItemService>();
            services.AddTransient<IFileService, FileService>();
        }

    }
}