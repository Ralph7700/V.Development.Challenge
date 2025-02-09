using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using VeerBackend.Contracts.Interfaces;

namespace VeerBackend.Services.AuthUser;

public class AuthUserService(IHttpContextAccessor contextAccessor):IAuthUserService
{
    public Guid? GetUserId()
    {
        var sub = contextAccessor?.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(sub, out var id) ? id : null;
    }
}