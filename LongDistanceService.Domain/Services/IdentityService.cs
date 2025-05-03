using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Models;
using LongDistanceService.Domain.Models.Abstract.Auth;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class IdentityService(IMediator mediator, IPasswordHasher passwordHasher) : IIdentityService
{
    public async Task<IAuthResult> LoginAsync(string login, string password)
    {
        var loginUser = await mediator.Send(new GetLoginUserByLoginRequest(login));
        if (loginUser == null)
            return new AuthResult();
        
        var isPasswordValid = passwordHasher.VerifyHashedPassword(loginUser.PasswordHash, password);
        if(!isPasswordValid)
            return new AuthResult(true);
        
        var user = await mediator.Send(new GetUserByIdRequest(loginUser.Id));
        
        return user == null ? new AuthResult(true, true) : new AuthResult(true, true, user);
    }

    public Task<IAuthResult> LoginByProviderAsync(string provider, string providerId)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ChangeLoginAsync(string userId, string password, string newLogin)
    {
        throw new NotImplementedException();
    }

    public Task<bool> AddLoginProviderAsync(string userId, string provider, string providerId)
    {
        throw new NotImplementedException();
    }
}