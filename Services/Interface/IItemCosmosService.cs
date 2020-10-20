using net_core_api_boiler_plate.Database.Tables.Cosmos;
using net_core_api_boiler_plate.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace net_core_api_boiler_plate.Services.Interface
{
    public interface IItemCosmosService
    {
        /// <summary>
        ///     Deletes item from Azure Cosmos DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteItem(string id);

        /// <summary>
        ///     Gets all items from Azure Cosmos DB
        /// </summary>
        /// <returns></returns>
        IEnumerable<ItemCosmos> GetAllItems();

        /// <summary>
        ///     Gets item from Azure Cosmos DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ItemCosmos> GetItem(string id);

        /// <summary>
        ///     Adds item from Azure Cosmos DB
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ItemCosmos> PostItem(ItemRequest request);

        /// <summary>
        ///     Updates item from Azure Cosmos DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<ItemCosmos> PutItem(string id, ItemRequest item);
    }
}