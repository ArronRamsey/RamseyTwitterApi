namespace Infrastructure.Services.Interfaces
{
    public interface ITwitterApiService
    {
        delegate void ReceivedTweet();
        event ReceivedTweet? TweetReceived;
        void Connect();
        void Disconnect();
    }
}
