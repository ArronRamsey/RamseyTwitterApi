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
            Assert.AreEqual(3, props.Count());
        }

        [TestMethod]
        public void ConstructorsEqual()
        {
            var dto1 = new TweetDto() { Text = "1", AuthorId = "2", CreatedOn = new DateTime(2020,11,06,00,00,00)};
            var dto2 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00));
            Assert.AreEqual(dto1, dto2);
        }

        [TestMethod]
        public void Equals0()
        {
            var dto1 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00));
            var dto2 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00));
            Assert.AreEqual(dto1, dto2);
        }

        [TestMethod]
        public void Equals1()
        {
            var dto1 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00));
            var dto2 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00));
            Assert.IsTrue(dto1 == dto2);
        }

        [TestMethod]
        public void Equals2()
        {
            var dto1 = new TweetDto("1", "3", new DateTime(2020, 11, 06, 00, 00, 00));
            var dto2 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00));
            Assert.IsTrue(dto1 != dto2);
        }

        [TestMethod]
        public void Equals3()
        {
            var dto1 = new TweetDto("1", "3", new DateTime(2020, 11, 06, 00, 00, 00));
            var dto2 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00));
            Assert.AreNotEqual(dto1, dto2);
        }

        [TestMethod]
        public void Equals4()
        {
            var dto1 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00)).GetHashCode();
            var dto2 = new TweetDto("1", "2", new DateTime(2020, 11, 06, 00, 00, 00)).GetHashCode();
            Assert.AreEqual(dto1, dto2);
        }

    }
}
