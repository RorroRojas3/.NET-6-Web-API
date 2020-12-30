using Rodrigo.Tech.Model.Requests;
using Rodrigo.Tech.Respository.Pattern.Interface;
using Rodrigo.Tech.Respository.Tables.Context;
using Rodrigo.Tech.Service.Helpers;
using Rodrigo.Tech.Service.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rodrigo.Tech.Service.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IRepository<Item> _itemRepository;
        private readonly ICacheService _cacheService;

        public ItemService(IRepository<Item> itemRepository,
                            ICacheService cacheHelper)
        {
            _itemRepository = itemRepository;
            _cacheService = cacheHelper;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteItem(Guid id)
        {
            return await _itemRepository.Delete(id);
        }

        /// <inheritdoc/>
        public async Task<Item> GetItem(Guid id)
        {
            var cacheBytes = await _cacheService.GetAsync($"item-{id}");

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

            await _cacheService.SetDatatMinAsync($"item-{id}", serializedItem, 5);

            return item;
        }

        /// <inheritdoc/>
        public async Task<List<Item>> GetItems()
        {
            var cacheBytes = await _cacheService.GetAsync($"items");

            if (cacheBytes != null)
            {
                var cacheItem = SerializeHelper.DeserializeObject<List<Item>>(cacheBytes);
                return cacheItem;
            }

            var items = await _itemRepository.GetAll();

            if (items.Count == 0)
            {
                return null;
            }

            var serializedItem = SerializeHelper.SerializeObject(items);

            await _cacheService.SetDatatMinAsync($"items", serializedItem, 5);

            return items;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<Item> PutItem(Guid id, ItemRequest itemRequest)
        {
            var item = await GetItem(id);

            if (item == null)
            {
                return null;
            }

            await _cacheService.RemoveCacheAsync($"item-{id}");

            item.Name = itemRequest.Name;
            item.Value = itemRequest.Value;

            return await _itemRepository.Update(item);
        }
    }
}