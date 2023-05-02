
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Entities
{
    public sealed class VehicleReservation : Reservation
    {
        public UserId UserId { get; }
        public EmployeeName EmployeeName { get; }
        public LicensePlate LicensePlate { get; private set; }

        private VehicleReservation()
        {
        }

        public VehicleReservation(ReservationId reservationId, UserId userId, EmployeeName employeeName,
            LicensePlate licensePlate, Capacity capacity, Date date) : base(reservationId, capacity, date)
        {
            UserId = userId;
            EmployeeName = employeeName;
            LicensePlate = licensePlate;
        }

        public void ChangeLicencePlate(LicensePlate licensePlate)
            => LicensePlate = licensePlate;
    }


}
