namespace VeerBackend.Services.Jwt;

public class JwtSettings
{
    public const string SectionName = "Jwt";
    public string? SecretKey { get; set; }
    public string? Issuer { get; set; }
    public string? Audience { get; set; }
    public int AccessTokenExpirationInMinutes { get; set; } = 60;
}