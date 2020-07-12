using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Database.Tables;
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

        /// <summary>
        ///     ItemService constructor with DI
        /// </summary>
        /// <param name="itemRepository"></param>
        public ItemService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
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
            return await _itemRepository.Get(id);
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
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Item> PutItem(Item item)
        {
            return await _itemRepository.Update(item);
        }
    }
}