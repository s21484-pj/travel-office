using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelOffice.Infrastructure.Context;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Exception;

namespace TravelOffice.Infrastructure.Repository;

public class OfferRepository : IOfferRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<IOfferRepository> _logger;

    public OfferRepository(MainContext mainContext, ILogger<OfferRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Offer>> GetAllAsync()
    {
        var offers = await _mainContext.Offers.ToListAsync();

        foreach (var offer in offers)
        {
            var hotel = await _mainContext.Hotels
                .SingleOrDefaultAsync(hotel1 => hotel1.Id == offer.HotelId);
            var transport = await _mainContext.Transports
                .SingleOrDefaultAsync(transport1 => transport1.Id == offer.TransportId);
            var attraction = await _mainContext.TouristAttractions
                .SingleOrDefaultAsync(touristAttraction => touristAttraction.Id == offer.AttractionId);
            offer.Hotel = hotel;
            offer.Transport = transport;
            offer.TouristAttraction = attraction;
        }
        
        return offers;
    }

    public async Task<Offer> GetByIdAsync(int id)
    {
        var offer = await _mainContext.Offers
            .SingleOrDefaultAsync(offer1 => offer1.Id == id);
        
        if (offer != null)
        {
            var hotel = await _mainContext.Hotels
                .SingleOrDefaultAsync(hotel1 => hotel1.Id == offer.HotelId);
            var transport = await _mainContext.Transports
                .SingleOrDefaultAsync(transport1 => transport1.Id == offer.TransportId);
            var attraction = await _mainContext.TouristAttractions
                .SingleOrDefaultAsync(touristAttraction => touristAttraction.Id == offer.AttractionId);
            offer.Hotel = hotel;
            offer.Transport = transport;
            offer.TouristAttraction = attraction;
            return offer;
        }
        
        _logger.LogError("Cant find offer for given id: {OfferId}", id);
        throw new OfferNotFoundException("No offer for given id.");
    }

    public async Task AddAsync(Offer entity)
    {
        var hotel = await _mainContext.Hotels
            .SingleOrDefaultAsync(hotel1 => hotel1.Id == entity.HotelId);
        var transport = await _mainContext.Transports
            .SingleOrDefaultAsync(transport1 => transport1.Id == entity.TransportId);
        var attraction = await _mainContext.TouristAttractions
            .SingleOrDefaultAsync(touristAttraction => touristAttraction.Id == entity.AttractionId);

        if (hotel != null)
        {
            entity.Hotel = hotel;
        }
        else
        {
            throw new HotelNotFoundException("No hotel for given id");
        }

        if (transport != null)
        {
            entity.Transport = transport;
        }
        else
        {
            throw new TransportNotFoundException("No transport for given id");
        }

        if (attraction != null)
        {
            entity.TouristAttraction = attraction;
        }
        else
        {
            throw new TouristAttractionNotFoundException("No attraction for given id");
        }
        
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Offer entity)
    {
        var offer = await _mainContext.Offers.SingleOrDefaultAsync(offer1 => offer1.Id == entity.Id);

        if (offer == null)
        {
            _logger.LogError("Cant find offer for given id: {OfferId}", entity.Id);
            throw new OfferNotFoundException("No offer for given id.");
        }

        offer.Name = entity.Name;
        offer.Location = entity.Location;
        offer.TermFrom = entity.TermFrom;
        offer.TermTo = entity.TermTo;
        offer.Price = entity.Price;
        offer.HotelId = entity.HotelId;
        offer.TransportId = entity.TransportId;
        
        var hotel = await _mainContext.Hotels
            .SingleOrDefaultAsync(hotel1 => hotel1.Id == entity.HotelId);
        var transport = await _mainContext.Transports
            .SingleOrDefaultAsync(transport1 => transport1.Id == entity.TransportId);
        var attraction = await _mainContext.TouristAttractions
            .SingleOrDefaultAsync(touristAttraction => touristAttraction.Id == entity.AttractionId);

        if (hotel != null)
        {
            entity.Hotel = hotel;
        }
        else
        {
            throw new HotelNotFoundException("No hotel for given id");
        }

        if (transport != null)
        {
            entity.Transport = transport;
        }
        else
        {
            throw new TransportNotFoundException("No transport for given id");
        }
        
        if (attraction != null)
        {
            entity.TouristAttraction = attraction;
        }
        else
        {
            throw new TouristAttractionNotFoundException("No attraction for given id");
        }

        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var offer = await _mainContext.Offers.SingleOrDefaultAsync(offer1 => offer1.Id == id);

        if (offer != null)
        {
            _mainContext.Offers.Remove(offer);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogError("Cant find offer for given id: {OfferId}", id);
            throw new OfferNotFoundException("No offer for given id.");
        }
    }
}