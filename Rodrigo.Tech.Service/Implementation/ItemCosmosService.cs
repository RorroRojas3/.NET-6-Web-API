using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rodrigo.Tech.Model.Requests;
using Rodrigo.Tech.Model.Settings;
using Rodrigo.Tech.Respository.Pattern.Interface;
using Rodrigo.Tech.Respository.Tables.Cosmos;
using Rodrigo.Tech.Service.Interface;

namespace Rodrigo.Tech.Service.Implementation
{
    public class ItemCosmosService : IItemCosmosService
    {
        private readonly ILogger _logger;
        private readonly ICosmosRepository _cosmosRepository;
        private readonly IMapper _mapper;
        private readonly CosmosDb _cosmosDb;

        public ItemCosmosService(ILogger<ItemCosmosService> logger,
                                    ICosmosRepository cosmosRepository,
                                    IMapper mapper,
                                    CosmosDb cosmosDb)
        {
            _logger = logger;
            _cosmosRepository = cosmosRepository;
            _mapper = mapper;
            _cosmosDb = cosmosDb;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteItem(Guid id)
        {
            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(DeleteItem)} - Started, " +
                $"{nameof(id)}: {id}");

            await _cosmosRepository.DeleteItemAsync(id.ToString(), _cosmosDb.DatabaseName, CosmosTables.ITEM);

            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(DeleteItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return true;
        }

        /// <inheritdoc/>
        public IEnumerable<ItemCosmos> GetAllItems()
        {
            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(GetAllItems)} - Started");

            var result = _cosmosRepository.GetItemsAsync<ItemCosmos>(_cosmosDb.DatabaseName, CosmosTables.ITEM);

            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(GetAllItems)} - Finished");
            return result;
        }

        /// <inheritdoc/>
        public async Task<ItemCosmos> GetItem(Guid id)
        {
            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(GetItem)} - Started, " +
                $"{nameof(id)}: {id}");
            
            var result = await _cosmosRepository.GetItemAsync<ItemCosmos>(id.ToString(), _cosmosDb.DatabaseName, CosmosTables.ITEM);

            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(GetItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return result;
        }

        /// <inheritdoc/>
        public async Task<ItemCosmos> PostItem(ItemRequest request)
        {
            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(PostItem)} - Started, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            ItemCosmos newItem = _mapper.Map<ItemCosmos>(request);
            newItem.Id = Guid.NewGuid();

            await _cosmosRepository.AddItemAsync(newItem, newItem.Id.ToString(), _cosmosDb.DatabaseName, CosmosTables.ITEM);

            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(PostItem)} - Finished, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return newItem;
        }

        /// <inheritdoc/>
        public async Task<ItemCosmos> PutItem(Guid id, ItemRequest request)
        {
            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(PutItem)} - Started, " +
                $"{nameof(id)}: {id}" +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var item = await GetItem(id);
            _mapper.Map(request, item);

            await _cosmosRepository.UpdateItemAsync(item.Id.ToString(), item, _cosmosDb.DatabaseName, CosmosTables.ITEM);

            _logger.LogInformation($"{nameof(ItemCosmosService)} - {nameof(PutItem)} - Finished, " +
                $"{nameof(id)}: {id}" +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return item;
        }
    }
}