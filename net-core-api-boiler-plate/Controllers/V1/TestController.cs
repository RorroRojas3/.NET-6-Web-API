using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Models;

namespace net_core_api_boiler_plate.Controllers.V1
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : Controller
    {
        private readonly ILogger _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                _logger.LogInformation($"GetItems - Started");
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetItems - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet]
        [Route("Item")]
        public async Task<IActionResult> GetItem(string id)
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
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("Item")]
        public async Task<IActionResult> PostItem(Item item)
        {
            try
            {
                _logger.LogInformation($"PostItem - Started");
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PostItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("Item")]
        public async Task<IActionResult> PutItem(Item item)
        {
            try
            {
                _logger.LogInformation($"PutItem - Started");
                return StatusCode(StatusCodes.Status200OK);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PutItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("Item")]
        public async Task<IActionResult> DeleteItem(string id)
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
