using LongDistanceService.Domain.CQRS.Commands.AuthProviders;
using LongDistanceService.Domain.CQRS.Queries.AuthProviders;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Models.Abstract.Auth;
using LongDistanceService.Domain.Services.Identity.Abstract;
using LongDistanceService.Domain.Services.Utils.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services.Identity;

public class IdentityService(IMediator mediator, IPasswordHasher passwordHasher, IAccessTokenService tokenService)
    : IIdentityService
{
    public async Task<IAuthResult> LoginAsync(string login, string password)
    {
        var loginUser = await mediator.Send(new GetLoginUserByLoginRequest(login));
        if (loginUser == null)
            return new AuthResult();

        var isPasswordValid = passwordHasher.VerifyHashedPassword(loginUser.PasswordHash, password);
        if (!isPasswordValid)
            return new AuthResult(true);

        var user = await mediator.Send(new GetUserByIdRequest(loginUser.Id));

        return user == null ? new AuthResult(true, true) : new AuthResult(true, true, user);
    }

    public async Task<IAuthResult> LoginAsync(string token)
    {
        var user = await tokenService.GetUserDataFromTokenAsync(token);

        return new AuthResult(user != null, user != null,
            user != null ? await mediator.Send(new GetUserByIdRequest(user.Id)) : null);
    }


    public async Task<bool> AddLoginProviderAsync(int userId, string provider, string providerId)
    {
        var result = await mediator.Send(new AddAuthProviderRequest(userId, provider, providerId));

        return result;
    }

    public async Task<IAuthResult> LoginByProviderAsync(string provider, string providerId)
    {
        var authProvider = await mediator.Send(new GetAuthProviderByIdRequest(provider, providerId));

        if (authProvider == null)
            return new AuthResult();
        
        var user = await mediator.Send(new GetUserByIdRequest(authProvider.UserId));
        
        return user == null ? new AuthResult(true, true) : new AuthResult(true, true, user);
    }

    public Task<bool> ChangePasswordAsync(int userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeLoginAsync(int userId, string password, string newLogin)
    {
        throw new NotImplementedException();
    }
}