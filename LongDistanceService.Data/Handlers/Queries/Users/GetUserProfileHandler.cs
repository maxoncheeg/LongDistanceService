using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Mappings;
using LongDistanceService.Domain.CQRS.Queries.Profile;
using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.Models.Abstract.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Users;

public class GetUserProfileHandler(IApplicationDbContext context)
    : IRequestHandler<GetUserProfileRequest, UserProfileResponse?>
{
    public async Task<UserProfileResponse?> Handle(GetUserProfileRequest request, CancellationToken cancellationToken)
    {
        var profile = await context.Users
            .Where(u => u.Id == request.UserId)
            .ToUserProfileResponse()
            .SingleOrDefaultAsync(cancellationToken);

        return profile;
    }
}