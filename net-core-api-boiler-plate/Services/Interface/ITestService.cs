using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using net_core_api_boiler_plate.Database.Tables;

namespace net_core_api_boiler_plate.Services.Interface
{
    public interface ITestService
    {
        Task<List<Item>> GetItems();

        Task<Item> GetItem(Guid id);

        Task<Item> PostItem(Item item);

        Task<Item> PutItem(Item item1);

        Task<Item> DeleteItem(Guid id);
    }
}