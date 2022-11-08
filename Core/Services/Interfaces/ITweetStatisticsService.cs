using Core.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Interfaces
{
    public interface ITweetStatisticsService
    {
        int TweetCount { get; }
        double TweetsPerMinute { get; }
        TweetStatisticsDto Statistics { get; }
        void TweetReceived();

    }
}
