using Core.Dtos;
using Core.Services.Implementations;
using FrameworkAbstractions.Interfaces;
using NSubstitute;

namespace UnitTests.Core.Services
{
    [TestClass]
    public class TweetStatisticsServiceTests
    {
        [TestMethod]
        public void TweetsPerMinute_NoDate_ReturnsZero()
        {
            var dateService = Substitute.For<IDateTimeService>();
            var service = new TweetStatisticsService(dateService);
            Assert.AreEqual(0, service.TweetsPerMinute);
        }

        [TestMethod]
        public void TweetReceived()
        {
            var dateService = Substitute.For<IDateTimeService>();
            var service = new TweetStatisticsService(dateService);
            service.TweetReceived();
            Assert.AreEqual(1, service.TweetCount);
        }

        [TestMethod]
        public void TweetsPerMinute()
        {
            var dateService = Substitute.For<IDateTimeService>();
            dateService.Now().Returns(new DateTime(2022, 11, 08, 10, 00, 00), new DateTime(2022, 11, 08, 10, 02, 00));
            var service = new TweetStatisticsService(dateService);
            service.TweetReceived();
            service.TweetReceived();
            service.TweetReceived();
            Assert.AreEqual(1.5, service.TweetsPerMinute);
        }

        [TestMethod]
        public void Statistics()
        {
            var dateService = Substitute.For<IDateTimeService>();
            dateService.Now().Returns(new DateTime(2022, 11, 08, 10, 00, 00), new DateTime(2022, 11, 08, 10, 02, 00));
            var service = new TweetStatisticsService(dateService);
            service.TweetReceived();
            service.TweetReceived();
            service.TweetReceived();
            var expectedStats = new TweetStatisticsDto() { TweetsPerMinute = 1.5, TweetsReceived = 3 };
            Assert.AreEqual(expectedStats, service.Statistics);
        }

    }
}
