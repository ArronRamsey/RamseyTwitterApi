using Core.Dtos;
using Core.Services.Interfaces;
using FrameworkAbstractions.Interfaces;

namespace Core.Services.Implementations
{
    public class TweetStatisticsService : ITweetStatisticsService
    {
        private int _TweetCount { get; set; }
        private DateTime? StartDate { get; set; }
        private IDateTimeService DateTimeService { get; }
        
        public TweetStatisticsService(IDateTimeService dateTimeService)
        {
            DateTimeService = dateTimeService;
        }

        public int GetTweetCount()
        {
            return _TweetCount;
        }

        public double GetTweetsPerMinute()
        {
            if (StartDate == null)
            {
                return 0;
            }
            return _TweetCount / DateTimeService.Now().Subtract(Convert.ToDateTime(StartDate)).TotalMinutes;
        }

        public TweetStatisticsDto GetStatistics()
        {
            return new TweetStatisticsDto() { TweetsPerMinute = GetTweetsPerMinute(), TweetsReceived = _TweetCount };
        }

        public void TweetReceived()
        {
            if (StartDate == null)
            {
                StartDate = DateTimeService.Now();
            }
            _TweetCount += 1;
        }

    }
}
