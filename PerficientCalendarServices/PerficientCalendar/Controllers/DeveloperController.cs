using System.Net;
using Microsoft.AspNetCore.Mvc;
using PerficientCalendar.Model;
using PerficientCalendar.Business;

namespace PerficientCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class DeveloperController : ControllerBase
{
    private readonly IOperationDeveloper Operations;
    public DeveloperController(IOperationDeveloper operations)
    {
        Operations = operations;
    }

    /// <summary>
    /// Get Developer Information By ID Developer
    /// </summary>
    /// <param name="id">Guid Developer</param>
    /// <returns>Developer Information</returns>
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
    /// Get Developer information By Name
    /// </summary>
    /// <param name="name">Developer Name</param>
    /// <returns>Developer Information</returns>
    [HttpGet]
    [Route("GetByName/{name}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Get(string name)
    {
        var result = await Operations.GetByName(name);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get List Of Developer information By Identifier
    /// </summary>
    /// <param name="identifier">Email Domain</param>
    /// <returns>Developer Information</returns>
    [HttpGet]
    [Route("GetByIdentifier/{identifier}")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> GetByIdentifier(string identifier)
    {
        var result = await Operations.GetByIdentifier(identifier);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Get The List Of all System Developers
    /// </summary>
    /// <returns>Developer Information</returns>
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
    /// Add New Developer.
    /// </summary>
    /// <param name="developer"></param>
    /// <returns>Developer Information</returns>
    [HttpPost(Name = "Developer")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(Developer developer)
    {
        var result = await Operations.AddDeveloper(developer);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Update The Developer Information.
    /// </summary>
    /// <param name="developer"></param>
    /// <returns>Developer Information</returns>
    [HttpPut(Name = "Developer")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Put(Developer developer)
    {
        var result = await Operations.UpdateDeveloper(developer);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Delete A Developer
    /// </summary>
    /// <param name="id">Id Developer</param>
    /// <returns>Developer Information</returns>
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
