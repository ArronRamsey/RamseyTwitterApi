using Core.Services.Interfaces;
using Microsoft.Extensions.Logging;

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
        private int _TweetCount { get; set; }

        public double TweetsPerMinute
        {
            get
            {
                return GetTweetsPerMinute();
            }
        }
        private DateTime? StartDate { get; set; }

        private IDateTimeService DateTimeService { get; }
        private ILogger<TweetService> Log { get; }
        private IThreadingService ThreadService { get; }

        private CancellationTokenSource LoggingTaskCancelSource { get; }
        private CancellationToken LoggingToken { get; }

        public TweetService(IDateTimeService dateTimeService, ILogger<TweetService> logger, IThreadingService threadingService)
        {
            DateTimeService = dateTimeService;
            Log = logger;
            ThreadService = threadingService;
            LoggingTaskCancelSource = new CancellationTokenSource();
            LoggingToken = LoggingTaskCancelSource.Token;
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

        public void StartWriteLogAsync()
        {
            Task.Run(() => LogInfo(), LoggingToken);
        }

        public void StopWriteLogAsync()
        {
            LoggingTaskCancelSource.Cancel();
            Log.LogWarning("TweetService_LogWritingTaskCancelled");
        }

        private void LogInfo()
        {
            while (!LoggingToken.IsCancellationRequested)
            {
                Log.LogWarning($"Tweet Count: {TweetCount}");
                Log.LogWarning($"Tweets Per Minute: {TweetsPerMinute}");
                ThreadService.Sleep(2000);
            }
        }

    }
}
