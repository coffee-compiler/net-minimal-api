using Microsoft.EntityFrameworkCore;
using UserManagement.Api.Domain.Entities;

namespace UserManagement.Api.Infrastructure.Data;

internal sealed class UserManagementContext
    : DbContext
{
    public UserManagementContext(DbContextOptions options)
        : base(options)
    {
    }
    
    public DbSet<User>? Users { get; set; }
}