using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;public delegate void Notify();

namespace RamseyTwitterApi.Workers
{
    public class TwitterStreamService : IHostedService
    {
        private ITwitterApiService ApiService { get; }
        private ITweetService TweetService { get; }

        public TwitterStreamService(ITwitterApiService twitterApiService, ITweetService tweetService )
        {
            ApiService = twitterApiService;
            TweetService = tweetService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ApiService.TweetReceived += (null, null) =>
            {
                TweetService.TweetReceived();
            };
            throw new NotImplementedException();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            ApiService.Disconnect();
            return Task.CompletedTask;
        }
    }
}
