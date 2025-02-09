using MediatR;
using VeerBackend.Application.Features.Auth.Commands.Signup;
using VeerBackend.Application.Features.Auth.Dtos;
using VeerBackend.Application.Features.Auth.Queries.GetById;
using VeerBackend.Application.Features.Auth.Queries.Login;

namespace VeerBackend.WebApi.Endpoints;

public static class UserEndpoints
{
    public static void AddUserEndpoints(this IEndpointRouteBuilder builder)
    {
        var group = builder.MapGroup("api/v1/")
            .WithOpenApi()
            .WithTags("User Endpoints");
        
        group.MapPost("auth/login",Login)
            .Produces<LoginResponse>();
        group.MapPost("auth/signup", Signup)
            .Produces(StatusCodes.Status201Created);

        group.MapGet("users/logged-in", GetUser)
            .RequireAuthorization()
            .Produces<ReadUserDto>()
            .WithDescription("use this secured endpoint to get the logged in user information");
    }

    private static async Task<IResult> Login(HttpContext context, LoginRequest? request, IMediator mediator)
    {
        if(request == null)
            return Results.BadRequest("invalid request body");
        var result = await mediator.Send(request);
        return result.ToIResult();
    }
    
    private static async Task<IResult> Signup(HttpContext context, SignupRequest? request, IMediator mediator)
    {
        if(request == null)
            return Results.BadRequest("invalid request body");
        var result = await mediator.Send(request);
        return result.ToIResult();
    }
    
    private static async Task<IResult> GetUser(HttpContext context, IMediator mediator)
    {
        var result = await mediator.Send(new GetUserByIdRequest());
        return result.ToIResult();
    }
}