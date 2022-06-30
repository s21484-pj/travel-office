using Microsoft.AspNetCore.Mvc;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Repository;

namespace TravelOffice.API.Controllers;

[ApiController]
[Route("offer")]
public class OfferController : ControllerBase
{
    private readonly IOfferRepository _offerRepository;

    public OfferController(IOfferRepository offerRepository)
    {
        _offerRepository = offerRepository;
    }
    
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _offerRepository.GetAllAsync());
    }
    
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetOfferById(int id)
    {
        try
        {
            var offer = await _offerRepository.GetByIdAsync(id);
            return Ok(offer);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddOffer([FromBody] Offer offer)
    {
        await _offerRepository.AddAsync(offer);
        return Ok(offer);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateOffer([FromBody] Offer offer)
    {
        try
        {
            await _offerRepository.UpdateAsync(offer);
            return Ok(offer);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteOfferById(int id)
    {
        try
        {
            await _offerRepository.DeleteByIdAsync(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}