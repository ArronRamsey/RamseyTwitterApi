using Core.Dtos;

namespace Core.Services.Interfaces
{
    public interface IHashtagRankingService
    {
        string GetStatistics();
        void TweetReceived(TweetDto dto);
    }
}
