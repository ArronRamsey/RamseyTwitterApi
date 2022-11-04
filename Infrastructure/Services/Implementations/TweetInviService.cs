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
        private ISampleStreamV2 Stream { 
            get
            {
                if (Stream == null)
                {
                    Stream =  GetStream();
                }
                return Stream;
            }
            set
            {
                Stream = value;
            } 
        }

        public TweetInviService(ISettingService settings)
        {
            settingService = settings;
        }

        public void Connect()
        {
            Stream.TweetReceived += (sender, eventArgs) =>
            {
                TweetReceived?.Invoke();
            }; 
            Stream.StartAsync();
        }

        public void Disconnect()
        {
            Stream.StopStream();
        }

        private ISampleStreamV2 GetStream()
        {
            return new TwitterClient(GetCredentials()).StreamsV2.CreateSampleStream();
        }

        private ConsumerOnlyCredentials GetCredentials()
        {
            return new ConsumerOnlyCredentials()
            {
                BearerToken = settingService.GetSettings().BearerToken,
                ConsumerKey = settingService.GetSettings().ConsumerKey,
                ConsumerSecret = settingService.GetSettings().ConsumerSecret
            };
        }

    }
}
