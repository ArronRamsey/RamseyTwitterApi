using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using System.Runtime.CompilerServices;

namespace RamseyTwitterApi.HostedServices
{
    public class TwitterStreamService : IHostedService
    {
        private ITwitterApiService ApiService { get; }
        private ITweetService TweetService { get; }
        private ILogger<TwitterStreamService> Log;

        public TwitterStreamService(ITwitterApiService twitterApiService, ITweetService tweetService, ILogger<TwitterStreamService> log)
        {
            ApiService = twitterApiService;
            TweetService = tweetService;
            Log = log;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {

            ApiService.TweetReceived += () =>
            {
                TweetService.TweetReceived();
            };
            Task.Run(() => ApiService.Connect());
            Log.LogWarning("TwitterStreamService_StartAsync");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //ApiService.Disconnect();
            Log.LogWarning("TwitterStreamService_StopAsync");
            Log.LogWarning($"Tweet Count: {TweetService.TweetCount}");
            Log.LogWarning($"Tweets Per Minute: {TweetService.GetTweetsPerMinute()}");
            return Task.CompletedTask;
        }
    }
}
