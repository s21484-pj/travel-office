namespace TravelOffice.Infrastructure.Exception;

public class TouristAttractionNotFoundException : System.Exception
{
    public TouristAttractionNotFoundException(string? message) : base(message)
    {
    }
}