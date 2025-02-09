namespace VeerBackend.Application.Common.Models;

public record ErrorDetail(
    ErrorType Type,
    string Code,
    string Message,
    Dictionary<string, string[]>? ValidationErrors = null
);

public enum ErrorType
{
    Validation,
    NotFound,
    Conflict,
    Forbidden,
    BadRequest,
    InternalServerError,
    Unauthorized
}