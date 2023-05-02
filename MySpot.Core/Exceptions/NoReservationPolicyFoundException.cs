

using MySpot.Core.ValueObjects;

namespace MySpot.Core.Exceptions
{
    public sealed class NoReservationPolicyFoundException : CustomException
    {
        public JobTitle JobTitle { get; set; }
        public NoReservationPolicyFoundException(JobTitle jobTitle) 
            : base ($"No Reservation policy for {jobTitle} has been found.") 
        {
            JobTitle= jobTitle;
        }
    }
}
