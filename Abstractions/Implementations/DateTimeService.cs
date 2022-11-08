using Abstractions.Interfaces;

namespace Abstractions.Implementations
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }

}
