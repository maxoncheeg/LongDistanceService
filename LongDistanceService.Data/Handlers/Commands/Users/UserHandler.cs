using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Commands.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Users;

public class UserHandler(IApplicationDbContext context) : IRequestHandler<ChangeUserPasswordRequest, bool>, IRequestHandler<CreateUserRequest, bool>
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
}