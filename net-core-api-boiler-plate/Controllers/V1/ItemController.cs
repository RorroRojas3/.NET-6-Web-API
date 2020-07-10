using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Controllers.V1
{
    /// <summary>
    ///     TestController
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}")]
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
        [Route("Items")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                _logger.LogInformation($"GetItems - Started");

                var result = await _itemService.GetItems();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetItems - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Gets item based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Item/{id}")]
        public async Task<IActionResult> GetItem([FromRoute] string id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogInformation($"GetItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Creates item 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Item")]
        public async Task<IActionResult> PostItem([FromBody] Item item)
        {
            try
            {
                if (item == null)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "Item not provided");
                }

                _logger.LogInformation($"PostItem - Started");

                var result = await _itemService.PostItem(item);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PostItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Updates item
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("Item")]
        public async Task<IActionResult> PutItem([FromBody] Item item)
        {
            try
            {
                if (item == null)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "Item not provided");
                }

                _logger.LogInformation($"PutItem - Started");

                var result = await _itemService.PutItem(item);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PutItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Deletes item based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("Item/{id}")]
        public async Task<IActionResult> DeleteItem([FromRoute] string id)
        {
            try
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
            catch (Exception ex)
            {
                _logger.LogInformation($"DeleteItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
