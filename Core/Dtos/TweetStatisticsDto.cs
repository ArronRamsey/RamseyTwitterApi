namespace Core.Dtos
{
    public class TweetStatisticsDto
    {
        public int TweetsReceived { get; set; }
        public double TweetsPerMinute { get; set; }

        public override bool Equals(object? obj)
        {
            return Equals(obj as TweetStatisticsDto);
        }

        public bool Equals(TweetStatisticsDto? other)
        {
            return other is not null &&
                   TweetsReceived == other.TweetsReceived &&
                   TweetsPerMinute == other.TweetsPerMinute;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(TweetsReceived, TweetsPerMinute);
        }

        public static bool operator ==(TweetStatisticsDto? left, TweetStatisticsDto? right)
        {
            return EqualityComparer<TweetStatisticsDto>.Default.Equals(left, right);
        }

        public static bool operator !=(TweetStatisticsDto? left, TweetStatisticsDto? right)
        {
            return !(left == right);
        }
        
    }
}
