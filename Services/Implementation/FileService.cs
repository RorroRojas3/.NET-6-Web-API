using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Database.Repository.Interface;
using net_core_api_boiler_plate.Models.Requests;
using net_core_api_boiler_plate.Models.Responses;
using net_core_api_boiler_plate.Services.Interface;
using File = net_core_api_boiler_plate.Database.Tables.File;
using SystemFile = System.IO.File;

namespace net_core_api_boiler_plate.Services.Implementation
{
    public class FileService : IFileService
    {
        private readonly IRepository<File> _fileRepository;
        private readonly IMapper _mapper;

        public FileService(IRepository<File> fileRepository,
                            IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        public async Task<bool> DeleteFile(Guid id)
        {
            return await _fileRepository.Delete(id);
        }

        /// <inheritdoc/>
        public async Task<List<FileResponse>> GetAllFiles()
        {
            var files = await _fileRepository.GetAll();
            var response = _mapper.Map<List<FileResponse>>(files);
            return response;
        }

        /// <inheritdoc/>
        public async Task<File> GetFile(Guid id)
        {
            var file = await _fileRepository.Get(id);
            return file;
        }

        /// <inheritdoc/>
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

        /// <inheritdoc/>
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

        /// <inheritdoc/>
        public async Task<bool> PostFileByChunks(FileByChunksRequest request)
        {
            var bytes = Encoding.ASCII.GetBytes(request.Bytes);
            await SystemFile.WriteAllBytesAsync("Example-2.xlsx", bytes);
            return true;
        }
    }
}