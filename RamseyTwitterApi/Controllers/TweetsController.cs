using Core.Dtos;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TweetsController : ControllerBase
    {
        private ITweetService apiService { get; }
        
        public TweetsController(ITweetService tweetService)
        {
            apiService = tweetService;
        }

        [HttpGet]
        public TweetStatisticsDto GetInfo()
        {
            return new TweetStatisticsDto()
            {
                TweetsPerMinute = apiService.TweetsPerMinute,
                TweetsReceived = apiService.TweetCount
            };
        }
    }
}
