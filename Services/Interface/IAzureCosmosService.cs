using System.Threading.Tasks;

namespace net_core_api_boiler_plate.Services.Interface
{
    /// <summary>
    ///     IAzureCosmos Interface
    /// </summary>
    public interface IAzureCosmosService
    {
        /// <summary>
        ///     Gets all items from Azure Cosmos DB
        /// </summary>
        /// <returns></returns>
        Task<object> GetAllItems();

        /// <summary>
        ///     Gets single item from Azure Cosmos DB
        /// </summary>
        /// <returns></returns>
        Task<object> GetItem();

        /// <summary>
        ///     Creates item on Azure Cosmos DB
        /// </summary>
        /// <returns></returns>
        Task<object> PostItem();

        /// <summary>
        ///     Updates item on Azure Cosmos DB
        /// </summary>
        /// <returns></returns>
        Task<object> PutItem();


        /// <summary>
        ///     Deletes item from Azure Cosmos DB
        /// </summary>
        /// <returns></returns>
        Task<object> DeleteItem();
    }
}