using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rodrigo.Rojas.Repository.Context;
using Rodrigo.Rojas.Repository.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rodrigo.Rojas.Services
{
    public interface IItemService
    {
        Task<List<ItemSet>> GetItems();
    }

    public class ItemService : IItemService
    {
        private readonly ILogger _logger;
        private readonly DemoContext _context;

        public ItemService(ILogger<ItemService> logger, DemoContext demoContext)
        {
            _logger = logger;
            _context = demoContext;
        }

        public async Task<List<ItemSet>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }
    }
}
