using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
        private readonly ILogger _logger;

        public ItemService(IRepository<Item> itemRepository,
                            ICacheService cacheHelper,
                            ILogger<ItemService> logger)
        {
            _itemRepository = itemRepository;
            _cacheService = cacheHelper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteItem(Guid id)
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(DeleteItem)} - Started, " +
                $"{nameof(id)}: {id}");

            var result =  await _itemRepository.Delete(id);

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(DeleteItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return result;
        }

        /// <inheritdoc/>
        public async Task<Item> GetItem(Guid id)
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItem)} - Started, " +
                $"{nameof(id)}: {id}");

            var cacheBytes = await _cacheService.GetAsync($"item-{id}");

            if (cacheBytes != null)
            {
                var cacheItem = SerializeHelper.DeserializeObject<Item>(cacheBytes);
                return cacheItem;
            }

            var item = await _itemRepository.Get(id);

            if (item == null)
            {
                _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItem)} - Not found, " +
                $"{nameof(id)}: {id}");
                return null;
            }

            var serializedItem = SerializeHelper.SerializeObject(item);

            await _cacheService.SetDataMinAsync($"item-{id}", serializedItem, 5);

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return item;
        }

        /// <inheritdoc/>
        public async Task<List<Item>> GetItems()
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItems)} - Started");

            var cacheBytes = await _cacheService.GetAsync($"items");

            if (cacheBytes != null)
            {
                var cacheItem = SerializeHelper.DeserializeObject<List<Item>>(cacheBytes);
                return cacheItem;
            }

            var items = await _itemRepository.GetAll();

            if (items.Count == 0)
            {
                _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItems)} - Not found");
                return null;
            }

            var serializedItem = SerializeHelper.SerializeObject(items);

            await _cacheService.SetDataMinAsync($"items", serializedItem, 5);

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItems)} - Finished");
            return items;
        }

        /// <inheritdoc/>
        public async Task<Item> PostItem(ItemRequest item)
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(PostItem)} - Started, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(item)}");

            var newItem = new Item
            {
                Id = Guid.NewGuid(),
                Name = item.Name,
                Value = item.Value
            };

            var result =  await _itemRepository.Add(newItem);

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(PostItem)} - Finished, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(item)}");
            return result;
        }

        /// <inheritdoc/>
        public async Task<Item> PutItem(Guid id, ItemRequest request)
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(PutItem)} - Started, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var item = await GetItem(id);

            if (item == null)
            {
                _logger.LogInformation($"{nameof(ItemService)} - {nameof(PutItem)} - Not found, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
                return null;
            }

            await _cacheService.RemoveCacheAsync($"item-{id}");

            item.Name = request.Name;
            item.Value = request.Value;

            var result =  await _itemRepository.Update(item);

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(PutItem)} - Finished, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return result;
        }
    }
}