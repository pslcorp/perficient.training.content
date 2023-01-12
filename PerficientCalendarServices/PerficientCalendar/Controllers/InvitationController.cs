using Microsoft.AspNetCore.Mvc;
using PerficientCalendar.Model;
using PerficientCalendar.Business;

namespace PerficientCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class InvitationController : ControllerBase
{
    private readonly IOperationInvitation Operations;

    public InvitationController(IOperationInvitation operations)
    {
        Operations = operations;
    }

    /// <summary>
    /// Get Invitation By ID Invitation
    /// </summary>
    /// <param name="id">Guid Invitation</param>
    /// <returns>Invitation Information</returns>
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
    /// Get Invitation By ID Developer
    /// </summary>
    /// <param name="idDeveloper">Id Developer</param>
    /// <returns>Invitation Information</returns>
    [HttpGet]
    [Route("GetByIDDeveloper/{idDeveloper}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetByIDDeveloper(Guid idDeveloper)
    {
        var result = await Operations.GetByIDDeveloper(idDeveloper);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get Invitation By ID Meeting
    /// </summary>
    /// <param name="idMeeting"></param>
    /// <returns>Invitation Information</returns>
    [HttpGet]
    [Route("GetByIDMeeting/{idMeeting}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetByIDMeeting(Guid idMeeting)
    {
        var result = await Operations.GetByIDMeeting(idMeeting);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get The List Of all System Invitations
    /// </summary>
    /// <returns>Intiation Information</returns>
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
    /// Add New Invitation.
    /// </summary>
    /// <param name="invitation"></param>
    /// <returns>Invitation Information</returns>
    [HttpPost(Name = "Invitation")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(Invitation invitation)
    {
        var result = await Operations.AddInvitation(invitation);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Update New Invitation.
    /// </summary>
    /// <param name="invitation"></param>
    /// <returns>Invitation Information</returns>
    [HttpPut(Name = "Invitation")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Put(Invitation invitation)
    {
        var result = await Operations.UpdateInvitation(invitation);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Delete A Invitation
    /// </summary>
    /// <param name="id">Id Invitation</param>
    /// <returns>Invitation Information</returns>
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
