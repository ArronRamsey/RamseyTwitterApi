
namespace Core.Dtos
{
    public class TweetDto : IEquatable<TweetDto?>
    {

        public string Text { get; set; } = String.Empty;
        public string AuthorId { get; set; } = String.Empty;

        public TweetDto()
        {
        }

        public TweetDto(string TweetText, string TweetAuthorId)
        {
            Text = TweetText;
            AuthorId = TweetAuthorId;
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TweetDto);
        }

        public bool Equals(TweetDto? other)
        {
            return other is not null &&
                   Text == other.Text &&
                   AuthorId == other.AuthorId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, AuthorId);
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
