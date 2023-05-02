using MySpot.Core.Abstractions;

namespace MySpot.Infrastructure.Services
{
    public class Clock : IClock
    {
        public DateTime Current() => DateTime.UtcNow;
    }

    
}
