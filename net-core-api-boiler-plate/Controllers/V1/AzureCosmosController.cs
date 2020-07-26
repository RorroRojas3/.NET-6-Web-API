using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace net_core_api_boiler_plate.Controllers.V1
{
    /// <summary>
    ///     AzureCosmosController
    /// </summary>
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1")]
    public class AzureCosmosController
    {
        /// <summary>
        ///     Private variables
        /// </summary>
        private readonly ILogger _logger;

        /// <summary>
        ///     Constructor for AzureCosmosController
        /// </summary>
        /// <param name="logger"></param>
        public AzureCosmosController(ILogger<AzureCosmosController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItems()
        {
            return null;
        }
    }
}