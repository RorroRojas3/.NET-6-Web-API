using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Services.Interface;
using File = net_core_api_boiler_plate.Database.Tables.File;
using static System.Net.WebRequestMethods;

namespace net_core_api_boiler_plate.Services.Implementation
{
    /// <summary>
    ///     FileService class with IFileService interface implementation
    /// </summary>
    public class FileService : IFileService
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly IRepository<File> _fileRepository;

        /// <summary>
        ///     FileService constructor with DI
        /// </summary>
        /// <param name="fileRepository"></param>
        public FileService(IRepository<File> fileRepository)
        {
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