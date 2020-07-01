using Microsoft.Extensions.DependencyInjection;
using net_core_api_boiler_plate.Services.Implementation;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Extensions.Services
{
    public static class TestControllerService
    {
        public static void AddTestControllerService(this IServiceCollection services)
        {
            services.AddTransient<ITestService, TestService>();
        }

    }
}