using System;

namespace net_core_api_boiler_plate.Database.Repository.Interface
{
    /// <summary>
    ///     IEntity interface
    /// </summary>
    public interface IEntity
    {
        /// <summary>
        ///     Id
        /// </summary>
        /// <value></value>
        public Guid Id { get; set; }
    }
}