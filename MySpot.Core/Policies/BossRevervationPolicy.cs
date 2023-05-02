

using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Policies
{
    internal sealed class BossRevervationPolicy : IReservationPolicy
    {
        public bool CanBeApllied(JobTitle jobTitle)
            => jobTitle == JobTitle.Boss;
        public bool CanReserve(IEnumerable<WeeklyParkingSpot> weeklyParkingSpots, EmployeeName employeeName)
            => true;
    }
}
