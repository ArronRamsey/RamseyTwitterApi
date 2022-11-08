using Core.Services.Interfaces;
using NSubstitute;
using RamseyTwitterApi.Controllers;

namespace UnitTests.API.Controllers
{
    [TestClass]
    public class HashtagRankingControllerTests
    {
        [TestMethod]
        public void GetRanking()
        {
            var service = Substitute.For<IHashtagRankingService>();
            var controller = new HashtagRankingController(service);
            controller.GetRanking();
            service.Received().GetStatistics();
        }
    }
}
