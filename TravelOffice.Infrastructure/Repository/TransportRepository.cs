using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TravelOffice.Infrastructure.Context;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Exception;

namespace TravelOffice.Infrastructure.Repository;

public class TransportRepository : ITransportRepository
{
    private readonly MainContext _mainContext;
    private readonly ILogger<ITransportRepository> _logger;

    public TransportRepository(MainContext mainContext, ILogger<TransportRepository> logger)
    {
        _mainContext = mainContext;
        _logger = logger;
    }

    public async Task<IEnumerable<Transport>> GetAllAsync()
    {
        var transports = await _mainContext.Transports.ToListAsync();
        return transports;
    }

    public async Task<Transport> GetByIdAsync(int id)
    {
        var transport = await _mainContext.Transports.SingleOrDefaultAsync(transport1 => transport1.Id == id);

        if (transport != null)
        {
            return transport;
        }

        _logger.LogError("Cant find transport for given id: {TransportId}", id);
        throw new TransportNotFoundException("No transport for given id");
    }

    public async Task AddAsync(Transport entity)
    {
        await _mainContext.AddAsync(entity);
        await _mainContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(Transport entity)
    {
        var transport = await _mainContext.Transports.SingleOrDefaultAsync(transport1 => transport1.Id == entity.Id);

        if (transport == null)
        {
            _logger.LogError("Cant find transport for given id: {TransportId}", entity.Id);
            throw new TransportNotFoundException("No transport for given id");
        }

        transport.TransportType = entity.TransportType;
        await _mainContext.SaveChangesAsync();
    }

    public async Task DeleteByIdAsync(int id)
    {
        var transport = await _mainContext.Transports.SingleOrDefaultAsync(transport1 => transport1.Id == id);

        if (transport != null)
        {
            _mainContext.Transports.Remove(transport);
            await _mainContext.SaveChangesAsync();
        }
        else
        {
            _logger.LogError("Cant find transport for given id: {TransportId}", id);
            throw new TransportNotFoundException("No transport for given id");
        }
    }
}