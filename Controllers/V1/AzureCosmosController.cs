using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Models.Requests;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class AzureCosmosController : Controller
    {
        private readonly ILogger _logger;
        private readonly IAzureCosmosService _azureCosmosService;

        public AzureCosmosController(ILogger<AzureCosmosController> logger,
                                        IAzureCosmosService azureCosmosService)
        {
            _logger = logger;
            _azureCosmosService = azureCosmosService;
        }

        /// <summary>
        ///     Gets all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Item")]
        public IActionResult GetAllItems(string dataBaseName, string containerName)
        {
            var result = _azureCosmosService.GetAllItems<Item>(dataBaseName, containerName);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Gets single item
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Items/{id}")]
        public async Task<IActionResult> GetItem(string id, string dataBaseName, string containerName)
        {
            var result = await _azureCosmosService.GetItem<Item>(id, dataBaseName, containerName);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Creates item
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostItem(string id, string dataBaseName, string containerName, ItemRequest request)
        {
            var result = await _azureCosmosService.PostItem(request, id, dataBaseName, containerName);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        ///     Updates item
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateItem(string id, string dataBaseName, string containerName, ItemRequest request)
        {
            var result = await _azureCosmosService.PutItem(id, request, dataBaseName, containerName);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Deletes item
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(string id, string dataBaseName, string containerName)
        {
            await _azureCosmosService.DeleteItem(id, dataBaseName, containerName);
            return StatusCode(StatusCodes.Status200OK, true);
        }
    }
}