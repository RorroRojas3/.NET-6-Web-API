using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net_core_api_boiler_plate.Database.DB;
using net_core_api_boiler_plate.Database.Repository.Interface;
using System.Linq;

namespace net_core_api_boiler_plate.Database.Repository.Implementation
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        // Private and Protected variables
        protected readonly DatabaseContext _dbContext;
        private DbSet<T> _entities;

        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        public async Task<T> Add(T entity)
        {
            T doesExit = await _entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (doesExit != null)
            {
                return default(T);
            }

            await _entities.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            T entity = await _entities.FirstOrDefaultAsync(x => x.Id == id);

            if (entity == null)
            {
                return false;
            }

            _entities.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(Guid id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetWithExpression(Func<T, bool> predicate)
        {
            return _entities.Where(predicate).FirstOrDefault();
        }

        public async Task<List<T>> GetAllWithExpression(Func<T, bool> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        public async Task<T> Update(T entity)
        {
            T doesExit = await _entities.FirstOrDefaultAsync(x => x.Id == entity.Id);

            if (doesExit == null)
            {
                return default(T);
            }

            _entities.Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }
    }
}