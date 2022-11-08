using Core.Services.Implementations;
using NSubstitute;
using UnitTests;
using Core.Dtos;
using Data.Repositories.Interfaces;
using Entities;
using FrameworkAbstractions.Interfaces;

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
            var repo = Substitute.For<ITweetRepository>();
            var guid = Substitute.For<IGuid>();
            repo.GetAll().Returns(new List<TweetEntity>() { new TweetEntity() { Text="123"} });
            var service = new TweetService(dateTime, logger, threadService, repo, guid);
            Assert.AreEqual(1, service.TweetCount);
        }

        [TestMethod]
        public void GetTweetsPerMinute_NullStart_Returns0()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            var logger = Substitute.For<MockLogger<TweetService>>();
            var threadService = Substitute.For<IThreadingService>();
            var repo = Substitute.For<ITweetRepository>();
            var guid = Substitute.For<IGuid>();
            var service = new TweetService(dateTime, logger, threadService, repo, guid);
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
            var repo = Substitute.For<ITweetRepository>();
            repo.GetAll().Returns(new List<TweetEntity>() { new TweetEntity() { Text = "123" }, new TweetEntity() { Text = "123" }, new TweetEntity() { Text = "123" } });
            var guid = Substitute.For<IGuid>();
            var service = new TweetService(dateTime, logger, threadService, repo, guid);
            service.TweetReceived(new TweetDto() { AuthorId = "Id",Text = "Text", CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00) });
            service.TweetReceived(new TweetDto() { AuthorId = "Id", Text = "Text", CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00) });
            service.TweetReceived(new TweetDto() { AuthorId = "Id", Text = "Text", CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00) });
            dateTime.Now().Returns(new DateTime(2022, 11, 03, 01, 02, 00));
            var tpm = service.GetTweetsPerMinute();
            Assert.AreEqual(1.5, tpm);
        }

        [TestMethod]
        public void GetStatistics()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            dateTime.Now().Returns(new DateTime(2022, 11, 03, 01, 00, 00));
            var logger = Substitute.For<MockLogger<TweetService>>();
            var threadService = Substitute.For<IThreadingService>();
            var repo = Substitute.For<ITweetRepository>();
            repo.GetAll().Returns(new List<TweetEntity>() { new TweetEntity() { Text = "123" }, new TweetEntity() { Text = "123" }, new TweetEntity() { Text = "123" } });
            var guid = Substitute.For<IGuid>();
            var service = new TweetService(dateTime, logger, threadService, repo, guid);
            service.TweetReceived(new TweetDto() { AuthorId = "Id", Text = "Text", CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00) });
            service.TweetReceived(new TweetDto() { AuthorId = "Id", Text = "Text", CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00) });
            service.TweetReceived(new TweetDto() { AuthorId = "Id", Text = "Text", CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00) });
            dateTime.Now().Returns(new DateTime(2022, 11, 03, 01, 02, 00));
            var stats = service.Statistics;
            Assert.AreEqual(1.5, stats.TweetsPerMinute);
        }

        //Commenting async logging out.
        //[TestMethod]
        //public void AsyncLogging()
        //{
        //    var builder = new StringBuilder();
        //    builder.AppendLine("Tweet Count: 0");
        //    builder.AppendLine("Tweets Per Minute: 0");
        //    builder.AppendLine("Last Text: Text");
        //    builder.AppendLine("Last Author: Author");

        //    var dateTime = Substitute.For<IDateTimeService>();
        //    var logger = Substitute.For<MockLogger<TweetService>>();
        //    var threadService = Substitute.For<IThreadingService>();
        //    var repo = Substitute.For<ITweetRepository>();
        //    repo.GetLastTweet().Returns(new TweetEntity() { Author = "Author", Text = "Text" });
        //    var service = new TweetService(dateTime, logger, threadService, repo);

        //    service.StartWriteLogAsync();
        //    logger.Received().Log(LogLevel.Warning, builder.ToString());
        //    logger.ClearReceivedCalls();
        //    service.StopWriteLogAsync();
        //    logger.Received().Log(LogLevel.Warning, "TweetService_LogWritingTaskCancelled");
        //    logger.ClearReceivedCalls();
        //}

    }
}