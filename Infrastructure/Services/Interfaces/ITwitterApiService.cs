
using Tweetinvi.Streaming.V2;

namespace Infrastructure.Services.Interfaces
{
    public interface ITwitterApiService
    {
        ISampleStreamV2 GetStream();
    }
}
