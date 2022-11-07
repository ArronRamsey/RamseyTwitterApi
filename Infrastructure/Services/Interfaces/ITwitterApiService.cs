using Core.Dtos;

namespace Infrastructure.Services.Interfaces
{
    public interface ITwitterApiService
    {
        delegate void ReceivedTweet(TweetDto dto);
        event ReceivedTweet? TweetReceived;
        void Connect();
        void Disconnect();
    }

}
