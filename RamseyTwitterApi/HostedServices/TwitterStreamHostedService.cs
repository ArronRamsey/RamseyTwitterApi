﻿using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;

namespace RamseyTwitterApi.HostedServices
{
    public class TwitterStreamHostedService : IHostedService
    {
        private ITwitterApiService ApiService { get; }
        private ITweetService TweetService { get; }
        private ILogger<TwitterStreamHostedService> Log { get; }
        private ITweetStatisticsService TweetStatisticsService { get; }

        public TwitterStreamHostedService(ITwitterApiService twitterApiService, 
                                          ITweetService tweetService, 
                                          ILogger<TwitterStreamHostedService> log,
                                          ITweetStatisticsService tweetStatisticsService)
        {
            ApiService = twitterApiService;
            TweetService = tweetService;
            Log = log;
            TweetStatisticsService = tweetStatisticsService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            ApiService.TweetReceived += (dto) =>
            {
                TweetService.TweetReceived(dto);
                TweetStatisticsService.TweetReceived();
            };
            Task.Run(() => ApiService.Connect());
            Log.LogWarning("TwitterStreamService_StartAsync");
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            ApiService.Disconnect();
            Log.LogWarning($"Final Tweet Count: {TweetStatisticsService.TweetCount}");
            Log.LogWarning($"Final Tweets Per Minute: {TweetStatisticsService.TweetsPerMinute}");
            return Task.CompletedTask;
        }

    }
}
