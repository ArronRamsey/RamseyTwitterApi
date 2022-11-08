using Core.Dtos;
using Entities;

namespace Core.Services.Interfaces
{
    public interface ITweetService
    {
        void TweetReceived(TweetDto dto);
        TweetEntity GetLastTweet();
    }

}
