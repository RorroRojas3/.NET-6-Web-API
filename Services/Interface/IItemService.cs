using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Models.Requests;

namespace net_core_api_boiler_plate.Services.Interface
{
    /// <summary>
    ///     ITestSerice interface
    /// </summary>
    public interface IItemService
    {
        /// <summary>
        ///     Gets all items from DB
        /// </summary>
        /// <returns></returns>
        Task<List<Item>> GetItems();

        /// <summary>
        ///     Gets item from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Item> GetItem(Guid id);

        /// <summary>
        ///     Creates item on DB
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<Item> PostItem(ItemRequest item);

        /// <summary>
        ///     Updates item on DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Task<Item> PutItem(Guid id, ItemRequest item);

        /// <summary>
        ///     Deletes item from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteItem(Guid id);
    }
}