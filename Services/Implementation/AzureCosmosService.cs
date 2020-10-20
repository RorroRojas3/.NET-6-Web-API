using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Cosmos;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Services.Implementation
{
    public class AzureCosmosService : IAzureCosmosService
    {
        private readonly CosmosClient _cosmosClient;

        public AzureCosmosService(CosmosClient cosmosClient)
        {
            _cosmosClient = cosmosClient;
        }

        /// <inheritdoc/>
        public async Task DeleteItem(string id, string dataBaseName, string containerName)
        {
            var container = GetContainer(dataBaseName, containerName);
            await container.DeleteItemAsync<IEntity>(id, new PartitionKey(id));
        }

        /// <inheritdoc/>
        public IEnumerable<T> GetAllItems<T>(string dataBaseName, string containerName)
        {
            var container = GetContainer(dataBaseName, containerName);
            var results = container.GetItemLinqQueryable<T>(true).ToList();
            return results;
        }

        /// <inheritdoc/>
        public async Task<T> GetItem<T>(string id, string dataBaseName, string containerName)
        {
            var container = GetContainer(dataBaseName, containerName);
            ItemResponse<T> response = await container.ReadItemAsync<T>(id, new PartitionKey(id));
            return response.Resource;
        }

        /// <inheritdoc/>
        public async Task<T> PostItem<T>(T item, string id, string dataBaseName, string containerName)
        {
            var container = GetContainer(dataBaseName, containerName);
            await container.CreateItemAsync(item, new PartitionKey(id));
            return item;
        }

        /// <inheritdoc/>
        public async Task<T> PutItem<T>(string id, T item, string dataBaseName, string containerName)
        {
            var container = GetContainer(dataBaseName, containerName);
            await container.UpsertItemAsync(item, new PartitionKey(id));
            return item;
        }

        /// <summary>
        ///     Gets Container for Azure Cosmos
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        private Container GetContainer(string databaseName, string containerName)
        {
            return _cosmosClient.GetContainer(databaseName, containerName);
        }
    }
}