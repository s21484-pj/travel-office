namespace TravelOffice.Infrastructure.Entities;

public class TouristAttraction : BaseEntity
{
    public string Name { get; set; }
    public double Price { get; set; }
    public string? Description { get; set; }
}