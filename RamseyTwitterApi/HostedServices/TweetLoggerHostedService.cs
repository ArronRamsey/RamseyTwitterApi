using Core.Services.Interfaces;

namespace RamseyTwitterApi.HostedServices
{
    public class TweetLoggerHostedService : IHostedService
    {
        private ITweetService TweetService { get; }

        public TweetLoggerHostedService(ITweetService tweetService)
        {
            TweetService = tweetService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            TweetService.StartWriteLogAsync();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            TweetService.StopWriteLogAsync();
            return Task.CompletedTask;
        }
       
    }
}
