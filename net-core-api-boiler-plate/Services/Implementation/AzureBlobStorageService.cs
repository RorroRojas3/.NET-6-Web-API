using System.Reflection.Metadata;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Services.Interface;
using Azure.Storage.Blobs;

namespace net_core_api_boiler_plate.Services.Implementation
{
    /// <summary>
    ///     AzureBlobStorageService class with Interface implementation
    /// </summary>
    public class AzureBlobStorageService : IAzureBlobStorageService
    {
        /// <summary>
        ///     Creates Azure Blob Storage Container
        /// </summary>
        /// <param name="containerName"></param>
        /// <returns></returns>
        public async Task<BlobContainerClient> CreateContainer(string containerName)
        {
            var blobServiceClient = CreateBlobServiceClient();

            BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);

            return containerClient;
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

        /// <summary>
        ///     Creates BlobServiceClient
        /// </summary>
        /// <returns></returns>
        private BlobServiceClient CreateBlobServiceClient()
        {
            var connectionString = Environment.GetEnvironmentVariable("AZURE_BLOB_STORAGE");
            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);
            return blobServiceClient;
        }
    }
}