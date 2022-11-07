namespace Core.Dtos
{
    public class TweetDto : IEquatable<TweetDto?>
    {
        public string Text { get; set; } = string.Empty;
        public string AuthorId { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }

        public TweetDto()
        {
        }

        public TweetDto(string TweetText, string TweetAuthorId, DateTime DateCreated)
        {
            Text = TweetText;
            AuthorId = TweetAuthorId;
            CreatedOn = DateCreated;    
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
