using Entities;

namespace UnitTests.Entities
{
    [TestClass]
    public class HashTagEntityTests
    {
        [TestMethod]
        public void Equals0()
        {
            var entity1 = new HashTagEntity() { Id = "1", Text = "2", TweetId = "3" };
            var entity2 = new HashTagEntity() { Id = "1", Text = "2", TweetId = "3" };
            Assert.AreEqual(entity1, entity2);
        }

        [TestMethod]
        public void EqualsOperator()
        {
            var entity1 = new HashTagEntity() { Id = "1", Text = "2", TweetId = "3" };
            var entity2 = new HashTagEntity() { Id = "1", Text = "2", TweetId = "3" };
            Assert.IsTrue(entity1 == entity2);
        }

        [TestMethod]
        public void NotEqualsOperator()
        {
            var entity1 = new HashTagEntity() { Id = "1", Text = "2", TweetId = "3" };
            var entity2 = new HashTagEntity() { Id = "2", Text = "2", TweetId = "3" };
            Assert.IsTrue(entity1 != entity2);
        }

        [TestMethod]
        public void HashCode()
        {
            var entity1 = new HashTagEntity() { Id = "1", Text = "2", TweetId = "3" }.GetHashCode();
            var entity2 = new HashTagEntity() { Id = "1", Text = "2", TweetId = "3" }.GetHashCode();
            Assert.AreEqual(entity1, entity2);
        }

    }
}
