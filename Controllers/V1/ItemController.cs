using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Models.Requests;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Controllers.V1
{
    /// <summary>
    ///     TestController
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class ItemController : Controller
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly ILogger _logger;
        private readonly IItemService _itemService;

        /// <summary>
        ///     TestController constructor with DI
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="itemService"></param>
        public ItemController(ILogger<ItemController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        /// <summary>
        ///     Gets all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetItems()
        {
            _logger.LogInformation($"GetItems - Started");

            var result = await _itemService.GetItems();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Gets item based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetItem([FromRoute] string id)
        {
            Guid guid;
            var validGuid = Guid.TryParse(id, out guid);
            if (string.IsNullOrEmpty(id) || !validGuid)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Id empty or not acceptable");
            }

            _logger.LogInformation($"GetItem - Started");

            var result = await _itemService.GetItem(guid);

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Creates item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostItem([FromBody] ItemRequest item)
        {
            if (item == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Item not provided");
            }

            _logger.LogInformation($"PostItem - Started");

            var result = await _itemService.PostItem(item);

            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        ///     Updates item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutItem([FromRoute] string id, [FromBody] ItemRequest item)
        {
            Guid guid;
            var validGuid = Guid.TryParse(id, out guid);
            if (string.IsNullOrEmpty(id) || !validGuid)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Id empty or not acceptable");
            }

            if (item == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Item not provided");
            }

            _logger.LogInformation($"PutItem - Started");

            var result = await _itemService.PutItem(guid, item);

            if (result == null)
            {
                _logger.LogInformation($"PutItem - Item not found");
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Deletes item based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] string id)
        {
            Guid guid;
            var validGuid = Guid.TryParse(id, out guid);
            if (string.IsNullOrEmpty(id) || !validGuid)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Id empty or not acceptable");
            }

            _logger.LogInformation($"DeleteItem - Started");

            var result = await _itemService.DeleteItem(guid);

            if (!result)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
