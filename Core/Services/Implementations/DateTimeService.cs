using Core.Services.Interfaces;

namespace Core.Services.Implementations
{
    public class DateTimeService : IDateTimeService
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }

}
