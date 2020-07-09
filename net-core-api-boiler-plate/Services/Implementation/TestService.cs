using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Services.Implementation
{
    /// <summary>
    ///     TestService class with implementation of interface ITestService
    /// </summary>
    public class TestService : ITestService
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly IRepository<Item> _itemRepository;

        /// <summary>
        ///     TestService constructor with DI
        /// </summary>
        /// <param name="itemRepository"></param>
        public TestService(IRepository<Item> itemRepository)
        {
            _itemRepository = itemRepository;
        }

        /// <summary>
        ///     Deletes file from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> DeleteFile(Guid id)
        {
            throw new NotImplementedException();
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
        ///     Gets file from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<byte[]> GetFile(Guid id)
        {
            throw new NotImplementedException();
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
        ///     Creates file on DB
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public Task<bool> PostFile(IFormFile formFile)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Creates item on DB
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<Item> PostItem(Item item)
        {
            return await _itemRepository.Add(item);
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

        /// <summary>
        ///     Updates file on DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<bool> UpdateFile(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}