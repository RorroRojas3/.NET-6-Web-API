using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Models.Responses;

namespace net_core_api_boiler_plate.Services.Interface
{
    /// <summary>
    ///     IFileService interface
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        ///     Gets all files from DB
        /// </summary>
        /// <returns></returns>
        Task<List<FileResponse>> GetAllFiles();

        /// <summary>
        ///     Gets file from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<File> GetFile(Guid id);

        /// <summary>
        ///     Creates file on DB 
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        Task<bool> PostFile(IFormFile formFile);

        /// <summary>
        ///     Delets file from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteFile(Guid id);

        /// <summary>
        ///     Updates file from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        Task<bool> UpdateFile(Guid id, IFormFile formFile);
    }
}