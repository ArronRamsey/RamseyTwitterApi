using Core.Dtos;
using Core.Services.Interfaces;
using System.Text;

namespace Core.Services.Implementations
{

    public class HashtagRankingService: IHashtagRankingService
    {
        private Dictionary<string, int> TagStats { get; set; } = new Dictionary<string, int>();

        public string GetStatistics()
        {
            var sb = new StringBuilder();
            sb.AppendLine("HashTag Top 10:");
            var i = 1;
            foreach (var stat in TagStats.OrderByDescending(x => x.Value).Take(10).ToList())
            {
                sb.AppendLine($"Place: {i}.  Used: {stat.Value}.  Tag: {stat.Key}");
                i++;
            }
            return sb.ToString();
        }

        public void TweetReceived(TweetDto dto)
        {
            foreach (var tag in dto.HashTags)
            {
                if (TagStats.ContainsKey(tag))
                {
                    TagStats[tag] += 1;
                }
                else
                {
                    TagStats.Add(tag, 1);
                }
            }
        }

    }
}
