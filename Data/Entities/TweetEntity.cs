﻿namespace Data.Entities
{
    public class TweetEntity
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
    }

}
