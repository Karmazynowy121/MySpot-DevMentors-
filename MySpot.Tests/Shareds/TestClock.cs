using MySpot.Core.Abstractions;

namespace MySpot.Tests.Unit.Shareds
{
    public class TestClock : IClock
    {
        public DateTime Current() => new(2023, 04, 08, 12, 0, 0);
    }
}
