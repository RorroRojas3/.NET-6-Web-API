using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rodrigo.Tech.Model.Requests;
using Rodrigo.Tech.Model.Response;
using Rodrigo.Tech.Service.Interface;

namespace Rodrigo.Tech.BoilerPlate.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    [Authorize]
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
        [Produces("application/json")]
        [ProducesResponseType(typeof(List<ItemResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItems()
        {
            _logger.LogInformation($"{nameof(ItemController)} - {nameof(GetItems)} - Started");

            var result = await _itemService.GetItems();

            if (result == null)
            {
                _logger.LogInformation($"{nameof(ItemController)} - {nameof(GetItems)} - Not found");
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _logger.LogInformation($"{nameof(ItemController)} - {nameof(GetItems)} - Finished");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Gets item based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetItem([FromRoute] Guid id)
        {
            _logger.LogInformation($"{nameof(ItemController)} - {nameof(GetItem)} - Started, " +
                $"{nameof(id)}: {id}");

            var result = await _itemService.GetItem(id);

            if (result == null)
            {
                _logger.LogError($"{nameof(ItemController)} - {nameof(GetItem)} - Not found, " +
                $"{nameof(id)}: {id}");
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _logger.LogInformation($"{nameof(ItemController)} - {nameof(GetItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Creates item 
        /// </summary>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "name": "example",
        ///        "value": "example"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpPost]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status201Created)]
        public async Task<IActionResult> PostItem([FromBody] ItemRequest request)
        {
            _logger.LogInformation($"{nameof(ItemController)} - {nameof(PostItem)} - Started, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var result = await _itemService.PostItem(request);

            _logger.LogInformation($"{nameof(ItemController)} - {nameof(PostItem)} - Finished, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        ///     Updates item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <remarks>
        /// Sample request:
        ///
        ///     {
        ///        "name": "example",
        ///        "value": "example"
        ///     }
        ///
        /// </remarks>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(ItemResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> PutItem([FromRoute] Guid id, [FromBody] ItemRequest request)
        {
            _logger.LogInformation($"{nameof(ItemController)} - {nameof(PutItem)} - Started, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var result = await _itemService.PutItem(id, request);

            if (result == null)
            {
                _logger.LogError($"{nameof(ItemController)} - {nameof(PutItem)} - Not found, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _logger.LogInformation($"{nameof(ItemController)} - {nameof(PutItem)} - Finished, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Deletes item based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteItem([FromRoute] Guid id)
        {
            _logger.LogInformation($"{nameof(ItemController)} - {nameof(DeleteItem)} - Started, " +
                $"{nameof(id)}: {id}");

            var result = await _itemService.DeleteItem(id);

            if (!result)
            {
                _logger.LogError($"{nameof(ItemController)} - {nameof(DeleteItem)} - Not found, " +
                $"{nameof(id)}: {id}");
                return StatusCode(StatusCodes.Status404NotFound);
            }

            _logger.LogInformation($"{nameof(ItemController)} - {nameof(DeleteItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
