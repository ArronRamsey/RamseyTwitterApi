namespace Infrastructure.Services.Interfaces
{
    public interface ITwitterApiService
    {
        event EventHandler TweetReceived;
        void Connect();
        void Disconnect();
    }
}
