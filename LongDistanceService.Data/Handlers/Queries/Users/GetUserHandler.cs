using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class GetUserHandler(IApplicationDbContext context) :  IRequestHandler<GetUsersRequest, IList<UserResponse>>, IRequestHandler<GetUserByLoginRequest, LoginUserResponse?>, IRequestHandler<GetUserByIdRequest, LoginUserResponse?>
{
    public async Task<LoginUserResponse?> Handle(GetUserByLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Login.Equals(request.Login), cancellationToken: cancellationToken);

        return user != null ? new LoginUserResponse(user.Id, user.Login, user.Password) : null;
    }

    public async Task<LoginUserResponse?> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken: cancellationToken);

        return user != null ? new LoginUserResponse(user.Id, user.Login, user.Password) : null;
    }

    public async Task<IList<UserResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        return await context.Users.Include(u => u.Role).Select(u => new UserResponse()
        {
            Id = u.Id,
            Login = u.Login,
            Name = u.Name,
            Surname = u.Surname,
            Role = new RoleResponse()
            {
                Id = u.Role.Id,
                Name = u.Role.Name
            }
        }).ToListAsync(cancellationToken);
    }
}