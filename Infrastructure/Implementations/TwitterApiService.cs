using Core.Interfaces;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Streaming.V2;

namespace Infrastructure.Implementations
{
    public class TwitterApiService : ITwitterApiService
    {
        private ISettingService settingService { get; }
        private ISampleStreamV2? apiStream { get; set; }

        public TwitterApiService(ISettingService settings)
        {
            settingService = settings;
        }

        public void Connect()
        {
            var credentials = new ConsumerOnlyCredentials()
            {
                BearerToken = settingService.GetSettings().BearerToken,
                ConsumerKey = settingService.GetSettings().ConsumerKey,
                ConsumerSecret=settingService.GetSettings().ConsumerSecret
            };
            apiStream = new TwitterClient(credentials).StreamsV2.CreateSampleStream();
            apiStream.StartAsync();
        }

        public void Disconnect()
        {
            apiStream.StopStream();
        }

    }
}
