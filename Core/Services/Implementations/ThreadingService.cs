using Core.Services.Interfaces;

namespace Core.Services.Implementations
{
    public class ThreadingService : IThreadingService
    {
        public void Sleep(int millisecondsToSleep)
        {
            Thread.Sleep(millisecondsToSleep);
        }
    }
}
