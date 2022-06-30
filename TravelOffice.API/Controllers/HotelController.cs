using Microsoft.AspNetCore.Mvc;
using TravelOffice.Infrastructure.Entities;
using TravelOffice.Infrastructure.Repository;

namespace TravelOffice.API.Controllers;

[ApiController]
[Route("hotel")]
public class HotelController : ControllerBase
{
    private readonly IHotelRepository _hotelRepository;

    public HotelController(IHotelRepository hotelRepository)
    {
        _hotelRepository = hotelRepository;
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _hotelRepository.GetAllAsync());
    }

    [HttpGet("get/{id:int}")]
    public async Task<IActionResult> GetHotelById(int id)
    {
        try
        {
            var hotel = await _hotelRepository.GetByIdAsync(id);
            return Ok(hotel);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddHotel([FromBody] Hotel hotel)
    {
        await _hotelRepository.AddAsync(hotel);
        return Ok(hotel);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateHotel([FromBody] Hotel hotel)
    {
        try
        {
            await _hotelRepository.UpdateAsync(hotel);
            return Ok(hotel);
        }
        catch (Exception)
        {
            return NotFound();
        }
    }

    [HttpDelete("delete/{id:int}")]
    public async Task<IActionResult> DeleteHotelById(int id)
    {
        try
        {
            await _hotelRepository.DeleteByIdAsync(id);
            return NoContent();
        }
        catch (Exception)
        {
            return NotFound();
        }
    }
}