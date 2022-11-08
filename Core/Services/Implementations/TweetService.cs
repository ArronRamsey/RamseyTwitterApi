using Core.Dtos;
using Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Data.Repositories.Interfaces;
using Entities;
using System.Text;
using FrameworkAbstractions.Interfaces;

namespace Core.Services.Implementations
{
    public class TweetService : ITweetService
    {
        public Dictionary<string, int> TagStats { get; set; } = new Dictionary<string, int>();
        
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
        private IGuidService GuidService { get; }

        private CancellationTokenSource LoggingTaskCancelSource { get; set; }
        private CancellationToken LoggingToken { get; set; }

        public TweetService(IDateTimeService dateTimeService, ILogger<TweetService> logger, IThreadingService threadingService, 
                            ITweetRepository tweetRepository, IGuidService guidService)
        {
            DateTimeService = dateTimeService;
            Log = logger;
            ThreadService = threadingService;
            LoggingTaskCancelSource = new CancellationTokenSource();
            LoggingToken = LoggingTaskCancelSource.Token;
            TweetRepo = tweetRepository;
            GuidService = guidService;
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
            UpdateTagStats(dto);
        }

        private void UpdateTagStats(TweetDto dto)
        {
            foreach(var tag in dto.HashTags)
            {
                if(TagStats.ContainsKey(tag))
                {
                    TagStats[tag] += 1;
                }
                else
                {
                    TagStats.Add(tag, 1);
                }
            }
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
                sb.AppendLine($"HashTags: {string.Join(",", lastTweet.Tags.Select(x => x.Text).ToList())}");
                sb.AppendLine();
                sb.AppendLine(GetStats());
                Log.LogWarning(sb.ToString());
                ThreadService.Sleep(2000);
            }
        }

        public string GetStats()
        {
            var sb = new StringBuilder();
            sb.AppendLine("HashTag Top 10:");
            var i = 1;
            foreach (var stat in TagStats.OrderByDescending(x => x.Value).Take(10).ToList())
            {
                sb.AppendLine($"Place: {i}.  Used: {stat.Value}.  Tag: {stat.Key}");
                i ++;
            }
            return sb.ToString();
        }
        
        private IEnumerable<TweetEntity> GetTweets()
        {
            return TweetRepo.GetAll();
        }

        private void SaveTweet(TweetDto dto)
        {
            var tweetId = GuidService.GetGuid().ToString();
            var tweet = new TweetEntity()
            {
                Author= dto.AuthorId,
                CreatedOn = dto.CreatedOn,
                Id = tweetId,
                Text=dto.Text
            };
            dto.HashTags.ToList().ForEach(x => tweet.Tags.Add(new HashTagEntity()
            {
                Id = GuidService.GetGuid().ToString(),
                TweetId = tweetId,
                Text = x
            }));
            TweetRepo.SaveTweet(tweet);
        }

    }
}
