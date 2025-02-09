namespace VeerBackend.Domain.Common;

// this class ensures that all our main entities have the necessary properties to keep track of their changes
public abstract class AuditableEntityBase
{
    public Guid Id { get; set; }
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset LastModified { get; set; }
}