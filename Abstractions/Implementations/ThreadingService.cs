using FrameworkAbstractions.Interfaces;

namespace FrameworkAbstractions.Implementations
{
    public class ThreadingService : IThreadingService
    {
        public void Sleep(int millisecondsToSleep)
        {
            Thread.Sleep(millisecondsToSleep);
        }
    }

}
