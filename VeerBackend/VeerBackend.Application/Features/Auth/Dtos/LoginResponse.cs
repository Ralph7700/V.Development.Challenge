namespace VeerBackend.Application.Features.Auth.Dtos;

public class LoginResponse
{
    public string? Token { get; set; }
    public DateTime Expiration { get; set; }
}