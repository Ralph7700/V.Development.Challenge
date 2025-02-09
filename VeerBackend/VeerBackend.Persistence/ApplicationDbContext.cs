using System.Reflection;
using VeerBackend.Contracts.Interfaces;
using VeerBackend.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace VeerBackend.Persistence;

public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}