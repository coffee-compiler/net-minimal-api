using UserManagement.Api.Application.Models;

namespace UserManagement.Api.Application.Services;

internal interface IUserService
{
    Task<UserDto?> CreateAsync(CreateUserDto user, CancellationToken cancellationToken = default);

    Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    
    Task<UserDto?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<IEnumerable<UserDto?>> GetAllAsync(CancellationToken cancellationToken = default);
}