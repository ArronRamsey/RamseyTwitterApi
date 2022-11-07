using Data.Entities;
using Data.Repositories.Interfaces;

namespace Data.Repositories.Implementations
{
    public class TweetRepository : ITweetRepository
    {
        private List<Tweets> Tweets { get; set; } = new List<Tweets>();

        public IEnumerable<Tweets> GetAll()
        {
            return Tweets.AsEnumerable();
        }

        public void SaveTweet(Tweets tweet)
        {
            Tweets.Add(tweet);
        }
    }
}
