using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using net_core_api_boiler_plate.Database.Repository.Interface;
using Newtonsoft.Json;

namespace net_core_api_boiler_plate.Database.Tables
{
    /// <summary>
    ///     Item table
    /// </summary>
    [Table(nameof(Item), Schema = nameof(Schemas.Example))]
    public class Item : IEntity
    {
        /// <summary>
        ///     Id
        /// </summary>
        /// <value></value>
        [Key]
        [Required]
        [JsonProperty("id")]
        public Guid Id { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        ///     Value
        /// </summary>
        /// <value></value>
        public string Value { get; set; }
    }
}