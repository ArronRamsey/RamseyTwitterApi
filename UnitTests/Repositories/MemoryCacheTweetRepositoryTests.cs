using Data.Repositories.Implementations;
using Entities;
using FrameworkAbstractions.Interfaces;
using NSubstitute;

namespace UnitTests.Repositories
{
    [TestClass]
    public class MemoryCacheTweetRepositoryTests
    {
        [TestMethod]
        public void Save_GetAll_GetReturnsNullMemory_SetCalled()
        {
            var cache = Substitute.For<ICacheService>();
            var repo = new MemoryCacheTweetRepository(cache);
            repo.GetAll();
            cache.Received().Get<List<TweetEntity>>(Arg.Any<string>());
            cache.Received().Set(Arg.Any<string>(), Arg.Any<List<TweetEntity>>());
        }

        [TestMethod]
        public void Save_GetLastTweet_Null()
        {
            var cache = Substitute.For<ICacheService>();
            var repo = new MemoryCacheTweetRepository(cache);
            cache.Get<List<TweetEntity>>(Arg.Any<string>()).Returns(new List<TweetEntity>());
            var tweet = repo.GetLastTweet();
            Assert.AreEqual("", tweet.Id);
        }

        [TestMethod]
        public void Save_GetLastTweet_NotNull()
        {
            var cache = Substitute.For<ICacheService>();
            var repo = new MemoryCacheTweetRepository(cache);
            cache.Get<List<TweetEntity>>(Arg.Any<string>()).Returns(new List<TweetEntity>()
            {
                new TweetEntity()
                {
                    Id = "1",
                    CreatedOn = new DateTime(2022, 08, 08, 08, 08, 08, 08)
                },
                new TweetEntity()
                {
                    Id = "2",
                    CreatedOn = new DateTime(2022, 08, 08, 08, 08, 08, 09)
                }
            });
            var tweet = repo.GetLastTweet();
            Assert.AreEqual("2", tweet.Id);
        }

        [TestMethod]
        public void SaveTweet()
        {
            var cache = Substitute.For<ICacheService>();
            var repo = new MemoryCacheTweetRepository(cache);
            cache.Get<List<TweetEntity>>(Arg.Any<string>()).Returns(new List<TweetEntity>());
            var tweet = new TweetEntity() { Id = "5" };
            repo.SaveTweet(tweet);
            cache.Received().Set(Arg.Any<string>(), Arg.Is<List<TweetEntity>>(x => x.Count == 1 && x[0].Id == "5"));
        }

    }
}
