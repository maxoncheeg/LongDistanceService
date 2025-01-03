﻿using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class SecurityService(IMediator mediator, IAccessTokenService tokenService) : ISecurityService
{
    public async Task<IUser?> ValidateTokenAsync(string token)
    {
        return await tokenService.GetUserDataFromTokenAsync(token);
    }

    public async Task<string?> RefreshTokenAsync(string refreshToken, string expiredToken)
    {
        return await tokenService.RefreshTokenAsync(refreshToken, expiredToken);
    }

    public async Task<bool> IsAdminAsync(IUser user)
    {
        return await mediator.Send(new IsUserAdminRequest() { UserId = user.Id });
    }

    public async Task<IUserRights?> GetUserRightsToPageAsync(IUser user, string route)
    {
        return await mediator.Send(new GetUserRightsRequest(user, route));
    }
}