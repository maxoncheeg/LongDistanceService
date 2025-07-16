using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Services.Entities.Abstract;

public interface IUserService
{
    public Task<IUser?> CreateUserAsync(string login, string password, IList<Roles> roles);
    public Task<bool> ChangePasswordAsync(int userId, string oldPassword, string password);
    public Task<IList<IRole>> GetRolesAsync();
    public Task<IList<IUser>> GetUsersAsync();
    public Task<IUser?> GetUserAsync(int userId);
    public Task<bool> UpdateUserAsync(IUser user);
    public Task<bool> DeleteUserAsync(int userId);
    public Task<bool> UpdateEmailVerificationAsync(int userId, bool verified);
}