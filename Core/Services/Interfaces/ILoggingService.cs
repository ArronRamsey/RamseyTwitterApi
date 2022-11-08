namespace Core.Services.Interfaces
{
    public interface ILoggingService
    {
        void WriteLog();
        void RunLogAsync(CancellationToken LoggingToken);
        bool LoggingEnabled { get; set; }
    }
}
