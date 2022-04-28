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
        Task<List<ItemSet>> GetItemsAsync();

        /// <summary>
        ///     Gets item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ItemSet> GetItemAsync(int id);

        /// <summary>
        ///     Creates 
        /// </summary>
        /// <param name="itemSet"></param>
        /// <returns></returns>
        Task<ItemSet> CreateItemAsync(ItemSet itemSet);
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
        public async Task<List<ItemSet>> GetItemsAsync()
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItemsAsync)} - " +
                $"Started");

            var items = await _context.Items.ToListAsync();
            if (items.Count == 0)
            {
                throw new NotFoundException($"Items not found");
            }

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItemsAsync)} - " +
                $"Finished");
            return items;
        }

        /// </inheritdoc>
        public async Task<ItemSet> GetItemAsync(int id)
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItemAsync)} - " +
                $"Started");

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                throw new NotFoundException($"Item with {nameof(id)}: {id} not found");
            }

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(GetItemAsync)} - " +
                $"Finished");
            return item;
        }

        /// </inheritdoc>
        public async Task<ItemSet> CreateItemAsync(ItemSet itemSet)
        {
            _logger.LogInformation($"{nameof(ItemService)} - {nameof(CreateItemAsync)} - " +
                $"Started");

            if (itemSet == null)
            {
                throw new ArgumentNullException($"Item cannot be null.");
            }

            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == itemSet.Id);
            if (item != null)
            {
                throw new ConflictException($"Item already exists with {nameof(item.Id)}: {item.Id}");
            }

            await _context.AddAsync(itemSet);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"{nameof(ItemService)} - {nameof(CreateItemAsync)} - " +
                $"Finished");
            return itemSet;
        }
    }
}
