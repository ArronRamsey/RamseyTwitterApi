using Core.Dtos;
using Core.Services.Interfaces;
using FrameworkAbstractions.Interfaces;

namespace Core.Services.Implementations
{
    public class TweetStatisticsService : ITweetStatisticsService
    {
        public int TweetCount
        {
            get
            {
                return _TweetCount;
            }
        }

        private int _TweetCount { get; set; }  

        public double TweetsPerMinute
        {
            get
            {
                if (StartDate == null)
                {
                    return 0;
                }
                return TweetCount / DateTimeService.Now().Subtract(Convert.ToDateTime(StartDate)).TotalMinutes;
            }
        }

        public TweetStatisticsDto Statistics
        {
            get
            {
                return new TweetStatisticsDto() { TweetsPerMinute = TweetsPerMinute, TweetsReceived = _TweetCount };
            }
        }

        private DateTime? StartDate { get; set; }

        private IDateTimeService DateTimeService { get; }

        public TweetStatisticsService(IDateTimeService dateTimeService)
        {
            DateTimeService = dateTimeService;
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
