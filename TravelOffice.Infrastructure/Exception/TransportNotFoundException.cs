namespace TravelOffice.Infrastructure.Exception;

public class TransportNotFoundException : System.Exception
{
    public TransportNotFoundException(string? message) : base(message)
    {
    }
}