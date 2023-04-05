namespace MySpot.Core.Exceptions
{
    public class InvalidParkingSpotNameException : CustomException
    {
        public InvalidParkingSpotNameException() : base("Invalid Parking Spot Name")
        {
        }
    }
}
