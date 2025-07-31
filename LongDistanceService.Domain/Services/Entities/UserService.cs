using LongDistanceService.Domain.CQRS.Commands.Users;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Users;
using LongDistanceService.Domain.Services.Entities.Abstract;
using LongDistanceService.Domain.Services.Utils.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services.Entities;

public class UserService(IMediator mediator, IPasswordHasher hasher) : IUserService
{
    public async Task<IUser?> CreateUserAsync(string login, string password, IList<Roles> roles)
    {
        return await mediator.Send(new CreateUserRequest()
        {
            Login = login,
            Password = hasher.Hash(password),
            Roles = roles
        });
    }

    public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string password)
    {
        var user = await mediator.Send(new GetLoginUserByIdRequest(userId));
        if (user == null) return false;

        if (hasher.VerifyHashedPassword(user.PasswordHash, oldPassword))
            return await mediator.Send(new ChangeUserPasswordRequest()
            {
                NewPassword = hasher.Hash(password),
                UserId = userId
            });
        return false;
    }

    public async Task<IList<IRole>> GetRolesAsync()
    {
        return [..await mediator.Send(new GetRolesRequest())];
    }

    public async Task<IList<IUser>> GetUsersAsync()
    {
        return [..await mediator.Send(new GetUsersRequest())];
    }

    public async Task<IUser?> GetUserAsync(int userId)
    {
        return await mediator.Send(new GetUserByIdRequest(userId));
    }

    public async Task<bool> UpdateUserAsync(IUser user)
    {
        return await mediator.Send(new UpdateUserRequest()
        {
            Id = user.Id,
            Login = user.Email,
            Roles = user.Roles
        });
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        return await mediator.Send(new DeleteUserRequest(userId));
    }

    public async Task<bool> UpdateEmailVerificationAsync(int userId, bool verified)
    {
        return await mediator.Send(new UpdateUserEmailVerificationRequest(userId, verified));
    }
}