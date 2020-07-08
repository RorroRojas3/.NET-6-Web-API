using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Database.Tables;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1")]
    public class TestController : Controller
    {
        // Private variables
        private readonly ILogger _logger;
        private readonly ITestService _testService;

        public TestController(ILogger<TestController> logger, ITestService testService)
        {
            _logger = logger;
            _testService = testService;
        }

        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                _logger.LogInformation($"GetItems - Started");

                var result = await _testService.GetItems();
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetItems - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

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

                var result = await _testService.GetItem(guid);

                return StatusCode(StatusCodes.Status200OK, result);

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

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

                var result = await _testService.PostItem(item);

                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PostItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

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

                var result = await _testService.PutItem(item);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PutItem - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

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

                var result = await _testService.DeleteItem(guid);

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

        [HttpGet]
        [Route("File/{id}")]
        public async Task<IActionResult> GetFile(string id)
        {
            try
            {
                Guid guid;
                var validGuid = Guid.TryParse(id, out guid);
                if (string.IsNullOrEmpty(id) || !validGuid)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "Id empty or not acceptable");
                }

                _logger.LogInformation($"GetFile - Started");
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetFile - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        [Route("File")]
        public async Task<IActionResult> PostFile(IFormFile formFile)
        {
            try
            {
                if (formFile == null)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "File not provided");
                }

                _logger.LogInformation($"PostFile - Started");
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PostFile - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        [Route("File/{id}")]
        public async Task<IActionResult> PutFile(string id, IFormFile formFile)
        {
            try
            {
                Guid guid;
                var validGuid = Guid.TryParse(id, out guid);
                if (string.IsNullOrEmpty(id) || !validGuid)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "Id empty or not acceptable");
                }

                if (formFile == null)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "File not provided");
                }

                _logger.LogInformation($"PutFile - Started");
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PutFile - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        [Route("File/{id}")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            try
            {
                Guid guid;
                var validGuid = Guid.TryParse(id, out guid);
                if (string.IsNullOrEmpty(id) || !validGuid)
                {
                    return StatusCode(StatusCodes.Status406NotAcceptable, "Id empty or not acceptable");
                }

                _logger.LogInformation($"PutFile - Started");
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PutFile - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
