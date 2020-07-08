using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Services.Implementation
{
    public class TestService : ITestService
    {
        private readonly IRepository<Item> _itemRepository;

        public TestService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<bool> DeleteItem(Guid id)
        {
            return await _itemRepository.Delete(id);
        }

        public async Task<Item> GetItem(Guid id)
        {
            return await _itemRepository.Get(id);
        }

        public async Task<List<Item>> GetItems()
        {
            return await _itemRepository.GetAll();
        }

        public Task<bool> PostFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> PostItem(Item item)
        {
            return await _itemRepository.Add(item);
        }

        public async Task<Item> PutItem(Item item)
        {
            return await _itemRepository.Update(item);
        }
    }
}