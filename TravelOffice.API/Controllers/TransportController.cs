using Microsoft.AspNetCore.Mvc;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Repository;

namespace TravelOffice.API.Controllers;

[ApiController]
[Route("transport")]
public class TransportController : ControllerBase
{
    private readonly ITransportRepository _transportRepository;

    public TransportController(ITransportRepository transportRepository)
    {
        _transportRepository = transportRepository;
    }
    
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _transportRepository.GetAllAsync());
    }
    
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetTransportById(int id)
    {
        try
        {
            var transport = await _transportRepository.GetByIdAsync(id);
            return Ok(transport);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddTransport([FromBody] Transport transport)
    {
        await _transportRepository.AddAsync(transport);
        return Ok(transport);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateTransport([FromBody] Transport transport)
    {
        try
        {
            await _transportRepository.UpdateAsync(transport);
            return Ok(transport);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteTransportById(int id)
    {
        try
        {
            await _transportRepository.DeleteByIdAsync(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}