using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rodrigo.Tech.Model.Requests;
using Rodrigo.Tech.Service.Interface;

namespace Rodrigo.Tech.BoilerPlate.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class ItemController : Controller
    {
        private readonly ILogger _logger;
        private readonly IItemService _itemService;

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
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            _logger.LogInformation($"GetItem - Started");

            var result = await _itemService.GetItem(id);

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
        public async Task<IActionResult> PutItem([FromRoute] Guid id, [FromBody] ItemRequest item)
        {
            _logger.LogInformation($"PutItem - Started");

            var result = await _itemService.PutItem(id, item);

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
        public async Task<IActionResult> DeleteItem([FromRoute] Guid id)
        {
            _logger.LogInformation($"DeleteItem - Started");

            var result = await _itemService.DeleteItem(id);

            if (!result)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            return StatusCode(StatusCodes.Status200OK);
        }
    }
}
