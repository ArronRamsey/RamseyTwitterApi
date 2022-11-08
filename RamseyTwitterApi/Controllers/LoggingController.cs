using Microsoft.AspNetCore.Mvc;
using RamseyTwitterApi.HostedServices;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController : ControllerBase
    {
        private TweetLoggerHostedService LoggingService { get; }
        
        public LoggingController(TweetLoggerHostedService hostedService)
        {
            LoggingService = hostedService;
        }

        [HttpPut]
        [Route("StopLogging")]
        public void StopLogging()
        {
            LoggingService.StopLogging();
        }

        [HttpPut]
        [Route("StartLogging")]
        public void StartLogging()
        {
            LoggingService.StartLogging();
        }

    }
}
