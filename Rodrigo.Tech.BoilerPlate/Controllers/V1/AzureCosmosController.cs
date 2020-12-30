using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rodrigo.Tech.Model.Requests;
using Rodrigo.Tech.Service.Interface;

namespace Rodrigo.Tech.BoilerPlate.Controllers.V1
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
            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(GetAllItems)} - Started");
            var result = _itemCosmosService.GetAllItems();

            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(GetAllItems)} - Finished");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Gets item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Items/{id}")]
        public async Task<IActionResult> GetItem(Guid id)
        {
            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(GetItem)} - Started, " +
                $"{nameof(id)}: {id}");

            var result = await _itemCosmosService.GetItem(id);

            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(GetItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Creates item
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostItem(ItemRequest request)
        {
            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(PostItem)} - Started, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var result = await _itemCosmosService.PostItem(request);

            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(PostItem)} - Finished, " +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return StatusCode(StatusCodes.Status201Created, result);
        }

        /// <summary>
        ///     Updates item
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, ItemRequest request)
        {
            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(UpdateItem)} - Started, " +
                $"{nameof(id)}: {id}" +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");

            var result = await _itemCosmosService.PutItem(id, request);

            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(UpdateItem)} - Finished, " +
                $"{nameof(id)}: {id}" +
                $"{nameof(ItemRequest)}: {JsonConvert.SerializeObject(request)}");
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /// <summary>
        ///     Deletes item
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(DeleteItem)} - Started, " +
                $"{nameof(id)}: {id}");

            var result = await _itemCosmosService.DeleteItem(id);

            _logger.LogInformation($"{nameof(AzureCosmosController)} - {nameof(DeleteItem)} - Finished, " +
                $"{nameof(id)}: {id}");
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}