using net_core_api_boiler_plate.Database.Repository.Interface;
using Newtonsoft.Json;
using System;

namespace net_core_api_boiler_plate.Database.Tables.Cosmos
{
    [Serializable]
    public class ItemCosmos : IEntity
    {
        [JsonProperty("id")]
        public Guid Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
