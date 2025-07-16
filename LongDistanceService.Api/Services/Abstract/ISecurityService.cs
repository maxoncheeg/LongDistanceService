using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Api.Services.Abstract;

public interface ISecurityService
{
    public Task<IUser?> GetCurrentUserAsync();
}