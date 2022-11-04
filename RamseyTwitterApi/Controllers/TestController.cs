using Core.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private ITweetService apiService { get; }
        
        public TestController(ITweetService tweetService)
        {
            apiService = tweetService;
        }

        [HttpGet]
        public int TestConnect()
        {
            return apiService.TweetCount;
        }
    }
}
