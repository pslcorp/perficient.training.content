using Microsoft.AspNetCore.Mvc;
using PerficientCalendar.Model;
using PerficientCalendar.Business;

namespace PerficientCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class TypeEventController : ControllerBase
{
    private readonly IOperationsTypeEvent Operations;

    public TypeEventController(IOperationsTypeEvent operations)
    {
        Operations = operations;
    }

    /// <summary>
    /// Get Type Event Information By ID Developer
    /// </summary>
    /// <param name="id">Guid Type Event</param>
    /// <returns>Type Event Information</returns>
    [HttpGet]
    [Route("GetByID/{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Get(int id)
    {
        var result = await Operations.GetByID(id);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get Type Event information By Name
    /// </summary>
    /// <param name="name">Type Event Name</param>
    /// <returns>Type Event Information</returns>
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
    /// Get The List Of all System Type Events
    /// </summary>
    /// <returns>Type Event Information</returns>
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
    /// Add New Type Event.
    /// </summary>
    /// <param name="typeEvent"></param>
    /// <returns>Type Event Information</returns>
    [HttpPost(Name = "TypeEvent")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(TypeEvent typeEvent)
    {
        var result = await Operations.AddTypeEvent(typeEvent);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Update The Developer Type Event.
    /// </summary>
    /// <param name="typeEvent"></param>
    /// <returns>Type Event Information</returns>
    [HttpPut(Name = "TypeEvent")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Put(TypeEvent typeEvent)
    {
        var result = await Operations.UpdateTypeEvent(typeEvent);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Delete A Type Event
    /// </summary>
    /// <param name="id">Id Type Event</param>
    /// <returns>Type Event Information</returns>
    [HttpDelete("{id}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await Operations.Delete(id);
        return StatusCode(result.StatusCode, result);
    }
}
