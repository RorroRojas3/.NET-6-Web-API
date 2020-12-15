using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rodrigo.Tech.BoilerPlate.Models.Settings;
using Rodrigo.Tech.BoilerPlate.Services.Implementation;
using Rodrigo.Tech.BoilerPlate.Services.Interface;
using Rodrigo.Tech.Respository.Pattern.Implementation;
using Rodrigo.Tech.Respository.Pattern.Interface;

namespace Rodrigo.Tech.BoilerPlate.Extensions.Services
{
    public static class CosmosService
    {
        /// <summary>
        ///     Adds Azure Cosmos DB
        /// </summary>
        /// <param name="services"></param>
        /// <param name="configuration"></param>
        public static void AddAzureCosmosService(this IServiceCollection services, IConfiguration configuration)
        {
            var cosmosDb = configuration.GetSection("CosmosDb").Get<CosmosDb>();
            CosmosClientBuilder clientBuilder = new CosmosClientBuilder(cosmosDb.Account, cosmosDb.Key);
            CosmosClient client = clientBuilder
                                .WithConnectionModeDirect()
                                .Build();

            DatabaseResponse database = client.CreateDatabaseIfNotExistsAsync(cosmosDb.DatabaseName).GetAwaiter().GetResult();

            foreach (var item in cosmosDb.ContainerCollection)
            {
                database.Database.CreateContainerIfNotExistsAsync(item.Name, item.PartitionKey);
            }
            
            services.AddSingleton(client);
            services.AddScoped<ICosmosRepository, CosmosRepository>();
            services.AddSingleton(cosmosDb);
            services.AddScoped<IItemCosmosService, ItemCosmosService>();
        }
    }
}