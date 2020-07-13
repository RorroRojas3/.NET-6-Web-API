using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Helpers;
using net_core_api_boiler_plate.Models.Requests;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Services.Implementation
{
    /// <summary>
    ///     TestService class with implementation of interface ITestService
    /// </summary>
    public class ItemService : IItemService
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly IRepository<Item> _itemRepository;
        private readonly IDistributedCache _cache;

        /// <summary>
        ///     ItemService constructor with DI
        /// </summary>
        /// <param name="itemRepository"></param>
        /// <param name="distributedCache"></param>
        public ItemService(IRepository<Item> itemRepository,
                            IDistributedCache distributedCache)
        {
            _itemRepository = itemRepository;
            _cache = distributedCache;
        }

        /// <summary>
        ///     Deletes item from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteItem(Guid id)
        {
            return await _itemRepository.Delete(id);
        }

        /// <summary>
        ///     Gets item from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Item> GetItem(Guid id)
        {
            var cacheBytes = await CacheHelper.GetAsync($"item-{id}", _cache);

            if (cacheBytes != null)
            {
                var cacheItem = SerializeHelper.DeserializeObject<Item>(cacheBytes);
                return cacheItem;
            }

            var item = await _itemRepository.Get(id);

            if (item == null)
            {
                return null;
            }

            var serializedItem = SerializeHelper.SerializeObject(item);

            await CacheHelper.SetDatatMinAsync($"item-{id}", serializedItem, 5, _cache);

            return item;
        }

        /// <summary>
        ///     Gets all items from DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<Item>> GetItems()
        {
            return await _itemRepository.GetAll();
        }

        /// <summary>
        ///     Creates item on DB
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Item> PostItem(ItemRequest item)
        {
            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Value = item.Value
            };

            return await _itemRepository.Add(newItem);
        }

        /// <summary>
        ///     Updates item on DB
        /// </summary>
        /// <param name="id"></param>
        /// <param name="itemRequest"></param>
        /// <returns></returns>
        public async Task<Item> PutItem(Guid id, ItemRequest itemRequest)
        {
            var item = await GetItem(id);

            if (item == null)
            {
                return null;
            }

            item.Name = itemRequest.Name;
            item.Value = itemRequest.Value;

            return await _itemRepository.Update(item);
        }
    }
}