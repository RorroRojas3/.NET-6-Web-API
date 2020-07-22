using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace net_core_api_boiler_plate.Services.Interface
{
    /// <summary>
    ///     IAzureBlobStorage Interface
    /// </summary>
    public interface IAzureBlobStorageService
    {
        /// <summary>
        ///     Creates Azure Blob Storage Container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task<object> CreateContainer(string containerName);

        /// <summary>
        ///     Deletes Azure Blob Storage Container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        Task<object> DeleteContainer(string containerName);

        /// <summary>
        ///     Gets file from Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<object> GetFile(string containerName, string fileName);

        /// <summary>
        ///     Uploads file to Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="fileName"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        Task<object> UploadFile(string containerName, string fileName, IFormFile formFile);

        /// <summary>
        ///     Deletes file from Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        Task<object> DeleteFile(string containerName, string fileName);
    }
}