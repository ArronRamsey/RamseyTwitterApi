using Core.Interfaces;
using Infrastructure.Services.Interfaces;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming.V2;

namespace Infrastructure.Services.Implementations
{
    public class TwitterApiService : ITwitterApiService
    {
        private ISettingService settingService { get; }

        public TwitterApiService(ISettingService settings)
        {
            settingService = settings;
        }

        public ISampleStreamV2 GetStream()
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
