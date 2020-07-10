using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace net_core_api_boiler_plate.Services.Interface
{
    /// <summary>
    ///     IFileService interface
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        ///     Gets file from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<byte[]> GetFile(Guid id);

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