using MediatR;
using VeerBackend.Application.Common.Helpers;
using VeerBackend.Application.Common.Models;
using VeerBackend.Application.Features.Auth.Dtos;
using VeerBackend.Contracts.Interfaces;

namespace VeerBackend.Application.Features.Auth.Queries.Login;

public class LoginRequest: IRequest<Result<LoginResponse>>
{
    public string? Email { get; init; }
    public string? Password { get; init; }
}

public class LoginRequestHandler(
    IUserRepository userRepository,
    IJwtService jwtService
    ) : IRequestHandler<LoginRequest, Result<LoginResponse>>
{
    public async Task<Result<LoginResponse>> Handle(LoginRequest request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetUserByEmail(request.Email!);
        if (user == null || !PasswordHasher.VerifyPassword(request.Password!, user.PasswordHash!, user.PasswordSalt!))
            return Result<LoginResponse>.BadRequest("InvalidEmailOrPassword", "Invalid email or password");
        
        var tokenData = jwtService.GenerateJwtAccessToken(user);
        
        var result = new LoginResponse()
        {
            Token = tokenData.Token,
            Expiration = tokenData.Expiration,
        };
        return Result<LoginResponse>.Success(result);
    }
}