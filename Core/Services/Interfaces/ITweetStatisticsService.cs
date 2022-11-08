using Core.Dtos;

namespace Core.Services.Interfaces
{
    public interface ITweetStatisticsService
    {
        int GetTweetCount();
        double GetTweetsPerMinute();
        TweetStatisticsDto GetStatistics();
        void TweetReceived();

    }
}
