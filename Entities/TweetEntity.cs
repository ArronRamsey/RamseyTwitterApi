namespace Entities
{
    public class TweetEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public IList<HashTagEntity> Tags { get; set; } = new List<HashTagEntity>();    
    }

}
