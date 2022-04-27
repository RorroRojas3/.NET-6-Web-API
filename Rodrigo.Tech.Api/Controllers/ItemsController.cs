using Microsoft.AspNetCore.Mvc;
using Rodrigo.Rojas.Repository.Sets;
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

        [HttpGet(Name = "Items")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ItemSet>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        public async Task<IActionResult> GetItems()
        {
            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(GetItems)} - " +
                $"Started");

            var items = await _itemService.GetItems();

            _logger.LogInformation($"{nameof(ItemsController)} - {nameof(GetItems)} - " +
                $"Finsihed");
            return Ok(items);
        }
    }
}