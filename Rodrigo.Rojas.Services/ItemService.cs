using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Rodrigo.Rojas.Models.Exceptions;
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
        /// <summary>
        ///     Gets items from database
        /// </summary>
        /// <returns></returns>
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
   
        /// </inheritdoc>
        public async Task<List<ItemSet>> GetItems()
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItems)} - " +
                $"Started");

            var items = await _context.Items.ToListAsync();
            if (items.Count == 0)
            {
                throw new NotFoundException($"Items not found");
            }

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItems)} - " +
                $"Finished");
            return items;
        }
    }
}
