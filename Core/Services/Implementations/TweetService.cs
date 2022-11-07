using Core.Dtos;
using Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Data.Repositories.Interfaces;
using Data.Entities;
using System.Text;

namespace Core.Services.Implementations
{
    public class TweetService : ITweetService
    {
        public TweetStatisticsDto Statistics
        {
            get
            {
                return new TweetStatisticsDto() { TweetsPerMinute = TweetsPerMinute, TweetsReceived = TweetCount };
            }
        }

        public int TweetCount
        {
            get
            {
                return GetTweets().Count();
            }
        }

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
        private ITweetRepository TweetRepo { get; }

        private CancellationTokenSource LoggingTaskCancelSource { get; set; }
        private CancellationToken LoggingToken { get; set; }

        public TweetService(IDateTimeService dateTimeService, ILogger<TweetService> logger, IThreadingService threadingService, ITweetRepository tweetRepository)
        {
            DateTimeService = dateTimeService;
            Log = logger;
            ThreadService = threadingService;
            LoggingTaskCancelSource = new CancellationTokenSource();
            LoggingToken = LoggingTaskCancelSource.Token;
            TweetRepo = tweetRepository;
        }

        public double GetTweetsPerMinute()
        {
            if (StartDate == null)
            {
                return 0;
            }
            return GetTweets().Count() / DateTimeService.Now().Subtract(Convert.ToDateTime(StartDate)).TotalMinutes;
        }

        public void TweetReceived(TweetDto dto)
        {
            if (StartDate == null)
            {
                StartDate = DateTimeService.Now();
            }
            SaveTweet(dto);
        }

        public void StartWriteLogAsync()
        {
            if (LoggingToken.IsCancellationRequested)
            {
                //We cancelled the task.  Need to re-initialize
                LoggingTaskCancelSource = new CancellationTokenSource();
                LoggingToken = LoggingTaskCancelSource.Token;
            }
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
                var lastTweet = TweetRepo.GetLastTweet();
                var sb = new StringBuilder();
                sb.AppendLine($"Tweet Count: {TweetCount}");
                sb.AppendLine($"Tweets Per Minute: {TweetsPerMinute}");
                sb.AppendLine($"Last Text: {lastTweet.Text}");
                sb.AppendLine($"Last Author: {lastTweet.Author}");
                Log.LogWarning(sb.ToString());
                ThreadService.Sleep(2000);
            }
        }
        
        private IEnumerable<TweetEntity> GetTweets()
        {
            return TweetRepo.GetAll();
        }

        private void SaveTweet(TweetDto dto)
        {
            var tweet = new TweetEntity()
            {
                Author= dto.AuthorId,
                CreatedOn = dto.CreatedOn,
                Id = 4,
                Text=dto.Text
            };
            TweetRepo.SaveTweet(tweet);
        }

    }
}
