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
                TweetReceived?.Invoke(new Core.Dtos.TweetDto()
                {
                    AuthorId = Guid.NewGuid().ToString(),
                    CreatedOn = DateTime.Now,
                    Text = Guid.NewGuid().ToString(),
                    HashTags = new List<string>() {"H1", "H2" }
                });
            }
        }

        public void Disconnect()
        {
            //Nothing!
        }

    }
}
