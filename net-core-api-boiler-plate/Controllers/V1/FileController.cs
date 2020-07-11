using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Controllers.V1
{
    /// <summary>
    ///     FileController
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}")]
    [ApiVersion("1")]
    public class FileController : Controller
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly ILogger _logger;
        private readonly IFileService _fileService;

        /// <summary>
        ///     TestController constructor with DI
        /// </summary>
        /// <param name="logger"></param>
        /// <param name="fileService"></param>
        public FileController(ILogger<FileController> logger, IFileService fileService)
        {
            _logger = logger;
            _fileService = fileService;
        }

        /// <summary>
        ///     Gets file based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

                var result = await _fileService.GetFile(guid);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound);
                }

                Stream stream = new MemoryStream(result.Data);

                return new FileStreamResult(stream, result.ContentType);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"GetFile - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Creates file
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
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

                var result = await _fileService.PostFile(formFile);

                if (!result)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "File could not be created");
                }

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PostFile - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Updates file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
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

                var result = await _fileService.UpdateFile(guid, formFile);

                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"PutFile - Failed - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        /// <summary>
        ///     Deletes file based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

                var result = await _fileService.DeleteFile(guid);

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