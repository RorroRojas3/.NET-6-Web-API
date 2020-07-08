using System;

namespace net_core_api_boiler_plate.Database.Repository.Interface
{
    public interface IEntity
    {
        public Guid Id { get; set; }
    }
}