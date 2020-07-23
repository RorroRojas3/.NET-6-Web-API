using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Controllers.V1
{
    /// <summary>
    ///     AzureBlobStorageController
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class AzureBlobStorageController : Controller
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly ILogger _logger;
        private readonly IAzureBlobStorageService _azureBlobStorageService;

        /// <summary>
        ///     TestController constructor with DI
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="azureBlobStorageService"></param>
        public AzureBlobStorageController(ILogger<AzureBlobStorageController> logger,
                                         IAzureBlobStorageService azureBlobStorageService)
        {
            _logger = logger;
            _azureBlobStorageService = azureBlobStorageService;
        }

        /// <summary>
        ///     Gets File from Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{containerName}/{fileName}")]
        public async Task<IActionResult> GetFile([FromRoute] string containerName, string fileName)
        {
            _logger.LogInformation($"AzureBlobStorage - GetFile - Started");

            if (string.IsNullOrEmpty(containerName) || string.IsNullOrEmpty(fileName))
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, $"Container name or File name not provided");
            }

            var result = await _azureBlobStorageService.GetFile(containerName, fileName);

            return null;
        }

        /// <summary>
        ///     Uploads file to Azure Blob Storage
        /// </summary>
        /// <param name="containerName"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("{containerName}")]
        public async Task<IActionResult> PostFile(string containerName, IFormFile formFile)
        {
            _logger.LogInformation($"AzureBlobStorage - PostFile - Started");

            if (string.IsNullOrEmpty(containerName) || formFile == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Container name or File not provided");
            }

            var result = await _azureBlobStorageService.UploadFile(containerName, formFile);

            return null;
        }
    }
}