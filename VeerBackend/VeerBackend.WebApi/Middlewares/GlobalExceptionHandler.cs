using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace VeerBackend.WebApi.Middlewares;

// This exception handler handles is meant to throw a default response to the user in case of an unhandled exception
// All other exception should be handled with an appropriate error response
public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        await HandleUnknownExceptionAsync(httpContext, exception);
        return true;
    }

    private async Task HandleUnknownExceptionAsync(HttpContext httpContext, Exception ex)
    {
        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        await httpContext.Response.WriteAsJsonAsync(new ProblemDetails
        {
            Status = StatusCodes.Status500InternalServerError,
            Title = "Internal Server Error",
            Type = "https://tools.ietf.org/html/rfc7231#section-6.6.1",
            Detail =
                "Something went wrong while processing your request. If this issue persists, please contact support."
        });
    }
}