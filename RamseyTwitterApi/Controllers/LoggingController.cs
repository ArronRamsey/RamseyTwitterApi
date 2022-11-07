using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoggingController : ControllerBase
    {
        private ITweetService TweetService { get; }
        
        public LoggingController(ITweetService tweetService)
        {
            TweetService = tweetService;
        }

        [HttpPut]
        [Route("StopLogging")]
        public void StopLogging()
        {
            TweetService.StopWriteLogAsync();
        }

        [HttpPut]
        [Route("StartLogging")]
        public void StartLogging()
        {
            TweetService.StartWriteLogAsync();
        }

    }
}
