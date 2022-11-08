using Core.Services.Interfaces;
using NSubstitute;
using RamseyTwitterApi.Controllers;

namespace UnitTests.API.Controllers
{
    [TestClass]
    public class LoggingControllerTests
    {
        [TestMethod]
        public void StartLogging()
        {
            var service = Substitute.For<ILoggingService>();
            var propertyChanged = false;
            service.When(x => x.LoggingEnabled = true).Do(x => propertyChanged = true);
            var controller = new LoggingController(service);
            controller.StartLogging();
            Assert.IsTrue(propertyChanged);
        }

        [TestMethod]
        public void StopLogging()
        {
            var service = Substitute.For<ILoggingService>();
            var loggingEnabled = false;
            service.When(x => x.LoggingEnabled = true).Do(x => loggingEnabled = true);
            service.When(x => x.LoggingEnabled = false).Do(x => loggingEnabled = false);
            var controller = new LoggingController(service);
            controller.StartLogging();
            controller.StopLogging();
            Assert.IsFalse(loggingEnabled);
        }

    }
}
