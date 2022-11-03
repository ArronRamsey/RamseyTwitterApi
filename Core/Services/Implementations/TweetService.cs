using Core.Services.Interfaces;

namespace Core.Services.Implementations
{
    public class TweetService : ITweetService
    {
        public int TweetCount
        {
            get
            {
                return _TweetCount;
            }
        }
        private IDateTimeService DateTimeService { get; }
        private int _TweetCount { get; set; }
        private DateTime? StartDate { get; set; }

        public TweetService(IDateTimeService dateTimeService)
        {
            DateTimeService = dateTimeService;
        }

        public double GetTweetsPerMinute()
        {
            if (StartDate == null)
            {
                return 0;
            }
            return _TweetCount / DateTimeService.Now().Subtract(Convert.ToDateTime(StartDate)).TotalMinutes;
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
