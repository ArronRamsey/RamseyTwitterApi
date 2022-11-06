using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace RamseyTwitterApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TwitterStreamController : ControllerBase
    {
        private ITwitterApiService ApiService { get; }
        
        public TwitterStreamController(ITwitterApiService service)
        {
            ApiService = service;
        }

        [HttpPut]
        [Route("Connect")]
        public void Connect()
        {
            ApiService.Connect();
        }

        [HttpPut]
        [Route("Disconnect")]
        public void Disconnect()
        {
            ApiService.Disconnect();
        }
    }
}
