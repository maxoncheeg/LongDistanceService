using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IProfileService
{
    public Task<IUserProfile?> GetUserProfileAsync(int userId);
}