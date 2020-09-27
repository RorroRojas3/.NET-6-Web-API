using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class AzureCosmosController
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
        public async Task<IActionResult> GetAllItems()
        {
            var result = await _azureCosmosService.GetAllItems();
            return null;
        }

        /// <summary>
        ///     Gets single item
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Items/{id}")]
        public async Task<IActionResult> GetItem()
        {
            var result = await _azureCosmosService.GetItem();
            return null;
        }

        /// <summary>
        ///     Creates item
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostItem()
        {
            var result = await _azureCosmosService.PostItem();
            return null;
        }

        /// <summary>
        ///     Updates item
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateItem()
        {
            var result = await _azureCosmosService.PutItem();
            return null;
        }

        /// <summary>
        ///     Deletes item
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteItem()
        {
            var result = await _azureCosmosService.DeleteItem();
            return null;
        }
    }
}