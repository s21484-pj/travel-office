using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelOffice.Infrastructure.Context;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Exception;

namespace TravelOffice.Infrastructure.Repository;

public class HotelRepository : IHotelRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<IHotelRepository> _logger;

    public HotelRepository(MainContext mainContext, ILogger<HotelRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Hotel>> GetAllAsync()
    {
        var hotel = await _mainContext.Hotels.ToListAsync();
        return hotel;
    }

    public async Task<Hotel> GetByIdAsync(int id)
    {
        var hotel = await _mainContext.Hotels.SingleOrDefaultAsync(hotel1 => hotel1.Id == id);
        if (hotel != null)
        {
            return hotel;
        }
        
        _logger.LogError("Cant find hotel for given id: {HotelId}", id);
        throw new HotelNotFoundException("No hotel for given id");
    }

    public async Task AddAsync(Hotel entity)
    {
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Hotel entity)
    {
        var hotel = await _mainContext.Hotels.SingleOrDefaultAsync(hotel1 => hotel1.Id == entity.Id);

        if (hotel == null)
        {
            _logger.LogError("Cant find hotel for given id: {HotelId}", entity.Id);
            throw new HotelNotFoundException("No hotel for given id");
        }

        hotel.Name = entity.Name;
        hotel.Address = entity.Address;
        hotel.Stars = entity.Stars;
        hotel.Description = entity.Description;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var hotel = await _mainContext.Hotels.SingleOrDefaultAsync(hotel1 => hotel1.Id == id);

        if (hotel != null)
        {
            _mainContext.Hotels.Remove(hotel);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogError("Cant find hotel for given id: {HotelId}", id);
            throw new HotelNotFoundException("No hotel for given id");
        }
    }
}