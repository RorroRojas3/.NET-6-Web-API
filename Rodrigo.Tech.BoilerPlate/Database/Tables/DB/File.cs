using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Rodrigo.Tech.BoilerPlate.Database.Repository.Interface;

namespace Rodrigo.Tech.BoilerPlate.Database.Tables
{
    [Table(nameof(File), Schema = nameof(Schemas.Example))]
    public class File : IEntity
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string ContentType { get; set; }

        [Required]
        public byte[] Data { get; set; }
    }
}