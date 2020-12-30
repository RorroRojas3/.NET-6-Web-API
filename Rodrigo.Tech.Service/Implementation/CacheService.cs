using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Rodrigo.Tech.Service.Interface;

namespace Rodrigo.Tech.Service.Implementation
{
    public class CacheService : ICacheService
    {
        private readonly IDistributedCache _cache;

        public CacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        /// <inheritdoc/>
        public async Task<byte[]> GetAsync(string key)
        {
            return await _cache.GetAsync(key);
        }

        /// <inheritdoc/>
        public async Task SetDatatMillAsync(string key, byte[] data, int time)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMilliseconds(time));

            await _cache.SetAsync(key, data, options);
        }

        /// <inheritdoc/>
        public async Task SetDatatSecAsync(string key, byte[] data, int time)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(time));

            await _cache.SetAsync(key, data, options);
        }

        /// <inheritdoc/>
        public async Task SetDatatMinAsync(string key, byte[] data, int time)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(time));

            await _cache.SetAsync(key, data, options);
        }

        /// <inheritdoc/>
        public async Task SetDatatHourAsync(string key, byte[] data, int time)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(time));

            await _cache.SetAsync(key, data, options);
        }

        /// <inheritdoc/>
        public async Task SetDatatDaysAsync(string key, byte[] data, int time)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromDays(time));

            await _cache.SetAsync(key, data, options);
        }

        /// <inheritdoc/>
        public async Task RemoveCacheAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }
    }
}