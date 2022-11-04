namespace Core.Services.Interfaces
{
    public interface ITweetService
    {
        int TweetCount { get; }
        double GetTweetsPerMinute();
        void TweetReceived();
    }
}
