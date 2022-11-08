using FrameworkAbstractions.Interfaces;
using Core.Dtos;
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
       
        IDateTimeService DateService { get; }
        private ISettingService settingService { get; }
        private ISampleStreamV2 Stream { get; }

        public TweetInviService(ISettingService settings, IDateTimeService dateTimeService)
        {
            settingService = settings;
            DateService = dateTimeService;
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
            sampledStream.TweetReceived += (sender, args) =>
            {
                TweetReceived?.Invoke(new TweetDto()
                {
                    AuthorId = args.Tweet.AuthorId,
                    CreatedOn = DateService.Now(),
                    Text = args.Tweet.Text,
                    HashTags = args.Tweet.Entities.Hashtags == null ? 
                               new List<string>() :
                               args.Tweet.Entities.Hashtags.Select(x => x.Tag).ToList()

                });; 
            };
            return sampledStream;
        }

    }
}
