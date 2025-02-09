using VeerBackend.Domain.Entities;
using VeerBackend.Domain.Enums;

namespace VeerBackend.Application.Features.Auth.Dtos;

public class ReadUserDto
{
    public Guid Id { get; set; }
    public string? Email { get; set; }
    public string? UserName { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    
    public ReadUserDto(User user)
    {
        Id = user.Id;
        Email = user.Email;
        UserName = user.UserName;
        Gender = user.Gender;
        DateOfBirth = user.DateOfBirth;
    }
}