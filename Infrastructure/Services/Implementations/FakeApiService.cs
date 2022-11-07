using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services.Implementations
{
    public class FakeApiService : ITwitterApiService
    {
        public event ITwitterApiService.ReceivedTweet? TweetReceived;

        public void Connect()
        {
            var start = DateTime.Now;
            while ((DateTime.Now - start).TotalSeconds < 180)
            {
                TweetReceived?.Invoke(new Core.Dtos.TweetDto(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), DateTime.Now));
                Thread.Sleep(500);
            }
        }

        public void Disconnect()
        {
            //Nothing!
        }

    }
}
