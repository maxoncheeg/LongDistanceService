using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Mappings;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.Models.Abstract.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class GetUserHandler(IApplicationDbContext context) :
    IRequestHandler<GetUsersRequest, IList<UserResponse>>,
    IRequestHandler<GetLoginUserByLoginRequest, LoginUserResponse?>,
    IRequestHandler<GetLoginUserByIdRequest, LoginUserResponse?>,
    IRequestHandler<GetUserByIdRequest, UserResponse?>
{
    public async Task<LoginUserResponse?> Handle(GetLoginUserByLoginRequest request,
        CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Login.Equals(request.Login),
            cancellationToken: cancellationToken);

        return user != null ? new LoginUserResponse(user.Id, user.Login, user.Password) : null;
    }

    public async Task<LoginUserResponse?> Handle(GetLoginUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == request.Id,
            cancellationToken: cancellationToken);

        return user != null ? new LoginUserResponse(user.Id, user.Login, user.Password) : null;
    }

    public async Task<IList<UserResponse>> Handle(GetUsersRequest request, CancellationToken cancellationToken)
    {
        return await context.Users
            .Include(u => u.AuthProviders)
            .Include(u => u.UserRoles)
            .ThenInclude(u => u.Role)
            .ToUserResponse()
            .ToListAsync(cancellationToken);
    }

    public async Task<UserResponse?> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        return await context.Users
            .Include(u => u.AuthProviders)
            .Include(u => u.UserRoles)
            .ThenInclude(u => u.Role)
            .ToUserResponse()
            .SingleOrDefaultAsync(u => u.Id == request.Id, cancellationToken: cancellationToken);
    }
}