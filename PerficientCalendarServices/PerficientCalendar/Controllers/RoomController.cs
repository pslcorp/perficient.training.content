using Microsoft.AspNetCore.Mvc;
using PerficientCalendar.Model;
using PerficientCalendar.Business;

namespace PerficientCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomController : ControllerBase
{
    private readonly IOperationRoom Operations;
    public RoomController(IOperationRoom operations)
    {
        Operations = operations;
    }

    /// <summary>
    /// Get Room Information By ID Room
    /// </summary>
    /// <param name="id">Guid Room</param>
    /// <returns>Room Information</returns>
    [HttpGet]
    [Route("GetByID/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await Operations.GetByID(id);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get Room information By Name
    /// </summary>
    /// <param name="name">Room Name</param>
    /// <returns>Room Information</returns>
    [HttpGet]
    [Route("GetByName/{name}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Get(string name)
    {
        var result = await Operations.GetByName(name);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get The List Of all System Rooms
    /// </summary>
    /// <returns>Room Information</returns>
    [HttpGet]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Get()
    {
        var result = await Operations.GetAll();
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Add New Room.
    /// </summary>
    /// <param name="room"></param>
    /// <returns>Room Information</returns>
    [HttpPost(Name = "Room")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(Room room)
    {
        var result = await Operations.AddRoom(room);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Update The Room Information.
    /// </summary>
    /// <param name="room"></param>
    /// <returns>Room Information</returns>
    [HttpPut(Name = "Room")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Put(Room room)
    {
        var result = await Operations.UpdateRoom(room);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Delete A Room
    /// </summary>
    /// <param name="id">Id Room</param>
    /// <returns>Room Information</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await Operations.Delete(id);
        return StatusCode(result.StatusCode, result);
    }
}
