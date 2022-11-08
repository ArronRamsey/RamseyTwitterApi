using Core.Dtos;
using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatsController : ControllerBase
    {
        private ITweetService apiService { get; }
        
        public StatsController(ITweetService tweetService)
        {
            apiService = tweetService;
        }

        [HttpGet]
        public TweetStatisticsDto GetStats()
        {
            return apiService.Statistics;
        }

    }
}
