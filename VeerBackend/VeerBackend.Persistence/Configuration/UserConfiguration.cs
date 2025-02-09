using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VeerBackend.Domain.Entities;

namespace VeerBackend.Persistence.Configuration;

/// <summary>
/// Here we can configure the database properties as we see fit
/// </summary>
public class UserConfiguration: IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(e => e.Id);
        builder.HasIndex(e => e.Email).IsUnique();
        
        // with this query filter we can have soft delete options
        // entities will act as if they are not in the database but will remain there to avoid database conflict
        builder.HasQueryFilter(e => !e.IsDeleted);

        builder.Property(e => e.PasswordHash).IsRequired().HasMaxLength(100);
        builder.Property(e => e.PasswordSalt).IsRequired().HasMaxLength(100);
        builder.Property(e => e.UserName).IsRequired().HasMaxLength(30);
        builder.Property(e => e.DateOfBirth).HasColumnType("date");
    }
}