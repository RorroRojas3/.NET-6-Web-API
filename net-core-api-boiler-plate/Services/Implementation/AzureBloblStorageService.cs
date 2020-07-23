using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Services.Implementation
{
    /// <summary>
    ///     AzureBlobStorageService class with Interface implementation
    /// </summary>
    public class AzureBloblStorageService : IAzureBlobStorageService
    {
        /// <summary>
        ///     Creates Azure Blob Storage Container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Task<object> CreateContainer(string containerName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Deletes Azure Blob Storage Container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public Task<object> DeleteContainer(string containerName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Gets file from Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<object> GetFile(string containerName, string fileName)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Uploads file to Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        public Task<object> UploadFile(string containerName, IFormFile formFile)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        ///     Deletes file from Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public Task<object> DeleteFile(string containerName, string fileName)
        {
            throw new System.NotImplementedException();
        }
    }
}