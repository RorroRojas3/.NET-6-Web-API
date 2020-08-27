using System.Collections.Generic;

namespace net_core_api_boiler_plate.Models.Settings
{
    /// <summary>
    ///     CosmoDb class
    /// </summary>
    public class CosmosDb
    {
        /// <summary>
        ///     Name of database
        /// </summary>
        /// <value></value>
        public string DatabaseName { get; set; }

        /// <summary>
        ///     List of container
        /// </summary>
        /// <value></value>
        public List<ContainerCollection> ContainerCollection { get; set; }

        /// <summary>
        ///     Account
        /// </summary>
        /// <value></value>
        public string Account { get; set; }

        /// <summary>
        ///     Key
        /// </summary>
        /// <value></value>
        public string Key { get; set; }
    }

    /// <summary>
    ///     ContainerCollection class
    /// </summary>
    public class ContainerCollection
    {
        /// <summary>
        ///     Name
        /// </summary>
        /// <value></value>
        public string Name { get; set; }

        /// <summary>
        ///     Partition key
        /// </summary>
        /// <value></value>
        public string PartitionKey { get; set; }
    }
}