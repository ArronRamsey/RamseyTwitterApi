using FrameworkAbstractions.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace FrameworkAbstractions.Implementations
{
    public class MemoryCacheService : ICache
    {
        private IMemoryCache MemoryCache { get; set; }
        
        private const int DefaultCacheLengthInMinutes = 60;

        public MemoryCacheService(IMemoryCache cache)
        {
            MemoryCache = cache;
        }

        public void Set(string key, object value)
        {
            MemoryCache.Remove(key);
            if (value != null)
            {
                Set(key, value, DefaultCacheLengthInMinutes);
            }
        }

        public void Set(string key, object value, int lengthInMinutes)
        {
            MemoryCache.Remove(key);
            if (value != null)
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromMinutes(DefaultCacheLengthInMinutes));
                MemoryCache.Set(key, value, cacheEntryOptions);
            }
        }

        public object Get(string key)
        {
            var entry = MemoryCache.Get(key);
            return entry;
        }

        public T Get<T>(string key)
        {
            var entry = MemoryCache.Get<T>(key);
            return entry;
        }

    }
}

