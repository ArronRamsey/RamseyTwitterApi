using Core.Dtos;
using Core.Services.Interfaces;
using NSubstitute;
using RamseyTwitterApi.Controllers;

namespace UnitTests.API.Controllers
{
    [TestClass]
    public class TweetsControllerTests
    {
        [TestMethod]
        public void GetInfo()
        {
            var service = Substitute.For<ITweetService>();
            service.Statistics.Returns(new TweetStatisticsDto { TweetsPerMinute = 1, TweetsReceived = 2 });
            var expectedDto = new TweetStatisticsDto { TweetsPerMinute = 1, TweetsReceived = 2 };
            var controller = new TweetsController(service);
            var stats = controller.GetInfo();
            Assert.AreEqual(expectedDto, stats);
        }

    }
}
