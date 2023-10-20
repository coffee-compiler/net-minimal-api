using UserManagement.Api.Domain.Entities;

namespace UserManagement.Api.Application.Models;

internal sealed record UserDto
{
    public string Firstname { get; init; } = string.Empty;
    
    public Guid Id { get; init; }

    public string Lastname { get; init; } = string.Empty;

    public static implicit operator UserDto?(User? user)
        => user is null
            ? null
            : new UserDto
            {
                Firstname = user.Firstname,
                Id = user.Id,
                Lastname = user.Lastname,
            };
}