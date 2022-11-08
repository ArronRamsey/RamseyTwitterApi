using FrameworkAbstractions.Interfaces;

namespace FrameworkAbstractions.Implementations
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }

}
