using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming.V2;

namespace Infrastructure.Services.Implementations
{
    public class TweetInviService : ITwitterApiService
    {
        public event ITwitterApiService.ReceivedTweet? TweetReceived;
       
        private ISettingService settingService { get; }
        private ISampleStreamV2 Stream { get; }

        public TweetInviService(ISettingService settings)
        {
            settingService = settings;
            Stream = GetStream();
        }

        public void Connect()
        {
            Stream.StartAsync();
        }

        public void Disconnect()
        {
            Stream.StopStream();
        }

        private ISampleStreamV2 GetStream()
        {
            var credentials = new ConsumerOnlyCredentials()
            {
                BearerToken = settingService.GetSettings().BearerToken,
                ConsumerKey = settingService.GetSettings().ConsumerKey,
                ConsumerSecret = settingService.GetSettings().ConsumerSecret
            };
            var sampledStream = new TwitterClient(credentials).StreamsV2.CreateSampleStream();
            sampledStream.TweetReceived += (sender, eventArgs) =>
            {
                TweetReceived?.Invoke();
            };
            return sampledStream;
        }

    }
}
