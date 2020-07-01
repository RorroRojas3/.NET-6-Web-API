using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using net_core_api_boiler_plate.Models;
using net_core_api_boiler_plate.Services.Interface;

namespace net_core_api_boiler_plate.Services.Implementation
{
    public class TestService : ITestService
    {
        public async Task<Item> DeleteItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> GetItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Item>> GetItems()
        {
            throw new NotImplementedException();
        }

        public async Task<Item> PostItem(Item item)
        {
            throw new NotImplementedException();
        }

        public async Task<Item> PutItem(Item item1)
        {
            throw new NotImplementedException();
        }
    }
}