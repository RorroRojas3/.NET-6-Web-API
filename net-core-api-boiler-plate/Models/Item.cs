using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace net_core_api_boiler_plate.Models
{
    public class Item
    {
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        public string Value { get; set; }
    }
}