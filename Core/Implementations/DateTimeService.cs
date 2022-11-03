using Core.Interfaces;

namespace Core.Implementations
{
    internal class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
