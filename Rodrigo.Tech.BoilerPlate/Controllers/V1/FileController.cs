using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rodrigo.Tech.Service.Interface;

namespace Rodrigo.Tech.BoilerPlate.Controllers.V1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class FileController : Controller
    {
        private readonly ILogger _logger;
        private readonly IFileService _fileService;

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
        public async Task<IActionResult> GetFile(Guid id)
        {
            _logger.LogInformation($"{nameof(FileController)} - {nameof(GetFile)} - Started, " +
                $"{nameof(id)}: {id}");

            var result = await _fileService.GetFile(id);

            if (result == null)
            {
                _logger.LogError($"{nameof(FileController)} - {nameof(GetFile)} - Not found, " +
               $"{nameof(id)}: {id}");
                return StatusCode(StatusCodes.Status404NotFound);
            }

            Stream stream = new MemoryStream(result.Data);

            _logger.LogInformation($"{nameof(FileController)} - {nameof(GetFile)} - Finished, " +
               $"{nameof(id)}: {id}");
            return new FileStreamResult(stream, result.ContentType);
        }

        /// <summary>
        ///     Creates file
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> PostFile([FromBody] IFormFile formFile)
        {
            _logger.LogInformation($"{nameof(FileController)} - {nameof(PostFile)} - Started");

            var result = await _fileService.PostFile(formFile);

            if (!result)
            {
                _logger.LogError($"{nameof(FileController)} - {nameof(PostFile)} - File could not be created");
                return StatusCode(StatusCodes.Status400BadRequest, "File could not be created");
            }

            _logger.LogInformation($"{nameof(FileController)} - {nameof(PostFile)} - Finished");
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
        public async Task<IActionResult> PutFile(Guid id, [FromBody] IFormFile formFile)
        {
            _logger.LogInformation($"{nameof(FileController)} - {nameof(PutFile)} - Started, " +
                $"{nameof(id)}: {id}");

            await _fileService.UpdateFile(id, formFile);

            _logger.LogInformation($"{nameof(FileController)} - {nameof(PutFile)} - Finished, " +
                $"{nameof(id)}: {id}");
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Deletes file based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteFile(Guid id)
        {
            _logger.LogInformation($"{nameof(FileController)} - {nameof(DeleteFile)} - Started, " +
                $"{nameof(id)}: {id}");

            await _fileService.DeleteFile(id);

            _logger.LogInformation($"{nameof(FileController)} - {nameof(DeleteFile)} - Finished, " +
                $"{nameof(id)}: {id}");
            return StatusCode(StatusCodes.Status200OK);
        }

        /// <summary>
        ///     Get all files
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllFiles()
        {
            _logger.LogInformation($"{nameof(FileController)} - {nameof(GetAllFiles)} - Started");

            var result = await _fileService.GetAllFiles();

            _logger.LogInformation($"{nameof(FileController)} - {nameof(GetAllFiles)} - Finished");
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}