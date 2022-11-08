using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController : ControllerBase
    {
        private ILoggingService Logger { get; }

        public LoggingController(ILoggingService logger)
        {
            Logger = logger;
        }

        [HttpPut]
        [Route("StopLogging")]
        public void StopLogging()
        {
            Logger.LoggingEnabled = false;
        }

        [HttpPut]
        [Route("StartLogging")]
        public void StartLogging()
        {
            Logger.LoggingEnabled = true;
        }

    }
}
