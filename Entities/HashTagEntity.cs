using System.Net.Http.Headers;

namespace Entities
{
    public class HashTagEntity
    {
        public string Id { get; set; }  = string.Empty;
        public string TweetId { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;

        public override bool Equals(object? obj)
        {
            return obj is HashTagEntity entity &&
                   Id == entity.Id &&
                   TweetId == entity.TweetId &&
                   Text == entity.Text;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, TweetId, Text);
        }

        public static bool operator ==(HashTagEntity? left, HashTagEntity? right)
        {
            return EqualityComparer<HashTagEntity>.Default.Equals(left, right);
        }

        public static bool operator !=(HashTagEntity? left, HashTagEntity? right)
        {
            return !(left == right);
        }
    }
}
