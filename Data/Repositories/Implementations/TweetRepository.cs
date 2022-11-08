using Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class TweetRepository : ITweetRepository
    {
        private List<TweetEntity> TweetEntities { get; set; } = new List<TweetEntity>();

        public IEnumerable<TweetEntity> GetAll() => TweetEntities.AsEnumerable();

        public TweetEntity GetLastTweet() => TweetEntities.OrderByDescending(x => x.CreatedOn).DefaultIfEmpty(new TweetEntity()).First();

        public void SaveTweet(TweetEntity tweet) => TweetEntities.Add(tweet);

    }
}
