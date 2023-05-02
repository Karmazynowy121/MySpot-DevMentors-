namespace MySpot.Core.Exceptions
{
    public sealed class InvalidLicensePlateException : CustomException
    {
        public string LicensePlate { get; }
        public InvalidLicensePlateException(string LicensePlate)
            : base($"License plate: {LicensePlate} is invalid")
        {
            LicensePlate = LicensePlate;
        }
    }

}
