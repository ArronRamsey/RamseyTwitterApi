using Core.Services.Implementations;
using NSubstitute;
using Core.Dtos;
using Data.Repositories.Interfaces;
using Entities;
using FrameworkAbstractions.Interfaces;

namespace Tests.Core.Services
{
    [TestClass]
    public class TweetServiceTests
    {

        [TestMethod]
        public void TweetReceived()
        {
            var repo = Substitute.For<ITweetRepository>();
            var guid = Substitute.For<IGuidService>();
            guid.GetGuid().Returns(new Guid("16114e50-411f-48d3-89f7-8292898e7741"),
                                   new Guid("26114e50-411f-48d3-89f7-8292898e7741"),
                                   new Guid("36114e50-411f-48d3-89f7-8292898e7741"));
            repo.GetAll().Returns(new List<TweetEntity>() { new TweetEntity() { Text = "123" } });
            var service = new TweetService(repo, guid);
            service.TweetReceived(GetTestDto());
            var expectedTweet = new TweetEntity()
            {
                Author = "Author",
                CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00),
                Text = "Text",
                Id = "16114e50-411f-48d3-89f7-8292898e7741",
                Tags = new List<HashTagEntity>()
                {
                    new HashTagEntity() { Text = "Tag1", Id = "26114e50-411f-48d3-89f7-8292898e7741", TweetId = "16114e50-411f-48d3-89f7-8292898e7741" },
                    new HashTagEntity() { Text = "Tag2", Id = "36114e50-411f-48d3-89f7-8292898e7741", TweetId = "16114e50-411f-48d3-89f7-8292898e7741" }
                }
            };
            repo.Received().SaveTweet(expectedTweet);
        }

        [TestMethod]
        public void GetLastTweet_NotNull()
        {
            var repo = Substitute.For<ITweetRepository>();
            repo.GetLastTweet().Returns(new TweetEntity() { Id = "1" });
            var guid = Substitute.For<IGuidService>();
            var service = new TweetService(repo, guid);
            var entity = service.GetLastTweet();
            Assert.AreEqual("1", entity.Id);
        }

        [TestMethod]
        public void GetLastTweet_NullRepo_InstantiatedEntityReturned()
        {
            var repo = Substitute.For<ITweetRepository>();
            var guid = Substitute.For<IGuidService>();
            var service = new TweetService(repo, guid);
            var entity = service.GetLastTweet();
            Assert.AreEqual("", entity.Id);
        }

        private TweetDto GetTestDto()
        {
            return new TweetDto()
            {
                AuthorId = "Author",
                Text = "Text",
                CreatedOn = new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
                {
                    "Tag1", "Tag2"
                }
            };
        }
    }
}