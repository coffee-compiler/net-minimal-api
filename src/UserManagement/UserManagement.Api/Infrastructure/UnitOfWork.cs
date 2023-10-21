using UserManagement.Api.Domain.Core.Interfaces;
using UserManagement.Api.Domain.Repositories;
using UserManagement.Api.Infrastructure.Data;

namespace UserManagement.Api.Infrastructure;

internal sealed class UnitOfWork
    : IUnitOfWork
{
    private readonly UserManagementContext _dbContext;

    public UnitOfWork(
        UserManagementContext context,
        IUserRepository userRepository)
    {
        _dbContext = context;
        UserRepository = userRepository;
    }
    
    public IUserRepository UserRepository { get; }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        => await _dbContext.SaveChangesAsync(cancellationToken);
}