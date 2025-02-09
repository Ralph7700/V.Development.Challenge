using FluentValidation;

namespace VeerBackend.Application.Features.Auth.Queries.Login;

public class LoginRequestValidator:AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Email).NotEmpty()
            .EmailAddress()
            .WithMessage("invalid email");
        RuleFor(x => x.Password).NotEmpty();
    }
}