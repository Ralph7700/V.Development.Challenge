using VeerBackend.Domain.Entities;

namespace VeerBackend.Contracts.Interfaces;

public interface IJwtService
{
    (string Token, DateTime Expiration) GenerateJwtAccessToken(User user);
}