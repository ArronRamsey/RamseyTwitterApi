using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Entities
{
    [TestClass]
    public class TweetEntityTests
    {
        [TestMethod]
        public void Equals()
        {
            var tweet1 = GetTweet();
            var tweet2 = GetTweet();
            Assert.AreEqual(tweet1, tweet2);
        }

        [TestMethod]
        public void EqualsOperator()
        {
            var tweet1 = GetTweet();
            var tweet2 = GetTweet();
            Assert.IsTrue(tweet1 == tweet2);
        }

        [TestMethod]
        public void NotEqualsOperator()
        {
            var tweet1 = GetTweet();
            var tweet2 = GetTweet();
            tweet2.Author = "Blah";
            Assert.IsTrue(tweet1 != tweet2);
        }

        [TestMethod]
        public void HashCode()
        {
            var tweet1 = GetTweet().GetHashCode();
            var tweet2 = GetTweet().GetHashCode();
            Assert.AreEqual(tweet1, tweet2);
        }

        private TweetEntity GetTweet()
        {
            return new TweetEntity()
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
        }
    }

}
