using Core.Services.Interfaces;

namespace RamseyTwitterApi.HostedServices
{
    public class TweetLoggerHostedService : IHostedService
    {
        private ILoggingService LogService { get; }
        
        //These exist to enable the stopping and starting of the logging task without stopping the hosted service
        private CancellationTokenSource LoggingTaskCancelSource { get; set; }
        private CancellationToken LoggingToken { get; set; }

        public TweetLoggerHostedService(ILoggingService logService)
        {
            LoggingTaskCancelSource = new CancellationTokenSource();
            LoggingToken = LoggingTaskCancelSource.Token;
            LogService = logService;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(() => LogService.RunLogAsync(LoggingToken), LoggingToken);
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            LoggingTaskCancelSource.Cancel();
            Thread.Sleep(5000);
            return Task.CompletedTask;
        }
       
    }
}
