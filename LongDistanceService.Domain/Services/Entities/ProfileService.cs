using LongDistanceService.Domain.CQRS.Queries.Profile;
using LongDistanceService.Domain.Models.Abstract.Users;
using LongDistanceService.Domain.Services.Entities.Abstract;
using MediatR;

namespace LongDistanceService.Domain.Services.Entities;

public class ProfileService(IMediator mediator) : IProfileService
{
    public async Task<IUserProfile?> GetUserProfileAsync(int userId)
    {
        return await mediator.Send(new GetUserProfileRequest(userId));
    }
}