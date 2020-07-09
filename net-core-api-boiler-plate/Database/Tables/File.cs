using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using net_core_api_boiler_plate.Database.Repository.Interface;

namespace net_core_api_boiler_plate.Database.Tables
{
    /// <summary>
    ///     File table
    /// </summary>
    [Table(nameof(File), Schema = nameof(Schemas.Example))]
    public class File : IEntity
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
        public string Name { get; set; }

        /// <summary>
        ///  ContentType
        /// </summary>
        /// <value></value>
        public string ContentType { get; set; }

        /// <summary>
        ///     Data
        /// </summary>
        /// <value></value>
        public byte[] Data { get; set; }
    }
}