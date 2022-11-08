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
        [Route("GetStats")]
        public TweetStatisticsDto GetStats()
        {
            return apiService.Statistics;
        }

        [HttpGet]
        [Route("GetTags")]
        public string GetTags()
        {
            return apiService.GetStats();
        }

    }
}
