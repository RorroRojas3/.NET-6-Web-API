using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Rodrigo.Tech.Model.Settings;
using Rodrigo.Tech.Respository.Pattern.Implementation;
using Rodrigo.Tech.Respository.Pattern.Interface;
using Rodrigo.Tech.Service.Implementation;
using Rodrigo.Tech.Service.Interface;

namespace Rodrigo.Tech.BoilerPlate.Extensions.ServiceCollection
{
    public static class CosmosServiceCollection
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