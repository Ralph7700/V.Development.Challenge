using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using VeerBackend.Contracts.Interfaces;
using VeerBackend.Domain.Entities;

namespace VeerBackend.Services.Jwt;

public class JwtService(IOptions<JwtSettings> settings) : IJwtService
{
    public (string Token, DateTime Expiration) GenerateJwtAccessToken(User user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(settings.Value.SecretKey!));
        var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Aud, settings.Value.Audience!),
            new Claim(JwtRegisteredClaimNames.Iss, settings.Value.Issuer!),
            new Claim(JwtRegisteredClaimNames.Email, user.Email!)
        };
        var expiration = DateTime.UtcNow.AddMinutes(settings.Value.AccessTokenExpirationInMinutes);
        var token = new JwtSecurityToken(
            settings.Value.Issuer,
            settings.Value.Audience!,
            claims,
            expires: expiration,
            signingCredentials: credential
        );

        return (new JwtSecurityTokenHandler().WriteToken(token), expiration);
    }
}