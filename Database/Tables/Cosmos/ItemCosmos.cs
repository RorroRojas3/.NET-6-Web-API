using net_core_api_boiler_plate.Database.Repository.Interface;
using System;

namespace net_core_api_boiler_plate.Database.Tables.Cosmos
{
    [Serializable]
    public class ItemCosmos : IEntity
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }
}
