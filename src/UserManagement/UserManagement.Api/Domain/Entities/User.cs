namespace UserManagement.Api.Domain.Entities;

internal sealed record User
{
    public Guid Id { get; init; }
    
    public string Firstname { get; init; } = string.Empty;

    public string Lastname { get; init; } = string.Empty;
}