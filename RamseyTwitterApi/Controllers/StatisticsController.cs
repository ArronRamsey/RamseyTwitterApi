using Core.Dtos;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private ITweetStatisticsService StatisticService { get; }
        
        public StatisticsController(ITweetStatisticsService statService)
        {
            StatisticService = statService;
        }

        [HttpGet]
        [Route("GetStats")]
        public TweetStatisticsDto GetStats()
        {
            return StatisticService.GetStatistics();
        }

        [HttpGet]
        [Route("TweetCount")]
        public int TweetCount()
        {
            return StatisticService.GetTweetCount();
        }

        [HttpGet]
        [Route("TweetsPerMinute")]
        public double TweetsPerMinute()
        {
            return StatisticService.GetTweetsPerMinute();
        }

    }
}
