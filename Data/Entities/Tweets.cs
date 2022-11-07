namespace Data.Entities
{
    public class Tweets
    {
        int id { get; set; }
        string Text { get; set; } = string.Empty;
        string Author { get; set; } = string.Empty;
        DateTime CreatedOn { get; set; }
    }
}
