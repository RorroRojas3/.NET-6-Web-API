using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Database.Tables.Cosmos;
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
        private readonly IItemCosmosService _itemCosmosService;

        public AzureCosmosController(ILogger<AzureCosmosController> logger,
                                        IItemCosmosService itemCosmosService)
        {
            _logger = logger;
            _itemCosmosService = itemCosmosService;
        }

        /// <summary>
        ///     Gets all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Item")]
        public IActionResult GetAllItems()
        {
            var result = _itemCosmosService.GetAllItems();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Gets single item
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("Items/{id}")]
        public async Task<IActionResult> GetItem(string id)
        {
            var result = await _itemCosmosService.GetItem(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Creates item
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostItem(ItemRequest request)
        {
            var result = await _itemCosmosService.PostItem(request);
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        ///     Updates item
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateItem(string id, ItemRequest request)
        {
            var result = await _itemCosmosService.PutItem(id, request);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Deletes item
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteItem(string id)
        {
            await _itemCosmosService.DeleteItem(id);
            return StatusCode(StatusCodes.Status200OK, true);
        }
    }
}