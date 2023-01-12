using Microsoft.AspNetCore.Mvc;
using PerficientCalendar.Data.Entities;
using PerficientCalendar.Business;

namespace PerficientCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class MeetingController : ControllerBase
{
    private readonly IOperationMeeting Operations;

    public MeetingController(IOperationMeeting operations)
    {
        Operations = operations;
    }

    /// <summary>
    /// Get Meeting Information By ID Meeting
    /// </summary>
    /// <param name="id">Guid Meeting</param>
    /// <returns>Meeting Information</returns>
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
    /// Get Meeting information By Name
    /// </summary>
    /// <param name="name">Meeting Name</param>
    /// <returns>Meeting Information</returns>
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
    /// Get The List Of all System Meetings
    /// </summary>
    /// <returns>Meeting Information</returns>
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
    /// Add New Meeting.
    /// </summary>
    /// <param name="meeting"></param>
    /// <returns>Meeting Information</returns>
    [HttpPost(Name = "Meeting")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(Meeting meeting)
    {
        var result = await Operations.AddMeeting(meeting);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Update The Meeting Information.
    /// </summary>
    /// <param name="meeting"></param>
    /// <returns>Meeting Information</returns>
    [HttpPut(Name = "Meeting")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Put(Meeting meeting)
    {
        var result = await Operations.UpdateMeeting(meeting);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Delete A Meeting
    /// </summary>
    /// <param name="id">Id Meeting</param>
    /// <returns>Meeting Information</returns>
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
