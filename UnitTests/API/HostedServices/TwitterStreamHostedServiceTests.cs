using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.Extensions.Logging;
using NSubstitute;
using RamseyTwitterApi.HostedServices;
using static Infrastructure.Services.Interfaces.ITwitterApiService;

namespace UnitTests.API.HostedServices
{
    [TestClass]
    public class TwitterStreamHostedServiceTests
    {
        [TestMethod]
        public void StartAsync_TweetService_TweetReceivedCalledViaEvent()
        {
            //var apiService = Substitute.For<ITwitterApiService>();
            //var tweetService = Substitute.For<ITweetService>();
            //var logger = Substitute.For<ILogger<TwitterStreamHostedService>>();
            //var service = new TwitterStreamHostedService(apiService, tweetService, logger);
            //apiService.When(x => x.Connect()).Do(y => apiService.TweetReceived += Raise.Event<ReceivedTweet>());
            ////var wasCalled = false;
            ////apiService.TweetReceived += () => wasCalled = true;
            ////apiService.TweetReceived += Raise.Event<ReceivedTweet>();
            //service.StartAsync(new CancellationToken());
            //tweetService.Received().TweetReceived();
            ////Assert.IsTrue(wasCalled);
        }

        [TestMethod]
        public void StartAsync_ConnectCalled()
        {
            var apiService = Substitute.For<ITwitterApiService>();
            var tweetService = Substitute.For<ITweetService>();
            var logger = Substitute.For<ILogger<TwitterStreamHostedService>>();
            var service = new TwitterStreamHostedService(apiService, tweetService, logger);
            service.StartAsync(new CancellationToken());
            apiService.Received().Connect();
        }

        [TestMethod]
        public void StartAsync_TaskCompleted()
        {
            var apiService = Substitute.For<ITwitterApiService>();
            var tweetService = Substitute.For<ITweetService>();
            var logger = Substitute.For<ILogger<TwitterStreamHostedService>>();
            var service = new TwitterStreamHostedService(apiService, tweetService, logger);
            var returnedTask = service.StartAsync(new CancellationToken());
            Assert.IsTrue(returnedTask.IsCompleted);
        }

        [TestMethod]
        public void StartAsync_LogCalled1xOnConnect()
        {
            var apiService = Substitute.For<ITwitterApiService>();
            var tweetService = Substitute.For<ITweetService>();
            var logger = Substitute.For<ILogger<TwitterStreamHostedService>>();
            var service = new TwitterStreamHostedService(apiService, tweetService, logger);
            service.StartAsync(new CancellationToken());
            Assert.AreEqual(1, logger.ReceivedCalls().Count());
        }

        [TestMethod]
        public void StopAsync_DisconnectCalled()
        {
            var apiService = Substitute.For<ITwitterApiService>();
            var tweetService = Substitute.For<ITweetService>();
            var logger = Substitute.For<ILogger<TwitterStreamHostedService>>();
            var service = new TwitterStreamHostedService(apiService, tweetService, logger);
            service.StopAsync(new CancellationToken());
            apiService.Received().Disconnect();
        }

        [TestMethod]
        public void StopAsync_LogCalled3x()
        {
            var apiService = Substitute.For<ITwitterApiService>();
            var tweetService = Substitute.For<ITweetService>();
            var logger = Substitute.For<ILogger<TwitterStreamHostedService>>();
            var service = new TwitterStreamHostedService(apiService, tweetService, logger);
            service.StopAsync(new CancellationToken());
            Assert.AreEqual(3, logger.ReceivedCalls().Count());
        }

        [TestMethod]
        public void StopAsync_TaskCompleted()
        {
            var apiService = Substitute.For<ITwitterApiService>();
            var tweetService = Substitute.For<ITweetService>();
            var logger = Substitute.For<ILogger<TwitterStreamHostedService>>();
            var service = new TwitterStreamHostedService(apiService, tweetService, logger);
            var returnedTask = service.StopAsync(new CancellationToken());
            Assert.IsTrue(returnedTask.IsCompleted);
        }

    }
}
