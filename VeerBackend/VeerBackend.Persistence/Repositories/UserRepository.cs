using Microsoft.EntityFrameworkCore;
using VeerBackend.Contracts.Interfaces;
using VeerBackend.Domain.Entities;

namespace VeerBackend.Persistence.Repositories;

public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
{
    public async Task<User?> GetUserById(Guid id)
    {
        return await dbContext.Users.FindAsync(id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await dbContext.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<Guid> CreateUser(User user)
    {
        var result = await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
        return result.Entity.Id;
    }

    public async Task<bool> EmailExists(string email)
    {
        return await dbContext.Users.AnyAsync(u => u.Email == email);
    }
}