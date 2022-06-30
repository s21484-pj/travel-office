namespace TravelOffice.Infrastructure.Entities;

public class Offer : BaseEntity
{
    public string Name { get; set; }
    public string Location { get; set; }
    public DateTime TermFrom { get; set; }
    public DateTime TermTo { get; set; }
    public double Price { get; set; }

    public int HotelId { get; set; }
    public Hotel? Hotel { get; set; }
    
    public int TransportId { get; set; }
    public Transport? Transport { get; set; }

    public int AttractionId { get; set; }
    public TouristAttraction? TouristAttraction { get; set; }
}