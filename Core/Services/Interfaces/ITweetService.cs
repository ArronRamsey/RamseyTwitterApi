namespace Core.Services.Interfaces
{
    public interface ITweetService
    {
        int TweetCount { get; }
        double TweetsPerMinute { get; }
        void TweetReceived();
        void StartWriteLogAsync();
        void StopWriteLogAsync();
    }
}
