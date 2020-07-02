using System;
using System.Threading.Tasks;
using net_core_api_boiler_plate.Database.Repository.Interface;

namespace net_core_api_boiler_plate.Database.Repository.Implementation
{
    public class Repository : IRepository
    {
        public Task<T> Add<T>(T item)
        {
            throw new NotImplementedException();
        }

        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get<T>(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAll<T>()
        {
            throw new NotImplementedException();
        }

        public Task<T> Update<T>(T item)
        {
            throw new NotImplementedException();
        }
    }
}