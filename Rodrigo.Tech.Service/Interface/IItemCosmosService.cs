using Rodrigo.Tech.Model.Requests;
using Rodrigo.Tech.Respository.Tables.Cosmos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rodrigo.Tech.Service.Interface
{
    public interface IItemCosmosService
    {
        /// <summary>
        ///     Deletes item from Azure Cosmos DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItem(Guid id);

        /// <summary>
        ///     Gets all items from Azure Cosmos DB
        /// </summary>
        /// <returns></returns>
        IEnumerable<ItemCosmos> GetAllItems();

        /// <summary>
        ///     Gets item from Azure Cosmos DB
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ItemCosmos> GetItem(Guid id);

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
        Task<ItemCosmos> PutItem(Guid id, ItemRequest item);
    }
}