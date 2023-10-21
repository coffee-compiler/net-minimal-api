using UserManagement.Api.Application.Models;
using UserManagement.Api.Domain.Core.Interfaces;
using UserManagement.Api.Domain.Entities;

namespace UserManagement.Api.Application.Services;

internal sealed class UserService
    : IUserService
{
    private readonly IUnitOfWork _unitOfWork;

    public UserService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<UserDto?> CreateAsync(CreateUserDto user, CancellationToken cancellationToken = default)
    {
        var addedUser =
            _unitOfWork
                .UserRepository
                .Add(new User
                {
                    Firstname = user.Firstname,
                    Id = Guid.NewGuid(),
                    Lastname = user.Lastname,
                });

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return addedUser;
    }

    public async Task DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var user =
            await _unitOfWork
                .UserRepository
                .GetByIdAsync(id, cancellationToken);

        if (user is null)
        {
            return;
        }
        
        _unitOfWork.UserRepository.Remove(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserDto?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await _unitOfWork
            .UserRepository
            .GetByIdAsync(id, cancellationToken);

    public async Task<IEnumerable<UserDto?>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users =
            await _unitOfWork
                .UserRepository
                .GetAllAsync(cancellationToken);

        return users.Select(u => (UserDto?)u);
    }
}