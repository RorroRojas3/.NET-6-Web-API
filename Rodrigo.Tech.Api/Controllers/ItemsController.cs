using Microsoft.AspNetCore.Mvc;
using Rodrigo.Rojas.Services;

namespace Rodrigo.Rojas.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
        public async Task<IActionResult> GetItems()
        {
            var items = await _itemService.GetItems();
            return Ok(items);
        }
    }
}