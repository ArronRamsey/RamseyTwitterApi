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
            StartLogging();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            LoggingTaskCancelSource.Cancel();
            return Task.CompletedTask;
        }

        public void StopLogging()
        {
            LoggingTaskCancelSource.Cancel();
        }

        public void StartLogging()
        {
            if (LoggingToken.IsCancellationRequested)
            {
                //We cancelled the task.  Need to re-initialize
                LoggingTaskCancelSource = new CancellationTokenSource();
                LoggingToken = LoggingTaskCancelSource.Token;
            }
            Task.Run(() => LogService.StartWriteLog(), LoggingToken);
        }
       
    }
}
