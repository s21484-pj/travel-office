using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelOffice.Infrastructure.Context;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Exception;

namespace TravelOffice.Infrastructure.Repository;

public class TouristAttractionRepository : ITouristAttractionRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<ITouristAttractionRepository> _logger;

    public TouristAttractionRepository(MainContext mainContext, ILogger<TouristAttractionRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<TouristAttraction>> GetAllAsync()
    {
        var touristAttractions = await _mainContext.TouristAttractions.ToListAsync();
        return touristAttractions;
    }

    public async Task<TouristAttraction> GetByIdAsync(int id)
    {
        var touristAttraction = await _mainContext.TouristAttractions.SingleOrDefaultAsync(attraction => attraction.Id == id);

        if (touristAttraction != null)
        {
            return touristAttraction;
        }

        _logger.LogError("Cant find attraction for given id: {TouristAttractionId}", id);
        throw new TouristAttractionNotFoundException("No attraction for given id");
    }

    public async Task AddAsync(TouristAttraction entity)
    {
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(TouristAttraction entity)
    {
        var touristAttraction = await _mainContext.TouristAttractions.SingleOrDefaultAsync(attraction => attraction.Id == entity.Id);

        if (touristAttraction == null)
        {
            _logger.LogError("Cant find attraction for given id: {TouristAttractionId}", entity.Id);
            throw new TouristAttractionNotFoundException("No attraction for given id");
        }

        touristAttraction.Name = entity.Name;
        touristAttraction.Price = entity.Price;
        touristAttraction.Description = entity.Description;

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var touristAttraction = await _mainContext.TouristAttractions.SingleOrDefaultAsync(attraction => attraction.Id == id);

        if (touristAttraction != null)
        {
            _mainContext.TouristAttractions.Remove(touristAttraction);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogError("Cant find attraction for given id: {TouristAttractionId}", id);
            throw new TouristAttractionNotFoundException("No attraction for given id");
        }
    }
}