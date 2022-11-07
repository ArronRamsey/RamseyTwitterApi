using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class TweetRepository : ITweetRepository
    {
        private List<TweetEntity> TweetEntities { get; set; } = new List<TweetEntity>();

        public IEnumerable<TweetEntity> GetAll()
        {
            return TweetEntities.AsEnumerable();
        }

        public void SaveTweet(TweetEntity tweet)
        {
            TweetEntities.Add(tweet);
        }
    }
}
