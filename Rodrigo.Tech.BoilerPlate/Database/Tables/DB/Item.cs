using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rodrigo.Tech.BoilerPlate.Database.Repository.Interface;
using Newtonsoft.Json;

namespace Rodrigo.Tech.BoilerPlate.Database.Tables
{
    [Serializable]
    [Table(nameof(Item), Schema = nameof(Schemas.Example))]
    public class Item : IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Value { get; set; }
    }
}