using Core.Dtos;

namespace UnitTests.Core.Dtos
{
    [TestClass]
    public class TweetStatisticsDtoTests
    {
        /// <summary>
        /// Idea behind this is to throw a failure and prompt to correct 
        /// the equals override and other places the properties would be used
        /// </summary>
        [TestMethod]
        public void PropertyCount()
        {
            var dto = new TweetStatisticsDto();
            var props = dto.GetType().GetProperties();
            Assert.AreEqual(2, props.Count());
        }

        [TestMethod]
        public void Equals0()
        {
            var dto1 = new TweetStatisticsDto() { TweetsPerMinute = 2, TweetsReceived = 3 };
            var dto2 = new TweetStatisticsDto() { TweetsPerMinute = 2, TweetsReceived = 3 };
            Assert.AreEqual(dto1, dto2);
        }

        [TestMethod]
        public void Equals1()
        {
            var dto1 = new TweetStatisticsDto() { TweetsPerMinute = 2, TweetsReceived = 3 };
            var dto2 = new TweetStatisticsDto() { TweetsPerMinute = 2, TweetsReceived = 3 };
            Assert.IsTrue(dto1 == dto2);
        }

        [TestMethod]
        public void NotEquals()
        {
            var dto1 = new TweetStatisticsDto() { TweetsPerMinute = 3, TweetsReceived = 3 };
            var dto2 = new TweetStatisticsDto() { TweetsPerMinute = 2, TweetsReceived = 3 };
            Assert.IsTrue(dto1 != dto2);
        }

        [TestMethod]
        public void HashCode()
        {
            var hash1 = new TweetStatisticsDto() { TweetsPerMinute = 2, TweetsReceived = 3 }.GetHashCode(); ;
            var hash2 = new TweetStatisticsDto() { TweetsPerMinute = 2, TweetsReceived = 3 }.GetHashCode();
            Assert.AreEqual(hash1, hash2);
        }

    }
}
