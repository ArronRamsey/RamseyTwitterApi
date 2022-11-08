using System.Net.Http.Headers;

namespace Entities
{
    public class HashTagEntity
    {
        public string Id { get; set; }  = string.Empty;
        public string TweetId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
    }
}
