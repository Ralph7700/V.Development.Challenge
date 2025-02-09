using System.Security.Cryptography;
using VeerBackend.Domain.Common;
using VeerBackend.Domain.Enums;

namespace VeerBackend.Domain.Entities;

public class User : AuditableEntityBase
{
    public string? Email { get; set; }
    public string? PasswordHash { get; set; }
    public string? PasswordSalt { get; set; }
    public string? UserName { get; set; }
    public Gender Gender { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool IsDeleted { get; set; }
}