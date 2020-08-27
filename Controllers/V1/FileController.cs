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
    [Route("api/v{version:apiVersion}/[controller]")]
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
        [Route("{id}")]
        public async Task<IActionResult> GetFile(string id)
        {
            _logger.LogInformation($"GetFile - Started");

            Guid guid;
            var validGuid = Guid.TryParse(id, out guid);
            if (string.IsNullOrEmpty(id) || !validGuid)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "Id empty or not acceptable");
            }

            var result = await _fileService.GetFile(guid);

            if (result == null)
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }

            Stream stream = new MemoryStream(result.Data);

            return new FileStreamResult(stream, result.ContentType);
        }

        /// <summary>
        ///     Creates file
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostFile(IFormFile formFile)
        {
            _logger.LogInformation($"PostFile - Started");

            if (formFile == null)
            {
                return StatusCode(StatusCodes.Status406NotAcceptable, "File not provided");
            }

            var result = await _fileService.PostFile(formFile);

            if (!result)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "File could not be created");
            }

            return StatusCode(StatusCodes.Status201Created);
        }

        /// <summary>
        ///     Updates file
        /// </summary>
        /// <param name="id"></param>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> PutFile(string id, IFormFile formFile)
        {
            _logger.LogInformation($"PutFile - Started");

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

        /// <summary>
        ///     Deletes file based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFile(string id)
        {
            _logger.LogInformation($"DeleteFile - Started");

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

        /// <summary>
        ///     Get all files
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            _logger.LogInformation($"GetAllFiles - Started");

            var result = await _fileService.GetAllFiles();

            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}