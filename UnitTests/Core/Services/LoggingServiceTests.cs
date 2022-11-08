using Core.Services.Implementations;
using Core.Services.Interfaces;
using Entities;
using FrameworkAbstractions.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;
using System.Text;

namespace UnitTests.Core.Services
{
    [TestClass]
    public class LoggingServiceTests
    {
        [TestMethod]
        public void StartWriteLog()
        {
            var logger = Substitute.For<MockLogger<LoggingService>>();
            var thread = Substitute.For<IThreadingService>();
            var stats = Substitute.For<ITweetStatisticsService>();
            stats.GetTweetCount().Returns(5);
            stats.GetTweetsPerMinute().Returns(5.75);
            var tags = Substitute.For<IHashtagRankingService>();
            tags.GetStatistics().Returns("HashTagStats");
            var tweets = Substitute.For<ITweetService>();
            tweets.GetLastTweet().Returns(GetTestTweetEntity());
            var service = new LoggingService(logger, thread, stats, tags, tweets);
            service.StartWriteLog();
            logger.Received().Log(LogLevel.Warning, GetLogMessage());
        }

        private TweetEntity GetTestTweetEntity()
        {
            return new TweetEntity()
            {
                Author = "Author",
                Text = "Text",
                Tags = new List<HashTagEntity>()
                {
                    new HashTagEntity() {Text = "Tag1" },
                    new HashTagEntity() {Text = "Tag2" }
                }
            };
        }

        private string GetLogMessage()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Tweet Count: 5");
            builder.AppendLine("Tweets Per Minute: 5.75");
            builder.AppendLine("Last Text: Text");
            builder.AppendLine("Last Author: Author");
            builder.AppendLine("HashTags: Tag1,Tag2");
            builder.AppendLine("");
            builder.AppendLine("HashTagStats");
            return builder.ToString();
        }

    }
}
