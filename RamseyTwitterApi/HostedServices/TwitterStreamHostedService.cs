using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;

namespace RamseyTwitterApi.HostedServices
{
    public class TwitterStreamHostedService : IHostedService
    {
        private ITwitterApiService ApiService { get; }
        private ITweetService TweetService { get; }
        private ILogger<TwitterStreamHostedService> Log { get; }

        public TwitterStreamHostedService(ITwitterApiService twitterApiService, ITweetService tweetService, ILogger<TwitterStreamHostedService> log)
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
            ApiService.Disconnect();
            Log.LogWarning($"Final Tweet Count: {TweetService.TweetCount}");
            Log.LogWarning($"Final Tweets Per Minute: {TweetService.TweetsPerMinute}");
            return Task.CompletedTask;
        }
    }
}
