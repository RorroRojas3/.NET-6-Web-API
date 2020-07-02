using System;
using System.Threading.Tasks;

namespace net_core_api_boiler_plate.Database.Repository.Interface
{
    public interface IRepository
    {
        Task<T> GetAll<T>();
        Task<T> Get<T>(Guid id);
        Task<T> Add<T>(T item);
        Task<T> Update<T>(T item);
        Task Delete(Guid id);
    }
}