using Core.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HashtagRankingController : ControllerBase
    {
        private IHashtagRankingService HashtagRankingService { get; }
        
        public HashtagRankingController(IHashtagRankingService hashtagRankingService)
        {
            HashtagRankingService = hashtagRankingService;
        }

        [HttpGet]
        public string GetRanking()
        {
            return HashtagRankingService.GetStatistics();
        }

    }
}
