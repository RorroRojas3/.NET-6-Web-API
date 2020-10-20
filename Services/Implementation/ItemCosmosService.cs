using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Database.Tables.Cosmos;
using net_core_api_boiler_plate.Models.Requests;
using net_core_api_boiler_plate.Models.Settings;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Services.Implementation
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
        public async Task DeleteItem(string id)
        {
            await _cosmosRepository.DeleteItemAsync(id, _cosmosDb.DatabaseName, CosmosTables.ITEM);
        }

        /// <inheritdoc/>
        public IEnumerable<ItemCosmos> GetAllItems()
        {
            return _cosmosRepository.GetItemsAsync<ItemCosmos>(_cosmosDb.DatabaseName, CosmosTables.ITEM);
        }

        /// <inheritdoc/>
        public async Task<ItemCosmos> GetItem(string id)
        {
            return await _cosmosRepository.GetItemAsync<ItemCosmos>(id, _cosmosDb.DatabaseName, CosmosTables.ITEM);
        }

        /// <inheritdoc/>
        public async Task<ItemCosmos> PostItem(ItemRequest item)
        {
            ItemCosmos newItem = _mapper.Map<ItemCosmos>(item);
            newItem.Id = Guid.NewGuid();

            await _cosmosRepository.AddItemAsync(newItem, newItem.Id.ToString(), _cosmosDb.DatabaseName, CosmosTables.ITEM);

            return newItem;
        }

        /// <inheritdoc/>
        public async Task<ItemCosmos> PutItem(string id, ItemRequest request)
        {
            var item = await GetItem(id);
            _mapper.Map(request, item);

            await _cosmosRepository.UpdateItemAsync(item.Id.ToString(), item, _cosmosDb.DatabaseName, CosmosTables.ITEM);

            return item;
        }
    }
}