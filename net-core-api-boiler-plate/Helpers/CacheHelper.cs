using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;

namespace net_core_api_boiler_plate.Helpers
{
    /// <summary>
    ///     CacheHelper class
    /// </summary>
    public static class CacheHelper
    {
        /// <summary>
        ///     Gets byte array from cache based on key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static async Task<byte[]> GetAsync(string key, IDistributedCache cache)
        {
            return await cache.GetAsync(key);
        }

        /// <summary>
        ///     Sets data in cache for miliseconds
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static async Task SetDatatMillAsync(string key, byte[] data, int time, IDistributedCache cache)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMilliseconds(time));

            await cache.SetAsync(key, data, options);
        }

        /// <summary>
        ///     Sets data in cache in seconds
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static async Task SetDatatSecAsync(string key, byte[] data, int time, IDistributedCache cache)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromSeconds(time));

            await cache.SetAsync(key, data, options);
        }

        /// <summary>
        ///     Sets data in cache for minutes
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static async Task SetDatatMinAsync(string key, byte[] data, int time, IDistributedCache cache)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromMinutes(time));

            await cache.SetAsync(key, data, options);
        }

        /// <summary>
        ///     Sets data cache for hours
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static async Task SetDatatHourAsync(string key, byte[] data, int time, IDistributedCache cache)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromHours(time));

            await cache.SetAsync(key, data, options);
        }

        /// <summary>
        ///     Sets data in cache for days
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="time"></param>
        /// <param name="cache"></param>
        /// <returns></returns>
        public static async Task SetDatatDaysAsync(string key, byte[] data, int time, IDistributedCache cache)
        {
            var options = new DistributedCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromDays(time));

            await cache.SetAsync(key, data, options);
        }
    }
}