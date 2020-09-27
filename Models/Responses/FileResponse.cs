using System;
using Newtonsoft.Json;

namespace net_core_api_boiler_plate.Models.Responses
{
    public class FileResponse
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }
    }
}