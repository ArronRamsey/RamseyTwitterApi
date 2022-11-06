using Core.Services.Implementations;
using Core.Services.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;
using UnitTests;

namespace Tests.Core.Services
{
    [TestClass]
    public class TweetServiceTests
    {
        
        [TestMethod]
        public void TweetReceived()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            var logger = Substitute.For<MockLogger<TweetService>>();
            var threadService = Substitute.For<IThreadingService>();
            var service = new TweetService(dateTime, logger, threadService);
            service.TweetReceived();
            Assert.AreEqual(1, service.TweetCount);
        }

        [TestMethod]
        public void GetTweetsPerMinute_NullStart_Returns0()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            var logger = Substitute.For<MockLogger<TweetService>>();
            var threadService = Substitute.For<IThreadingService>();
            var service = new TweetService(dateTime, logger, threadService);
            var tpm = service.GetTweetsPerMinute();
            Assert.AreEqual(0, tpm);
        }

        [TestMethod]
        public void GetTweetsPerMinute_HasTweets_Returns1()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            dateTime.Now().Returns(new DateTime(2022, 11, 03, 01, 00, 00));
            var logger = Substitute.For<MockLogger<TweetService>>();
            var threadService = Substitute.For<IThreadingService>();
            var service = new TweetService(dateTime, logger, threadService);
            service.TweetReceived();
            service.TweetReceived();
            service.TweetReceived();
            dateTime.Now().Returns(new DateTime(2022, 11, 03, 01, 02, 00));
            var tpm = service.GetTweetsPerMinute();
            Assert.AreEqual(1.5, tpm);
        }

        [TestMethod]
        public void AsyncLogging()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            var logger = Substitute.For<MockLogger<TweetService>>();
            var threadService = Substitute.For<IThreadingService>();
            var service = new TweetService(dateTime, logger, threadService);
            
            service = new TweetService(dateTime, logger, threadService);
            service.StartWriteLogAsync();
            logger.Received().Log(LogLevel.Warning, Arg.Is<string>(x => x.StartsWith("Tweet Count:")));
            logger.ClearReceivedCalls();

            service = new TweetService(dateTime, logger, threadService);
            service.StartWriteLogAsync();
            logger.Received().Log(LogLevel.Warning, Arg.Is<string>(x => x.StartsWith("Tweets Per Minute:")));
            logger.ClearReceivedCalls();

            service = new TweetService(dateTime, logger, threadService);
            service.StartWriteLogAsync();
            service.StopWriteLogAsync();
            logger.Received().Log(LogLevel.Warning, "TweetService_LogWritingTaskCancelled");
            logger.ClearReceivedCalls();
        }

    }
}