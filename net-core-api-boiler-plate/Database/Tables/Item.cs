using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using net_core_api_boiler_plate.Database.Repository.Interface;
using Newtonsoft.Json;

namespace net_core_api_boiler_plate.Database.Tables
{
    [Table(nameof(Item), Schema = nameof(Schemas.Example))]
    public class Item : IEntity
    {
        [Key]
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}