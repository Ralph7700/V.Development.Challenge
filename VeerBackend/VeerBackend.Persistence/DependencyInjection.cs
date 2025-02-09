using VeerBackend.Persistence.Interceptors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeerBackend.Contracts.Interfaces;
using VeerBackend.Persistence.Repositories;

namespace VeerBackend.Persistence;

public static class DependencyInjection
{
    public static void AddPersistence(this IHostApplicationBuilder builder)
    {
        var connectionString = builder.Configuration.GetConnectionString("MainDbConnection") ??
                               throw new ArgumentNullException(nameof(builder.Configuration),
                                   "MainDbConnection not found");
        builder.Services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetRequiredService<ISaveChangesInterceptor>());
            options.UseNpgsql(connectionString);
        });
        builder.Services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        builder.Services.AddScoped<IUserRepository, UserRepository>();
    }
}