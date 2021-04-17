using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Rodrigo.Tech.Model.Enums;

namespace Rodrigo.Tech.Service.Interface
{
    public interface IHttpClientService
    {
        /// <summary>
        ///     GET/POST/DELETE/PUT Json
        /// </summary>
        /// <param name="url"></param>
        /// <param name="httpCall"></param>
        /// <param name="headers"></param>
        /// <param name="body"></param>
        /// 
        /// <returns></returns>
        Task<HttpResponseMessage> Json(string url, HttpCallEnum httpCall, Dictionary<string, string> headers = null, object body = default);
    }
}
