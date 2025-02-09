using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VeerBackend.Contracts.Interfaces;
using VeerBackend.Services.AuthUser;
using VeerBackend.Services.Jwt;

namespace VeerBackend.Services;

public static class DependencyInjection
{
    public static void AddServices(this IHostApplicationBuilder builder)
    {
        // get and validate jwt settings from appsettings 
        builder.Services.AddOptions<JwtSettings>()
            .Bind(builder.Configuration.GetSection(JwtSettings.SectionName))
            .ValidateOnStart();

        // this is set as a singleton because it behaves in the same way for every request
        builder.Services.AddSingleton<IJwtService,JwtService>();

        builder.Services.AddScoped<IAuthUserService, AuthUserService>();
    }
}