using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Rodrigo.Tech.Model.Response;
using Rodrigo.Tech.Respository.Pattern.Interface;
using Rodrigo.Tech.Service.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using File = Rodrigo.Tech.Respository.Tables.Context.File;

namespace Rodrigo.Tech.Service.Implementation
{
    public class FileService : IFileService
    {
        private readonly IRepository<File> _fileRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public FileService(IRepository<File> fileRepository,
                            IMapper mapper,
                            ILogger<FileService> logger)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteFile(Guid id)
        {
            _logger.LogInformation($"{nameof(FileService)} - {nameof(DeleteFile)} - Started, " +
                $"{nameof(id)}: {id}");

            var result =  await _fileRepository.Delete(id);

            _logger.LogInformation($"{nameof(FileService)} - {nameof(DeleteFile)} - Finished, " +
                $"{nameof(id)}: {id}");
            return result;
        }

        /// <inheritdoc/>
        public async Task<List<FileResponse>> GetAllFiles()
        {
            _logger.LogInformation($"{nameof(FileService)} - {nameof(GetAllFiles)} - Started");

            var files = await _fileRepository.GetAll();
            var response = _mapper.Map<List<FileResponse>>(files);

            _logger.LogInformation($"{nameof(FileService)} - {nameof(GetAllFiles)} - Finished");
            return response;
        }

        /// <inheritdoc/>
        public async Task<File> GetFile(Guid id)
        {
            _logger.LogInformation($"{nameof(FileService)} - {nameof(GetFile)} - Started, " +
                $"{nameof(id)}: {id}");

            var file = await _fileRepository.Get(id);

            _logger.LogInformation($"{nameof(FileService)} - {nameof(GetFile)} - Finished, " +
                $"{nameof(id)}: {id}");
            return file;
        }

        /// <inheritdoc/>
        public async Task<bool> PostFile(IFormFile formFile)
        {
            _logger.LogInformation($"{nameof(FileService)} - {nameof(PostFile)} - Started");

            _logger.LogInformation($"{nameof(FileService)} - {nameof(PostFile)} - Formfile to Byte array");
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

            _logger.LogInformation($"{nameof(FileService)} - {nameof(PostFile)} - Adding to database");
            var result = await _fileRepository.Add(file);

            _logger.LogInformation($"{nameof(FileService)} - {nameof(PostFile)} - Finished");
            return result != null;
        }

        /// <inheritdoc/>
        public async Task<bool> UpdateFile(Guid id, IFormFile formFile)
        {
            _logger.LogInformation($"{nameof(FileService)} - {nameof(UpdateFile)} - Started, " +
                $"{nameof(id)}: {id}");

            var file = await _fileRepository.Get(id);

            if (file == null)
            {
                _logger.LogError($"{nameof(FileService)} - {nameof(UpdateFile)} - Not found, " +
                $"{nameof(id)}: {id}");
                return false;
            }

            _logger.LogInformation($"{nameof(FileService)} - {nameof(UpdateFile)} - Updating file, " +
                $"{nameof(id)}: {id}");

            byte[] data;
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                data = memoryStream.ToArray();
            }

            file.Name = formFile.Name;
            file.ContentType = formFile.ContentType;
            file.Data = data;
            await _fileRepository.Update(file);

            _logger.LogInformation($"{nameof(FileService)} - {nameof(UpdateFile)} - Finished, " +
                $"{nameof(id)}: {id}");
            return true;
        }
    }
}