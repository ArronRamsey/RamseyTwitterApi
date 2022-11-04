using Infrastructure.Services.Interfaces;

namespace Infrastructure.Services.Implementations
{
    public class FakeApiService : ITwitterApiService
    {
        public event ITwitterApiService.ReceivedTweet? TweetReceived;

        public void Connect()
        {
            var start = DateTime.Now;
            while ((DateTime.Now - start).TotalSeconds < 30)
            {
                TweetReceived?.Invoke();
                System.Threading.Thread.Sleep(500);
            }
        }

        public void Disconnect()
        {
            //Nothing!
        }
    }
}
