using VeerBackend.Domain.Entities;

namespace VeerBackend.Domain.Events;

public record CreateUserEvent(User UserData);
