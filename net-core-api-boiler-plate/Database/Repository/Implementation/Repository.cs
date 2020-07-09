using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using net_core_api_boiler_plate.Database.DB;
using net_core_api_boiler_plate.Database.Repository.Interface;
using System.Linq;

namespace net_core_api_boiler_plate.Database.Repository.Implementation
{
    /// <summary>
    ///     Repository class which implements IRepository interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        /// <summary>
        ///     Private and protected variables
        /// </summary>
        protected readonly DatabaseContext _dbContext;
        private DbSet<T> _entities;

        /// <summary>
        ///     Repository constructor with DI
        /// </summary>
        /// <param name="dbContext"></param>
        public Repository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _entities = dbContext.Set<T>();
        }

        /// <summary>
        ///     Adds T item to DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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

        /// <summary>
        ///     Deletes T item from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        ///     Gets T item from DB based on Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<T> Get(Guid id)
        {
            return await _entities.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        ///     Gets list of T from DB
        /// </summary>
        /// <returns></returns>
        public async Task<List<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        /// <summary>
        ///     Gets T with LINQ expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public T GetWithExpression(Func<T, bool> predicate)
        {
            return _entities.Where(predicate).FirstOrDefault();
        }

        /// <summary>
        ///     Gets list of T with LINQ expression
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetAllWithExpression(Func<T, bool> predicate)
        {
            return _entities.Where(predicate).ToList();
        }

        /// <summary>
        ///     Updates T on DB
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
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