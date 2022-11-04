using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;

namespace RamseyTwitterApi.Workers
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

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            ApiService.TweetReceived += () =>
            {
                TweetService.TweetReceived();
            };
            await Task.Run(() => ApiService.Connect());
            Log.LogInformation("TwitterStreamService_StartAsync");
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            ApiService.Disconnect();
            Log.LogInformation("TwitterStreamService_StartAsync");
            Log.LogInformation($"Tweet Count: {TweetService.TweetCount}");
            Log.LogInformation($"Tweets Per Minute: {TweetService.GetTweetsPerMinute()}");
            return Task.CompletedTask;
        }
    }
}
