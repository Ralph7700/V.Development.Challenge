using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace VeerBackend.Application.Common.Models;
/// <summary>
/// The validation pattern allows us to avoid using exceptions for flow control for a better performance and cleaner readability 
/// </summary>
public class Result
{
    protected Result(bool isSuccess, ErrorDetail? error = null)
    {
        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public ErrorDetail? Error { get; }

    // Factory methods for non-generic Result
    public static Result Success()
    {
        return new Result(true);
    }

    public static Result Failure(ErrorDetail error)
    {
        return new Result(false, error);
    }

    public static Result ValidationError(Dictionary<string, string[]> validationErrors)
    {
        return Failure(new ErrorDetail(
            ErrorType.Validation,
            "ValidationError",
            "One or more validation errors occurred.",
            validationErrors
        ));
    }

    public static Result NotFound(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.NotFound, code, message));
    }

    public static Result Conflict(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.Conflict, code, message));
    }

    public static Result Unauthorized(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.Unauthorized, code, message));
    }

    public static Result BadRequest(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.BadRequest, code, message));
    }

    // Standardizing Error Http response to avoid repetition
    public IResult ToIResult()
    {
        return IsSuccess
            ? Results.NoContent()
            : Error!.Type switch
            {
                ErrorType.Validation => Results.ValidationProblem(Error.ValidationErrors ??
                                                                  new Dictionary<string, string[]>()),
                ErrorType.Unauthorized => Results.Unauthorized(),
                ErrorType.NotFound => Results.NotFound(new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = Error.Message,
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
                }),
                ErrorType.Conflict => Results.Conflict(new ProblemDetails
                {
                    Title = "Conflict",
                    Detail = Error.Message,
                    Status = StatusCodes.Status409Conflict,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8"
                }),
                ErrorType.InternalServerError => Results.Problem(new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = Error.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                }),
                _ => Results.Problem(new ProblemDetails
                {
                    Title = "An error occurred",
                    Detail = Error.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                })
            };
    }
}

public class Result<T> : Result
{
    private Result(bool isSuccess, T? value = default, ErrorDetail? error = null)
        : base(isSuccess, error)
    {
        Value = value;
    }

    public T? Value { get; }

    public static Result<T> Success(T value)
    {
        return new Result<T>(true, value);
    }

    public new static Result<T> Failure(ErrorDetail error)
    {
        return new Result<T>(false, default, error);
    }

    public new static Result<T> ValidationError(Dictionary<string, string[]> validationErrors)
    {
        return Failure(new ErrorDetail(
            ErrorType.Validation,
            "ValidationError",
            "One or more validation errors occurred.",
            validationErrors
        ));
    }

    public new static Result<T> NotFound(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.NotFound, code, message));
    }

    public new static Result<T> Conflict(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.Conflict, code, message));
    }

    public new static Result<T> Unauthorized(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.Unauthorized, code, message));
    }

    public new static Result<T> BadRequest(string code, string message)
    {
        return Failure(new ErrorDetail(ErrorType.BadRequest, code, message));
    }

    public new IResult ToIResult()
    {
        return IsSuccess
            ? Results.Ok(Value)
            : Error!.Type switch
            {
                ErrorType.Validation => Results.ValidationProblem(Error.ValidationErrors ??
                                                                  new Dictionary<string, string[]>()),
                ErrorType.Unauthorized => Results.Unauthorized(),
                ErrorType.NotFound => Results.NotFound(new ProblemDetails
                {
                    Title = "Not Found",
                    Detail = Error.Message,
                    Status = StatusCodes.Status404NotFound,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.4"
                }),
                ErrorType.Conflict => Results.Conflict(new ProblemDetails
                {
                    Title = "Conflict",
                    Detail = Error.Message,
                    Status = StatusCodes.Status409Conflict,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.8"
                }),
                ErrorType.InternalServerError => Results.Problem(new ProblemDetails
                {
                    Title = "Internal Server Error",
                    Detail = Error.Message,
                    Status = StatusCodes.Status500InternalServerError,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                }),
                _ => Results.Problem(new ProblemDetails
                {
                    Title = "An error occurred",
                    Detail = Error.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Type = "https://tools.ietf.org/html/rfc7231#section-6.5.1"
                })
            };
    }
}