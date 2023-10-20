using UserManagement.Api.Domain.Core.Interfaces;
using UserManagement.Api.Domain.Entities;

namespace UserManagement.Api.Domain.Repositories;

internal interface IUserRepository
    : IGenericRepository<User>
{
}