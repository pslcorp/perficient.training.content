using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Perficient.Training.JwtAuthentication.Service.Dtos;
using Perficient.Training.JwtAuthentication.Service.Models;

namespace Perficient.Training.JwtAuthentication.Service.Services.Interfaces
{
    public interface IUserService
    {
        Task<IReadOnlyCollection<User>> GetUsersAsync();
        Task<User> GetUserAsync(Guid id);
        Task<User> CreateUserAsync(UserDto user);
        Task DeleteUserAsync(Guid id);
        Task UpdateUserAsync(Guid id, UserDto user);
    }
}
