using Core.Dtos;
using Core.Services.Interfaces;
using Data.Repositories.Interfaces;
using Entities;
using FrameworkAbstractions.Interfaces;

namespace Core.Services.Implementations
{
    public class TweetService : ITweetService
    {
        private ITweetRepository TweetRepo { get; }
        private IGuidService GuidService { get; }

        public TweetService(ITweetRepository tweetRepository, IGuidService guidService)
        {
            TweetRepo = tweetRepository;
            GuidService = guidService;
        }

        public void TweetReceived(TweetDto dto)
        {
            var tweetId = GuidService.GetGuid().ToString();
            var tweet = new TweetEntity()
            {
                Author = dto.AuthorId,
                CreatedOn = dto.CreatedOn,
                Id = tweetId,
                Text = dto.Text
            };
            dto.HashTags.ToList().ForEach(x => tweet.Tags.Add(new HashTagEntity()
            {
                Id = GuidService.GetGuid().ToString(),
                TweetId = tweetId,
                Text = x
            }));
            TweetRepo.SaveTweet(tweet);
        }

        public TweetEntity GetLastTweet()
        {
            return TweetRepo.GetLastTweet();
        }

    }
}
