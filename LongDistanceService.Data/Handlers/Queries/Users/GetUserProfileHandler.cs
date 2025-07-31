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
        var personals = await context.UserPersonals.Where(p => p.UserId == request.UserId)
            .FirstOrDefaultAsync(cancellationToken: cancellationToken);

        IList<IProfileOrder> orders = [];

        if (personals != null)
        {
            orders = new List<IProfileOrder>(await context.Orders
                .Take(5)
                .OrderByDescending(order => order.Id)
                .Where(order =>
                    order.IndividualReceiverId == personals.PersonalId ||
                    order.IndividualSenderId == personals.PersonalId ||
                    order.LegalSenderId == personals.PersonalId ||
                    order.LegalReceiverId == personals.PersonalId
                )
                .ToProfileOrderResponse()
                .ToListAsync(cancellationToken));
        }

        var profile = await context.Users.Where(u => u.Id == request.UserId).ToUserProfileResponse(context)
            .FirstOrDefaultAsync(cancellationToken);

        if (profile != null)
        {
            profile.Orders = orders;
        }

        return profile;
    }
}