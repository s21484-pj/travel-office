namespace TravelOffice.Infrastructure.Exception;

public class HotelNotFoundException : System.Exception
{
    public HotelNotFoundException(string? message) : base(message)
    {
    }
}