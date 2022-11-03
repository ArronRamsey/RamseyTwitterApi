using Core.Services.Implementations;
using Core.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Tests.Services
{
    [TestClass]
    public class TweetServiceTests
    {
        [TestMethod]
        public void TweetReceived()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            var service = new TweetService(dateTime);
            service.TweetReceived();
            Assert.AreEqual(1, service.TweetCount);
        }

        [TestMethod]
        public void GetTweetsPerMinute_NullStart_Returns0()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            var service = new TweetService(dateTime);
            var tpm = service.GetTweetsPerMinute();
            Assert.AreEqual(0, tpm);
        }

        [TestMethod]
        public void GetTweetsPerMinute_HasTweets_Returns1()
        {
            var dateTime = Substitute.For<IDateTimeService>();
            dateTime.Now().Returns(new DateTime(2022, 11, 03, 01, 00, 00));
            var service = new TweetService(dateTime);
            service.TweetReceived();
            dateTime.Now().Returns(new DateTime(2022, 11, 03, 01, 01, 00));
            var tpm = service.GetTweetsPerMinute();
            Assert.AreEqual(1, tpm);
        }
    }
}