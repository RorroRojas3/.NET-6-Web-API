using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Rodrigo.Tech.BoilerPlate.Extensions.ServiceCollection
{
    public static class HealthCheckServiceCollection
    {
        public static void AddCustomHealthChecks(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddHealthChecks()
                    .AddSqlServer(configuration.GetConnectionString("AZURE_DB"));
            // service.AddHealthChecksUI(options =>
            // {
            //     options.AddHealthCheckEndpoint("API", "/healthcheck"); 
            // })
            //     .AddInMemoryStorage();
        }
    }
}
