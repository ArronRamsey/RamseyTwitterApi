namespace Core.Services.Interfaces
{
    public interface ITweetService
    {
        double GetTweetsPerMinute();
        void TweetReceived();
    }
}
