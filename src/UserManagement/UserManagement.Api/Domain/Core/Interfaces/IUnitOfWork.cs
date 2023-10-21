using UserManagement.Api.Domain.Repositories;

namespace UserManagement.Api.Domain.Core.Interfaces;

internal interface IUnitOfWork
{
    IUserRepository UserRepository { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}