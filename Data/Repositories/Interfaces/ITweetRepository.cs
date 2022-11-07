using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ITweetRepository
    {
        IEnumerable<TweetEntity> GetAll();
        void SaveTweet(TweetEntity tweet);
        TweetEntity GetLastTweet();
    }
}
