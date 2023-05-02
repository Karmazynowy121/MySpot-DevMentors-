using MySpot.Application.Abstractions;

namespace MySpot.Application.Commands
{
    public record ReserveParkingSpotForVehicle(Guid ParkingSpotId, Guid ReservationId, Guid UserId,
    string LicensePlate, int Capacity, DateTime Date) : ICommand;

}
