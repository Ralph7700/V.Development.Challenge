using MediatR;
using VeerBackend.Application.Common.Helpers;
using VeerBackend.Application.Common.Models;
using VeerBackend.Contracts.Interfaces;
using VeerBackend.Domain.Entities;
using VeerBackend.Domain.Enums;

namespace VeerBackend.Application.Features.Auth.Commands.Signup;

public class SignupRequest: IRequest<Result<Guid>>
{
    public string? Email { get; init; }
    public string? UserName { get; init; }
    public DateTime? DateOfBirth { get; init; }
    public string? Password { get; init; }
    public Gender? Gender { get; init; }
}

public class SignupRequestHandler(IUserRepository userRepository) : IRequestHandler<SignupRequest, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(SignupRequest request, CancellationToken cancellationToken)
    {
        if (await userRepository.EmailExists(request.Email!))
            return Result<Guid>.Conflict("EmailExists", "This email already exists");
        
        var password = PasswordHasher.HashPassword(request.Password!);
        var newUser = new User()
        {
            Email = request.Email!.ToLower(),
            DateOfBirth = request.DateOfBirth!.Value,
            UserName = request.UserName,
            Gender = request.Gender!.Value,
            PasswordHash = password.Hash,
            PasswordSalt = password.Salt
        };

        var result = await userRepository.CreateUser(newUser);
        return Result<Guid>.Success(result);
    }
}