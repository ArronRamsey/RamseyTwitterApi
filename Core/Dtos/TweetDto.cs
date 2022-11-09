namespace Core.Dtos
{
    public class TweetDto
    {
        public string Text { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public IEnumerable<string> HashTags { get; set; } = new List<string>();

        public TweetDto()
        {
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TweetDto);
        }

        public bool Equals(TweetDto? other)
        {
            return other is not null &&
                   Text == other.Text &&
                   CreatedOn == other.CreatedOn &&
                   HashTags.SequenceEqual(other.HashTags) &&
                   AuthorId == other.AuthorId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, AuthorId, CreatedOn);
        }

        public static bool operator ==(TweetDto? left, TweetDto? right)
        {
            return EqualityComparer<TweetDto>.Default.Equals(left, right);
        }

        public static bool operator !=(TweetDto? left, TweetDto? right)
        {
            return !(left == right);
        }
    }
}
