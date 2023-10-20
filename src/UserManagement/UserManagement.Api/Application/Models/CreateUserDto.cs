namespace UserManagement.Api.Application.Models;

internal sealed record CreateUserDto
{
    public string Firstname { get; init; } = string.Empty;

    public string Lastname { get; init; } = string.Empty;
}