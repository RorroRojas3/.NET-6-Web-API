using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace net_core_api_boiler_plate.Database.Repository.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> GetWithExpression(Func<T, bool> predicate);
        Task<List<T>> GetAllWithExpression(Func<T, bool> predicate);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<bool> Delete(Guid id);
    }
}