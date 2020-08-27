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
    [Serializable]
    [Table(nameof(Item), Schema = nameof(Schemas.Example))]
    public class Item : IEntity
    {
        /// <summary>
        ///     Id
        /// </summary>
        /// <value></value>
        [Key]
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        ///     Name
        /// </summary>
        /// <value></value>
        [Required]
        public string Name { get; set; }

        /// <summary>
        ///     Value
        /// </summary>
        /// <value></value>
        [Required]
        public string Value { get; set; }
    }
}