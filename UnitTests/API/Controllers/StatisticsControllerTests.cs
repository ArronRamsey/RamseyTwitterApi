using Core.Dtos;
using Core.Services.Interfaces;
using NSubstitute;
using RamseyTwitterApi.Controllers;

namespace UnitTests.API.Controllers
{
    [TestClass]
    public class StatisticsControllerTests
    {
        [TestMethod]
        public void GetTweetsPerMinute()
        {
            var service = Substitute.For<ITweetStatisticsService>();
            var controller = new StatisticsController(service);
            controller.TweetsPerMinute();
            service.Received().GetTweetsPerMinute();
        }

    }
}
