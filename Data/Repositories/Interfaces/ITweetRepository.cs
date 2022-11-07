using Data.Entities;

namespace Data.Repositories.Interfaces
{
    public interface ITweetRepository
    {
        IEnumerable<Tweets> GetAll();
        void SaveTweet(Tweets tweet);
    }
}
