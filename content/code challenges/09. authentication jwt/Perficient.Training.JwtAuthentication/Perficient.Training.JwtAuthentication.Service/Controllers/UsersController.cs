using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Perficient.Training.JwtAuthentication.Service.Dtos;
using Perficient.Training.JwtAuthentication.Service.Models;
using Perficient.Training.JwtAuthentication.Service.Services.Interfaces;

namespace Perficient.Training.JwtAuthentication.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IReadOnlyCollection<User>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUsersAsync()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id:Guid}")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUserAsync([FromRoute] Guid id)
        {
            var user = await _userService.GetUserAsync(id);
            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto user)
        {
            var userCreated = await _userService.CreateUserAsync(user);
            return Created($"/users/{userCreated.Id}", userCreated);
        }

        [HttpPut("{id:Guid}")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateUserAsync([FromRoute] Guid id, [FromBody] UserDto user)
        {
            await _userService.UpdateUserAsync(id, user);
            return Ok(user);
        }

        [HttpDelete("{id:Guid}")]
        [ProducesResponseType(typeof(User), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserAsync([FromRoute] Guid id)
        {
            await _userService.DeleteUserAsync(id);
            return Ok();
        }
    }
}
