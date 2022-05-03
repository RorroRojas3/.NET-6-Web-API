using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Rodrigo.Rojas.Models.Dtos;
using Rodrigo.Rojas.Models.Requests;
using Rodrigo.Rojas.Services;

namespace Rodrigo.Rojas.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IItemService _itemService;

        public ItemsController(ILogger<ItemsController> logger, IItemService itemService)
        {
            _logger = logger;
            _itemService = itemService;
        }

        /// <summary>
        ///     Gets all items
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ItemDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetItems()
        {
            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(GetItems)} - " +
                $"Started");

            var items = await _itemService.GetItemsAsync();

            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(GetItems)} - " +
                $"Finsihed");
            return Ok(items);
        }

        /// <summary>
        ///     Gets item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetItem(int id)
        {
            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(GetItems)} - " +
                $"Started");

            var items = await _itemService.GetItemAsync(id);

            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(GetItems)} - " +
                $"Finsihed");
            return Ok(items);
        }

        /// <summary>
        ///     Creates a new item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(ItemDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> CreateItem(ItemRequest request)
        {
            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(CreateItem)} - " +
                $"Started, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var items = await _itemService.CreateItemAsync(request);

            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(CreateItem)} - " +
                $"Finsihed, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return StatusCode(StatusCodes.Status201Created, items);
        }

        /// <summary>
        ///     Updates an item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> UpdateItem(int id, ItemRequest request)
        {
            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(UpdateItem)} - " +
                $"Started, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var items = await _itemService.UpdateItemAsync(id, request);

            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(UpdateItem)} - " +
                $"Finsihed, " +
                $"{nameof(id)}: {id}, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return StatusCode(StatusCodes.Status200OK, items);
        }

        /// <summary>
        ///     Deletes item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> DeleteItem(int id)
        {
            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(DeleteItem)} - " +
                $"Started, " +
                $"{nameof(id)}: {id}");

            await _itemService.DeleteItemAsync(id);

            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(DeleteItem)} - " +
                $"Finsihed, " +
                $"{nameof(id)}: {id}");
            return StatusCode(StatusCodes.Status200OK);
        }
    }
}