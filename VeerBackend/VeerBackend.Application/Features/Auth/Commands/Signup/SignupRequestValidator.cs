using FluentValidation;

namespace VeerBackend.Application.Features.Auth.Commands.Signup;

public class SignupRequestValidator:AbstractValidator<SignupRequest>
{
    public SignupRequestValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Email must be a valid email address.");
        
        RuleFor(p => p.DateOfBirth)
            .Must(p =>
            {
                if(p != null)
                    return p.Value.Year < DateTime.Now.Year - 18;
                return false;
            }).WithMessage("User must be at least 18 years old.");

        RuleFor(p => p.UserName)
            .NotEmpty().WithMessage("Username is required")
            .Matches(@"^[a-zA-Z0-9_-]{3,20}$").WithMessage("Username must be 3-20 characters and can only contain letters, numbers, underscores and hyphens");
        
        RuleFor(p => p.Password).NotEmpty().WithMessage("Password is required")
            .Must(IsValidPassword).WithMessage("Password must contain at least 8 characters, one upper case, one lower case and one digit");
    }

    private bool IsValidPassword(string? password)
    {
        return !string.IsNullOrWhiteSpace(password)
               && password.Length >= 8
               && password.Any(char.IsUpper)
               && password.Any(char.IsLower)
               && password.Any(char.IsDigit);
    }
}