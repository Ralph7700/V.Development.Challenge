using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VeerBackend.Domain.Entities;
using VeerBackend.Domain.Enums;

namespace VeerBackend.Persistence;

// this seeder checks and performs migrations automatically and creates a default user
public static class Seeder
{
    public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        context.Database.Migrate();

        if (!context.Users.Any())
        {
            // default user
            var user = new User()
            {
                UserName = "test-user",
                Email = "test@test.com",
                Id = Guid.NewGuid(),
                PasswordHash = "7enAdmJuiicJYkLvd2415LLxrORwGfw3LU9RdAUYKOs=",
                PasswordSalt = "YAC1q/fcA1P0DsX0ccc4wA==",
                Gender = Gender.Male,
                DateOfBirth = DateTime.Now.AddYears(-21)
            };

            var result = context.Users.Add(user);
            context.SaveChanges();
        }

        return app;
    }
}