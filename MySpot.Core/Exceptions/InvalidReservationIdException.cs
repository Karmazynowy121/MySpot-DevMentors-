namespace MySpot.Core.Exceptions
{
    public class InvalidReservationIdException : CustomException
    {
        public InvalidReservationIdException() : base("Reservation Id is invalid")
        {

        }
    }
}
