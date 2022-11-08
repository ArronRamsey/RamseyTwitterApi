using FrameworkAbstractions.Interfaces;
using Data.Repositories.Interfaces;
using Entities;

namespace Data.Repositories.Implementations
{
    public class MemoryCacheTweetRepository : ITweetRepository
    {
        private ICacheService MemoryCache { get; }

        private string CacheKey = "ABCD1234_AllTweets";

        private List<TweetEntity> Tweets 
        {
            get
            {
                if (MemoryCache.Get<List<TweetEntity>>(CacheKey) == null)
                {
                    MemoryCache.Set(CacheKey, new List<TweetEntity>());
                }
                return MemoryCache.Get<List<TweetEntity>>(CacheKey);
            }
          
            set => MemoryCache.Set(CacheKey, value);
        } 

        public MemoryCacheTweetRepository(ICacheService cache)
        {
            MemoryCache = cache;
        }

        public IEnumerable<TweetEntity> GetAll() => Tweets.AsEnumerable();

        public TweetEntity GetLastTweet() => Tweets.OrderByDescending(x => x.CreatedOn).DefaultIfEmpty(new TweetEntity()).First();

        public void SaveTweet(TweetEntity tweet)
        {
            var tweets = Tweets;
            tweets.Add(tweet);
            Tweets = tweets;
        }

    }
}
