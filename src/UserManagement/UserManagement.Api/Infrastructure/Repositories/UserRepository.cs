using UserManagement.Api.Domain.Entities;
using UserManagement.Api.Domain.Repositories;
using UserManagement.Api.Infrastructure.Data;

namespace UserManagement.Api.Infrastructure.Repositories;

internal sealed class UserRepository
    : GenericRepository<User>, IUserRepository
{
    public UserRepository(UserManagementContext context)
        : base(context)
    {
    }
}