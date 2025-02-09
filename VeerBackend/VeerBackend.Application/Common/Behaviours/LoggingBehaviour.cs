using System.Diagnostics;
using System.Text.Json;
using VeerBackend.Application.Common.Models;
using MediatR;
using Microsoft.Extensions.Logging;
using Serilog.Context;

namespace VeerBackend.Application.Common.Behaviours;

/// <summary>
/// Custom logs that execute before and after each request
/// </summary>
/// <param name="logger"></param>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public class LoggingBehaviour<TRequest, TResponse>(
    ILogger<LoggingBehaviour<TRequest, TResponse>> logger)
    : IPipelineBehavior<TRequest, TResponse> where TRequest : class
{
    private readonly Stopwatch _timer = new();

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;


        logger.LogInformation("VeerBackend Request: {Name} {@Request}",
            requestName, request);

        _timer.Start();

        var result = await next();

        _timer.Stop();


        if (_timer.ElapsedMilliseconds > 500)
        {
            logger.LogWarning("VeerBackend request {Name} took {ElapsedMilliseconds}ms. {@Request}",
                requestName, _timer.ElapsedMilliseconds, request);
        }

        if (result is Result resultResult)
        {
            if (!resultResult.IsSuccess)
            {
                using (LogContext.PushProperty("Error", JsonSerializer.Serialize(resultResult.Error)))
                {
                    logger.LogInformation(
                        "VeerBackend request {Name} failed after {ElapsedMilliseconds}ms. {@Request}",
                        requestName, _timer.ElapsedMilliseconds, request);
                }
            }
        }

        return result;
    }
}