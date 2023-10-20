using UserManagement.Api.Application.Models;
using UserManagement.Api.Domain.Core.Interfaces;
using UserManagement.Api.Domain.Entities;
using UserManagement.Api.Domain.Repositories;

namespace UserManagement.Api.Application.Services;

internal sealed class UserService
    : IUserService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }
    
    public async Task<UserDto?> CreateAsync(CreateUserDto user, CancellationToken cancellationToken = default)
    {
        var addedUser = _userRepository.Add(new User
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
        var user = await _userRepository.GetByIdAsync(id, cancellationToken);

        if (user is null)
        {
            return;
        }
        
        _userRepository.Remove(user);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<UserDto?> GetAsync(Guid id, CancellationToken cancellationToken = default)
        => await _userRepository.GetByIdAsync(id, cancellationToken);

    public async Task<IEnumerable<UserDto?>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);

        return users.Select(u => (UserDto?)u);
    }
}