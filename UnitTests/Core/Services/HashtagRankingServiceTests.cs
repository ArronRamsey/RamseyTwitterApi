using Core.Dtos;
using Core.Services.Implementations;
using Microsoft.AspNetCore.Diagnostics;
using System.Text;
using Tweetinvi.Models.V2;

namespace UnitTests.Core.Services
{
    [TestClass]
    public class HashtagRankingServiceTests
    {
        [TestMethod]
        public void GetStatstics()
        {
            var service = new HashtagRankingService();

            foreach (var tweet in GetTweets())
            {
                service.TweetReceived(tweet);
            }

            Assert.AreEqual(GetExpectedString(), service.GetStatistics());

        }

        private List<TweetDto> GetTweets()
        {
            return new List<TweetDto>()
            {
                new TweetDto() { HashTags = new List<string>() { "Tag1" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3", "Tag4" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3", "Tag4", "Tag5" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3", "Tag4", "Tag5", "Tag6" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3", "Tag4", "Tag5", "Tag6", "Tag7" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3", "Tag4", "Tag5", "Tag6", "Tag7", "Tag8" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3", "Tag4", "Tag5", "Tag6", "Tag7", "Tag8", "Tag9" } },
                new TweetDto() { HashTags = new List<string>() { "Tag1", "Tag2", "Tag3", "Tag4", "Tag5", "Tag6", "Tag7", "Tag8", "Tag9", "Tag10" } }
            };
        }

        private string GetExpectedString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("HashTag Top 10:");
            sb.AppendLine("Place: 1.  Used: 9.  Tag: Tag1");
            sb.AppendLine("Place: 2.  Used: 8.  Tag: Tag2");
            sb.AppendLine("Place: 3.  Used: 8.  Tag: Tag3");
            sb.AppendLine("Place: 4.  Used: 7.  Tag: Tag4");
            sb.AppendLine("Place: 5.  Used: 6.  Tag: Tag5");
            sb.AppendLine("Place: 6.  Used: 5.  Tag: Tag6");
            sb.AppendLine("Place: 7.  Used: 4.  Tag: Tag7");
            sb.AppendLine("Place: 8.  Used: 3.  Tag: Tag8");
            sb.AppendLine("Place: 9.  Used: 2.  Tag: Tag9");
            sb.AppendLine("Place: 10.  Used: 1.  Tag: Tag10");
            return sb.ToString();
        }
    }
}
