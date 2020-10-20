using System.Collections.Generic;
using System.Threading.Tasks;

namespace net_core_api_boiler_plate.Services.Interface
{
    public interface IAzureCosmosService
    {
        /// <summary>
        ///     Deletes item from Azure Cosmos DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task DeleteItem(string id, string dataBaseName, string containerName);

        /// <summary>
        ///     Gets all items from Azure Cosmos DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataBaseName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        IEnumerable<T> GetAllItems<T>(string dataBaseName, string containerName);

        /// <summary>
        ///     Gets item from Azure Cosmos DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task<T> GetItem<T>(string id, string dataBaseName, string containerName);

        /// <summary>
        ///     Adds item from Azure Cosmos DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <param name="id"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task<T> PostItem<T>(T item, string id, string dataBaseName, string containerName);

        /// <summary>
        ///     Updates item from Azure Cosmos DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <param name="dataBaseName"></param>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task<T> PutItem<T>(string id, T item, string dataBaseName, string containerName);
    }
}