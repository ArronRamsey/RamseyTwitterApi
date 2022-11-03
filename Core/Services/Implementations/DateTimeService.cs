using Core.Services.Interfaces;

namespace Core.Services.Implementations
{
    internal class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
