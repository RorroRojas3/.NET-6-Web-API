using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Json;
using Rodrigo.Tech.Service.Interface;
using Rodrigo.Tech.Model.Enums;

namespace Rodrigo.Tech.Service.Implementation
{
    public class HttpClientService : IHttpClientService
    {
        private readonly ILogger _logger;

        public HttpClientService(ILogger<HttpClientService> logger)
        {
            _logger = logger;
        }

        /// <inheritdoc/>
        public async Task<HttpResponseMessage> Json(string url, HttpCallEnum httpCall, Dictionary<string, string> headers = null, object body = default)
        {
            _logger.LogInformation($"{nameof(HttpClientService)} - {nameof(Json)} - Started, " +
                $"{nameof(url)}: {url}, " +
                $"{nameof(body)}: {JsonConvert.SerializeObject(body)}, " +
                $"{nameof(httpCall)}: {httpCall}");

            using var client = CreateClient();
            HttpResponseMessage httpResponseMessage = null;
            if (headers != null)
            {
                foreach (var item in headers)
                {
                    client.DefaultRequestHeaders.Add(item.Key, item.Value);
                }
            }

            switch (httpCall)
            {
                case HttpCallEnum.GET:
                    httpResponseMessage = await client.GetAsync(url);
                    break;
                case HttpCallEnum.POST:
                    httpResponseMessage = await client.PostAsJsonAsync(url, body);
                    break;
                case HttpCallEnum.PUT:
                    httpResponseMessage = await client.PutAsJsonAsync(url, body);
                    break;
                case HttpCallEnum.DELETE:
                    httpResponseMessage = await client.DeleteAsync(url);
                    break;
                default:
                    break;
            }

            _logger.LogInformation($"{nameof(HttpClientService)} - {nameof(Json)} - Finished, " +
                $"{nameof(url)}: {url}, " +
                $"{nameof(body)}: {JsonConvert.SerializeObject(body)}, " +
                $"{nameof(httpCall)}: {httpCall}");
            return httpResponseMessage;
        }

        /// <summary>
        ///     Creates HttpClient 
        /// </summary>
        /// <returns></returns>
        private HttpClient CreateClient()
        {
            var httpClientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) =>
                {
                    return true;
                }
            };
            var httpClient = new HttpClient(httpClientHandler);
            return httpClient;
        }
    }
}
