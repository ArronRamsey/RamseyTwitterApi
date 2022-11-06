﻿using Core.Dtos;

namespace Core.Services.Interfaces
{
    public interface ITweetService
    {
        int TweetCount { get; }
        double TweetsPerMinute { get; }
        void TweetReceived(TweetDto dto);
        void StartWriteLogAsync();
        void StopWriteLogAsync();
    }
}
