namespace Entities
{
    public class TweetEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public IList<HashTagEntity> Tags { get; set; } = new List<HashTagEntity>();

        public override bool Equals(object? obj)
        {
            return obj is TweetEntity entity &&
                   Id == entity.Id &&
                   Text == entity.Text &&
                   Author == entity.Author &&
                   CreatedOn == entity.CreatedOn &&
                   Tags.SequenceEqual(entity.Tags);
        }

        public override int GetHashCode()
        {
            var tagsHash = 19;
            foreach (var tag in Tags)
            {
                tagsHash = tagsHash * 31 + tag.GetHashCode();
            }
            return HashCode.Combine(Id, Text, Author, CreatedOn, tagsHash);
        }

        public static bool operator ==(TweetEntity? left, TweetEntity? right)
        {
            return EqualityComparer<TweetEntity>.Default.Equals(left, right);
        }

        public static bool operator !=(TweetEntity? left, TweetEntity? right)
        {
            return !(left == right);
        }
    }

}
