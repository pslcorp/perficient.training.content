using Microsoft.AspNetCore.Mvc;
using PerficientCalendar.Model;
using PerficientCalendar.Business;

namespace PerficientCalendar.Controllers;

[ApiController]
[Route("[controller]")]
public class OfficeController : ControllerBase
{
    private readonly IOperationsOffice Operations;
    public OfficeController(IOperationsOffice operations)
    {
        Operations = operations;
    }

    /// <summary>
    /// Get Office Information By ID Office
    /// </summary>
    /// <param name="id">Guid Office</param>
    /// <returns>Office Information</returns>
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
    /// Get Office information By Name
    /// </summary>
    /// <param name="name">Office Name</param>
    /// <returns>Office Information</returns>
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
    /// Get The List Of all System Offices
    /// </summary>
    /// <returns>Office Information</returns>
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
    /// Add New Office.
    /// </summary>
    /// <param name="office"></param>
    /// <returns>Office Information</returns>
    [HttpPost(Name = "Office")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Post(Office office)
    {
        var result = await Operations.AddOffice(office);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Update The Office Information.
    /// </summary>
    /// <param name="office"></param>
    /// <returns>Office Information</returns>
    [HttpPut(Name = "Office")]
    [ProducesResponseType(200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(404)]
    [ProducesResponseType(500)]
    public async Task<IActionResult> Put(Office office)
    {
        var result = await Operations.UpdateOffice(office);
        return StatusCode(result.StatusCode, result);
    }

    /// <summary>
    /// Delete A Office
    /// </summary>
    /// <param name="id">Id Office</param>
    /// <returns>Office Information</returns>
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
