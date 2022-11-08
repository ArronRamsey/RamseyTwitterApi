using Core.Services.Interfaces;
using FrameworkAbstractions.Interfaces;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Core.Services.Implementations
{
    public class LoggingService : ILoggingService
    {
        private ILogger<LoggingService> Logger { get; }
        private IThreadingService ThreadService { get; }
        private ITweetStatisticsService StatService { get; }
        private IHashtagRankingService TagService { get; }
        private ITweetService TweetService { get; }
        public bool LoggingEnabled { get; set; }

        public LoggingService(ILogger<LoggingService> logger, IThreadingService threadingService, ITweetStatisticsService statisticsService, 
                              IHashtagRankingService hashtagRankingService, ITweetService tweetService)
        {
            Logger = logger;
            ThreadService = threadingService;
            StatService = statisticsService;
            TagService = hashtagRankingService;
            TweetService = tweetService;
        }

        public void WriteLog()
        {
            if (LoggingEnabled)
            {
                var lastTweet = TweetService.GetLastTweet();
                var sb = new StringBuilder();
                sb.AppendLine($"Tweet Count: {StatService.GetTweetCount()}");
                sb.AppendLine($"Tweets Per Minute: {StatService.GetTweetsPerMinute()}");
                sb.AppendLine($"Last Text: {lastTweet.Text}");
                sb.AppendLine($"Last Author: {lastTweet.Author}");
                sb.AppendLine($"HashTags: {string.Join(",", lastTweet.Tags.Select(x => x.Text).ToList())}");
                sb.AppendLine();
                sb.AppendLine(TagService.GetStatistics());
                Logger.LogWarning(sb.ToString());
                ThreadService.Sleep(2000);
            }
        }

        public void RunLogAsync(CancellationToken LoggingToken)
        {
            Logger.LogWarning("LoggingService_LogAsync_Start");
            while (!LoggingToken.IsCancellationRequested)
            {
                WriteLog();
            }
            Logger.LogWarning("LoggingService_LogAsync_End");
        }

    }
}
