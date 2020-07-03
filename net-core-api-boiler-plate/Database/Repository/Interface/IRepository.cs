using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace net_core_api_boiler_plate.Database.Repository.Interface
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(Guid id);
    }
}