using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using File = net_core_api_boiler_plate.Database.Tables.File;
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
        private readonly IRepository<File> _fileRepository;

        /// <summary>
        ///     TestService constructor with DI
        /// </summary>
        /// <param name="itemRepository"></param>
        /// <param name="fileRepository"></param>
        public TestService(IRepository<Item> itemRepository,
                            IRepository<File> fileRepository)
        {
            _itemRepository = itemRepository;
            _fileRepository = fileRepository;
        }

        /// <summary>
        ///     Deletes file from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteFile(Guid id)
        {
            return await _fileRepository.Delete(id);
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
        public async Task<byte[]> GetFile(Guid id)
        {
            var file = await _fileRepository.Get(id);
            return file.Data;
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
        public async Task<bool> PostFile(IFormFile formFile)
        {
            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                data = memoryStream.ToArray();
            }

            var file = new File
            {
                Id = Guid.NewGuid(),
                Name = formFile.FileName,
                ContentType = formFile.ContentType,
                Data = data
            };

            var result = await _fileRepository.Add(file);

            return result == null ? false : true;
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
        /// <param name="formfile"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFile(Guid id, IFormFile formfile)
        {
            var deleteFile = await _fileRepository.Delete(id);

            if (!deleteFile)
            {
                return false;
            }

            var addFile = await PostFile(formfile);

            if (!addFile)
            {
                return false;
            }

            return true;
        }
    }
}