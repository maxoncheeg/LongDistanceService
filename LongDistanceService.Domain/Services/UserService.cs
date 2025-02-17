using LongDistanceService.Domain.CQRS.Commands.Users;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;
using LongDistanceService.Domain.Services.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services;

public class UserService(IMediator mediator, IPasswordHasher hasher) : IUserService
{
    public async Task<bool> CreateUserAsync(string login, string password, UserRole role)
    {
        return await mediator.Send(new CreateUserRequest()
        {
            Login = login,
            Password = hasher.Hash(password),
            Role = role
        });
    }

    public async Task<bool> ChangePasswordAsync(int userId, string oldPassword, string password)
    {
        var user = await mediator.Send(new GetUserByIdRequest(userId));
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

    public async Task<bool> UpdateUserAsync(IUser user)
    {
        return await mediator.Send(new UpdateUserRequest()
        {
            Id = user.Id,
            Login = user.Login,
            Name = user.Name,
            Surname = user.Surname,
            Role = user.Role
        });
    }

    public async Task<bool> DeleteUserAsync(int userId)
    {
        return await mediator.Send(new DeleteUserRequest(userId));
    }
}