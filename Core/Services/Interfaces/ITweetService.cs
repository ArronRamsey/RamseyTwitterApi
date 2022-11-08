using Core.Dtos;

namespace Core.Services.Interfaces
{
    public interface ITweetService
    {
        void TweetReceived(TweetDto dto);
        void StartWriteLogAsync();
        void StopWriteLogAsync();
    }

}
