using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Commands.Users;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Commands.Users;

public class UserProfileHandler(IApplicationDbContext context) : IRequestHandler<UpdateUserEmailVerificationRequest, bool>
{
    public async Task<bool> Handle(UpdateUserEmailVerificationRequest request, CancellationToken cancellationToken)
    {
        var user = await context.Users.Where(u => u.Id == request.UserId).SingleOrDefaultAsync(cancellationToken);

        if (user == null) return false;
        
        user.IsEmailVerified = request.Verified;
        await context.SaveAsync();
        
        return true;
    }
}