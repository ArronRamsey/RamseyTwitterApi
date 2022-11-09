using Core.Dtos;

namespace UnitTests.Core.Dtos
{
    [TestClass]
    public class TweetDtoTests
    {
        /// <summary>
        /// Idea behind this is to throw a failure and prompt to correct 
        /// the equals override and other places the properties would be used
        /// </summary>
        [TestMethod]
        public void PropertyCount()
        {
            var dto = new TweetDto();
            var props = dto.GetType().GetProperties();
            Assert.AreEqual(4, props.Count());
        }

        [TestMethod]
        public void Equals0()
        {
            var dto1 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            var dto2 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            Assert.AreEqual(dto1, dto2);
        }

        [TestMethod]
        public void Equals1()
        {
            var dto1 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            var dto2 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            Assert.IsTrue(dto1 == dto2);
        }

        [TestMethod]
        public void Equals2()
        {
            var dto1 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            var dto2 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text1",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            Assert.IsTrue(dto1 != dto2);
        }

        [TestMethod]
        public void Equals3()
        {
            var dto1 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            var dto2 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text1",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            };
            Assert.AreNotEqual(dto1, dto2);
        }

        [TestMethod]
        public void Equals4()
        {
            var dto1 = new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            }.GetHashCode();
            var dto2 =  new TweetDto()
            {
                AuthorId = "Id",
                Text = "Text",
                CreatedOn =
                new DateTime(2022, 11, 06, 00, 00, 00),
                HashTags = new List<string>()
            }.GetHashCode();
            Assert.AreEqual(dto1, dto2);
        }

        [TestMethod]
        public void HashtagsNotNullOnInstantiation()
        {
            var dto1 = new TweetDto();
            Assert.IsNotNull(dto1.HashTags);
        }

    }
}
