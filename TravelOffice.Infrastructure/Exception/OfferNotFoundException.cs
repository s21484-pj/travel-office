namespace TravelOffice.Infrastructure.Exception;

public class OfferNotFoundException : System.Exception
{
    public OfferNotFoundException(string? message) : base(message)
    {
    }
}