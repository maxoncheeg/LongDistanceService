using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class GetUserHandler(IApplicationDbContext context) : IRequestHandler<GetUserByLoginRequest, UserResponse?>, IRequestHandler<GetUserByIdRequest, UserResponse?>
{
    public async Task<UserResponse?> Handle(GetUserByLoginRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Login.Equals(request.Login), cancellationToken: cancellationToken);

        return user != null ? new UserResponse(user.Id, user.Login, user.Password) : null;
    }

    public async Task<UserResponse?> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken: cancellationToken);

        return user != null ? new UserResponse(user.Id, user.Login, user.Password) : null;
    }
}