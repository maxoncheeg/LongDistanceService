using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Commands.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Users;

public class UserHandler(IApplicationDbContext context) : IRequestHandler<ChangeUserPasswordRequest, bool>, IRequestHandler<CreateUserRequest, bool>
, IRequestHandler<UpdateUserRequest, bool>, IRequestHandler<DeleteUserRequest, bool>
{
    public async Task<bool> Handle(ChangeUserPasswordRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == request.UserId, cancellationToken: cancellationToken);

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

    public async Task<bool> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var role = await context.Roles.SingleOrDefaultAsync(r => r.Id == request.RoleId, cancellationToken: cancellationToken);
        if (role == null) return false;
        
        var user = new User
        {
            Password = request.Password,
            Role = role,
            Login = request.Login,
            Name = request.Name,
            Surname = request.Surname
        };

        try
        {
            context.Create(user);
            await context.SaveAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }

        return true;
    }

    public async Task<bool> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        if(user == null) return false;
        var role = await context.Roles.SingleOrDefaultAsync(r => r.Id == request.Role.Id, cancellationToken: cancellationToken);
        if(role == null) return false;
        
        try
        {
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.Role = role;
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
        var user = await context.Users.SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
        if(user == null) return false;
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