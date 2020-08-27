using System;
using Newtonsoft.Json;

namespace net_core_api_boiler_plate.Models.Responses
{
    /// <summary>
    ///     FileResponse class
    /// </summary>
    public class FileResponse
    {
        /// <summary>
        ///     Id
        /// </summary>
        /// <value></value>
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        ///  ContentType
        /// </summary>
        /// <value></value>
        public string ContentType { get; set; }
    }
}