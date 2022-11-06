using Core.Services.Interfaces;
using NSubstitute;
using RamseyTwitterApi.HostedServices;

namespace UnitTests.API.HostedServices
{
    [TestClass]
    public class TweetLoggerHostedServiceTests
    {
        [TestMethod]
        public void StartAsync()
        {
            var tweetService = Substitute.For<ITweetService>();
            var hostedService = new TweetLoggerHostedService(tweetService);
            hostedService.StartAsync(new CancellationToken(false));
            tweetService.Received().StartWriteLogAsync();
        }

        [TestMethod]
        public void StopAsync()
        {
            var tweetService = Substitute.For<ITweetService>();
            var hostedService = new TweetLoggerHostedService(tweetService);
            hostedService.StartAsync(new CancellationToken(false));
            tweetService.Received().StopWriteLogAsync();
        }

    }
}
