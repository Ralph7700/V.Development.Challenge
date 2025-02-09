using VeerBackend.Domain.Entities;

namespace VeerBackend.Contracts.Interfaces;

public interface IUserRepository
{
    Task<User?> GetUserById(Guid id);
    Task<User?> GetUserByEmail(string email);
    Task<Guid> CreateUser(User user);
    Task<bool> EmailExists(string email);
} 