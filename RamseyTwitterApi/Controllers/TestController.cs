using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private ITwitterApiService apiService { get; }
        
        public TestController(ITwitterApiService twitterApiService )
        {
            apiService = twitterApiService;
        }

        [HttpGet]
        public void TestConnect()
        {
            apiService.Connect();
        }
    }
}
