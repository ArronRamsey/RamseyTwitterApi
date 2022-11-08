using Entities;
using Data.Repositories.Implementations;

namespace UnitTests.Repositories
{
    [TestClass]
    public class TweetRepositoryUnitTests
    {
        [TestMethod]
        public void Save_GetAll()
        {
            var repo = new TweetRepository();
            repo.SaveTweet(new TweetEntity() { Author = "Author1", Text = "Text1", Id = "1", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00) });
            repo.SaveTweet(new TweetEntity() { Author = "Author2", Text = "Text2", Id = "2", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00) });
            repo.SaveTweet(new TweetEntity() { Author = "Author3", Text = "Text3", Id = "3", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00) });
            repo.SaveTweet(new TweetEntity() { Author = "Author4", Text = "Text4", Id = "4", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 01) });
            var allTweets = repo.GetAll();
            Assert.AreEqual(4, allTweets.Count());
        }

        [TestMethod]
        public void GetLastTweet()
        {
            var repo = new TweetRepository();
            repo.SaveTweet(new TweetEntity() { Author = "Author1", Text = "Text1", Id = "1", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00) });
            repo.SaveTweet(new TweetEntity() { Author = "Author2", Text = "Text2", Id = "2", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00) });
            repo.SaveTweet(new TweetEntity() { Author = "Author3", Text = "Text3", Id = "3", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00) });
            repo.SaveTweet(new TweetEntity() { Author = "Author4", Text = "Text4", Id = "4", CreatedOn = new DateTime(2022, 11, 07, 00, 00, 01) });
            var lastTweet = repo.GetLastTweet();
            Assert.AreEqual("4", lastTweet.Id);
        }

        [TestMethod]
        public void TweetSaved()
        {
            var repo = new TweetRepository();
            var tweet = new TweetEntity()
            {
                Author = "Author1",
                Text = "Text1",
                Id = "1",
                CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00),
                Tags = new List<HashTagEntity>()
                {
                    new HashTagEntity()
                    {
                        Id = "1",
                        TweetId = "1",
                        Text = "Text"
                    }
                    }
            };

            var expectedTweet = new TweetEntity()
            {
                Author = "Author1",
                Text = "Text1",
                Id = "1",
                CreatedOn = new DateTime(2022, 11, 07, 00, 00, 00),
                Tags = new List<HashTagEntity>()
                {
                    new HashTagEntity()
                    {
                        Id = "1",
                        TweetId = "1",
                        Text = "Text"
                    }
                    }
            };

            repo.SaveTweet(tweet);
            var lastTweet = repo.GetAll().ToList()[0];
            Assert.AreEqual(expectedTweet, lastTweet);
        }

        [TestMethod]
        public void LastTweet_EmptyCollection_IdReturnedIsEmpty()
        {
            var repo = new TweetRepository();
            var lastTweet = repo.GetLastTweet();
            Assert.AreEqual("", lastTweet.Id);
        }

    }
}
