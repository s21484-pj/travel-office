namespace TravelOffice.Infrastructure.Entities;

public class Hotel : BaseEntity
{
    public string Name { get; set; }
    public string Address { get; set; }
    public float Stars { get; set; }
    public string? Description { get; set; }
}