using Infrastructure.Services.Interfaces;
using NSubstitute;
using RamseyTwitterApi.Controllers;

namespace UnitTests.API.Controllers
{
    [TestClass]
    public class TwitterStreamControllerTests
    {
        [TestMethod]
        public void Connect()
        {
            var service = Substitute.For<ITwitterApiService>();
            var controller = new TwitterStreamController(service);
            controller.Connect();
            service.Received().Connect();
        }

        [TestMethod]
        public void Disconnect()
        {
            var service = Substitute.For<ITwitterApiService>();
            var controller = new TwitterStreamController(service);
            controller.Disconnect();
            service.Received().Disconnect();
        }

    }
}
