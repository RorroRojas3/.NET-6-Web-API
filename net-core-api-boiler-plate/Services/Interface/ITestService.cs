using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using net_core_api_boiler_plate.Database.Tables;

namespace net_core_api_boiler_plate.Services.Interface
{
    public interface ITestService
    {
        Task<List<Item>> GetItems();

        Task<Item> GetItem(Guid id);

        Task<Item> PostItem(Item item);

        Task<Item> PutItem(Item item1);

        Task<bool> DeleteItem(Guid id);

        Task<byte[]> GetFile(Guid id);

        Task<bool> PostFile(IFormFile formFile);

        Task<bool> DeleteFile(Guid id);

        Task<bool> UpdateFile(Guid id);
    }
}