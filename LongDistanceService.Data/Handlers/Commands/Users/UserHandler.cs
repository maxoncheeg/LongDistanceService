using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Data.Mappings;
using LongDistanceService.Domain.CQRS.Commands.Users;
using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Users;

public class UserHandler(IApplicationDbContext context) : IRequestHandler<ChangeUserPasswordRequest, bool>,
    IRequestHandler<CreateUserRequest, UserResponse?>
    , IRequestHandler<UpdateUserRequest, bool>, IRequestHandler<DeleteUserRequest, bool>
{
    public async Task<bool> Handle(ChangeUserPasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == request.UserId,
            cancellationToken: cancellationToken);

        if (user == null) return false;

        try
        {
            user.Password = request.NewPassword;
            context.Update(user);
            await context.SaveAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;
    }

    public async Task<UserResponse?> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var roles = await context.Roles.Where(r => request.Roles.Contains(r.Type))
            .ToListAsync(cancellationToken: cancellationToken);
        if (roles.Count <= 0) return null;

        var user = new User
        {
            Password = request.Password,
            Login = request.Login,
        };

        var userRoles = roles.Select(role => new UserRole { User = user, Role = role }).ToList();

        try
        {
            await context.CreateAsync(user);
            await context.CreateRangeAsync(userRoles);
            await context.SaveAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }

        return await context.Users.ToUserResponse().SingleOrDefaultAsync(u => u.Email == request.Login, cancellationToken);
    }

    // todo: rework this method. totally bullshit. do not use
    public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == request.Id,
            cancellationToken: cancellationToken);

        if (user == null) return false;
        var userRoles = await context.UserRoles
            .Include(u => u.Role)
            .Where(u => u.UserId == request.Id)
            .ToListAsync(cancellationToken: cancellationToken);

        var roleTypes = request.Roles.Select(r => r.Type).ToList();

        var userRolesOnDelete = (from deleteRole in userRoles
            where !roleTypes.Contains(deleteRole.Role.Type)
            select deleteRole).ToList();
        
        var userRolesOnAdd = (from addRole in userRoles
            where roleTypes.Contains(addRole.Role.Type)
            select addRole).ToList();

        userRoles.RemoveAll(r => userRolesOnDelete.Contains(r));

        // todo: role update is different action
        try
        {
            context.DeleteRange(userRolesOnDelete);
            context.CreateRangeAsync(userRoles);
            
            user.Login = request.Login;
            context.Update(user);
            await context.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<bool> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == request.Id,
            cancellationToken: cancellationToken);
        if (user == null) return false;
        try
        {
            context.Delete(user);
            await context.SaveAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}