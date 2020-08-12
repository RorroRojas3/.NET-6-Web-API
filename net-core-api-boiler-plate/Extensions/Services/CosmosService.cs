using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using net_core_api_boiler_plate.Models.Settings;
using net_core_api_boiler_plate.Services.Implementation;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Extensions.Services
{
    /// <summary>
    ///     Static CosmosService class
    /// </summary>
    public static class CosmosService
    {
        /// <summary>
        ///     Adds Azure Cosmos DB
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAzureCosmosService(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDb = configuration.GetSection("AZURE_COSMOS_DB").Get<CosmosDb>();
            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(cosmosDb.Account, cosmosDb.Key);
            CosmosClient client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();

            services.AddSingleton(client);
            services.AddScoped<IAzureCosmosService, AzureCosmosService>();
        }
    }
}