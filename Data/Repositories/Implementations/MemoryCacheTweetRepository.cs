using FrameworkAbstractions.Interfaces;
using Data.Repositories.Interfaces;
using Entities;

namespace Data.Repositories.Implementations
{
    public class MemoryCacheTweetRepository : ITweetRepository
    {
        private ICacheService MemoryCache { get; }

        private string CacheKey = "ABCD1234_AllTweets";

        public MemoryCacheTweetRepository(ICacheService cache)
        {
            MemoryCache = cache;
        }

        public IEnumerable<TweetEntity> GetAll()
        {
            if (MemoryCache.Get<List<TweetEntity>>(CacheKey) == null)
            {
                MemoryCache.Set(CacheKey, new List<TweetEntity>());
            }
            return MemoryCache.Get<List<TweetEntity>>(CacheKey);
        }

        public TweetEntity GetLastTweet()
        {
            return GetAll().OrderByDescending(x => x.CreatedOn).DefaultIfEmpty(new TweetEntity()).First();
        }

        public void SaveTweet(TweetEntity tweet)
        {
            var tweets = GetAll().ToList();
            tweets.Add(tweet);
            MemoryCache.Set(CacheKey, tweets);
        }
    }
}
