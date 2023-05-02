
using MySpot.Core.ValueObjects;

namespace MySpot.Core.Exceptions
{
    public sealed class CaanotReserveParkingSpotException : CustomException
    {
        public ParkingSpotId ParkingSpotId { get; set; }
        public CaanotReserveParkingSpotException(ParkingSpotId parkingSpotId)
            :base($"Cannot reserve parking spot Id: {parkingSpotId}")
        {
            ParkingSpotId= parkingSpotId;
        }
    }
}
