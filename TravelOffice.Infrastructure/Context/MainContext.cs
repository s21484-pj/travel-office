using Microsoft.EntityFrameworkCore;
using TravelOffice.Infrastructure.Entities;

namespace TravelOffice.Infrastructure.Context;

public class MainContext : DbContext
{
    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<TouristAttraction> TouristAttractions { get; set; }
    public DbSet<Transport> Transports { get; set; }

    public MainContext()
    {
    }

    public MainContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=dbo.TravelOffice.db");
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<Hotel>()
    //         .HasOne(hotel => hotel.Offer)
    //         .WithOne(offer => offer.Hotel)
    //         .OnDelete(DeleteBehavior.Cascade);
    //
    //     modelBuilder.Entity<Transport>()
    //         .HasOne(transport => transport.Offer)
    //         .WithOne(offer => offer.Transport)
    //         .OnDelete(DeleteBehavior.Cascade);
    //     
    //     
    // }
}