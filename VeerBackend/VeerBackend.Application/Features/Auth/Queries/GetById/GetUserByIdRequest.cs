using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using VeerBackend.Application.Common.Models;
using VeerBackend.Application.Features.Auth.Dtos;
using VeerBackend.Contracts.Interfaces;

namespace VeerBackend.Application.Features.Auth.Queries.GetById;

public class GetUserByIdRequest : IRequest<Result<ReadUserDto>>;

public class GetUserByIdRequestHandler(IUserRepository userRepository, IAuthUserService authUserService )
    : IRequestHandler<GetUserByIdRequest, Result<ReadUserDto>>
{
    public async Task<Result<ReadUserDto>> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var userId = authUserService.GetUserId();
        if(!userId.HasValue)
            return Result<ReadUserDto>.Unauthorized("Unauthorized", "unauthenticated user");
        
        var user = await userRepository.GetUserById(userId.Value);
        if (user == null)
            return Result<ReadUserDto>.NotFound("UserNotFound", "user not found");

        return Result<ReadUserDto>.Success(new ReadUserDto(user));
    }
}