using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rodrigo.Rojas.Models.Dtos;
using Rodrigo.Rojas.Models.Exceptions;
using Rodrigo.Rojas.Models.Requests;
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
        Task<List<ItemDto>> GetItemsAsync();

        /// <summary>
        ///     Gets item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ItemDto> GetItemAsync(int id);

        /// <summary>
        ///     Creates an item
        /// </summary>
        /// <param name="itemSet"></param>
        /// <returns></returns>
        Task<ItemDto> CreateItemAsync(ItemRequest itemSet);

        /// <summary>
        ///     Updates an item by id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<ItemDto> UpdateItemAsync(int id, ItemRequest request);

        /// <summary>
        ///     Deletes item by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task DeleteItemAsync(int id);
    }

    public class ItemService : IItemService
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly DemoContext _context;

        public ItemService(ILogger<ItemService> logger, IMapper mapper, DemoContext demoContext)
        {
            _logger = logger;
            _mapper = mapper;
            _context = demoContext;
        }
   
        /// </inheritdoc>
        public async Task<List<ItemDto>> GetItemsAsync()
        {
            var items = await _context.Items.ToListAsync();
            if (items.Count == 0)
            {
                throw new NotFoundException($"Items not found");
            }

            return _mapper.Map<List<ItemDto>>(items);
        }

        /// </inheritdoc>
        public async Task<ItemDto> GetItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                throw new NotFoundException($"Item with {nameof(id)}: {id} not found");
            }

            return _mapper.Map<ItemDto>(item);
        }

        /// </inheritdoc>
        public async Task<ItemDto> CreateItemAsync(ItemRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException("Item cannot be null.");
            }

            var newItem = _mapper.Map<ItemSet>(request);
            await _context.AddAsync(newItem);
            await _context.SaveChangesAsync();

            return _mapper.Map<ItemDto>(newItem);
        }

        /// </inheritdoc>
        public async Task<ItemDto> UpdateItemAsync(int id, ItemRequest request)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                throw new NotFoundException($"Item with {nameof(id)}: {id} not found");
            }

            _mapper.Map(request, item);
            _context.Update(item);
            await _context.SaveChangesAsync();

            return _mapper.Map<ItemDto>(item);
        }

        /// </inheritdoc>
        public async Task DeleteItemAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                throw new NotFoundException($"Item with {nameof(id)}: {id} not found");
            }

            _context.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
