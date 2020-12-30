using Newtonsoft.Json;
using System;
using Rodrigo.Tech.Respository.Pattern.Interface;

namespace Rodrigo.Tech.Respository.Tables.Cosmos
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
