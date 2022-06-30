using Microsoft.AspNetCore.Mvc;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Repository;

namespace TravelOffice.API.Controllers;

[ApiController]
[Route("attraction")]
public class TouristAttractionController : ControllerBase
{
    private readonly ITouristAttractionRepository _attraction;

    public TouristAttractionController(ITouristAttractionRepository attraction)
    {
        _attraction = attraction;
    }
    
    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _attraction.GetAllAsync());
    }
    
    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetTouristAttractionById(int id)
    {
        try
        {
            var attraction = await _attraction.GetByIdAsync(id);
            return Ok(attraction);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> AddTouristAttraction([FromBody] TouristAttraction attraction)
    {
        await _attraction.AddAsync(attraction);
        return Ok(attraction);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> UpdateTouristAttraction([FromBody] TouristAttraction attraction)
    {
        try
        {
            await _attraction.UpdateAsync(attraction);
            return Ok(attraction);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
    
    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteTouristAttractionById(int id)
    {
        try
        {
            await _attraction.DeleteByIdAsync(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}