using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Domain.Services.Abstract;

public interface IUserService
{
    public Task<bool> CreateUserAsync(string login, string password, UserRole role);
    public Task<bool> ChangePasswordAsync(int userId, string oldPassword, string password);
    public Task<IList<IRole>> GetRolesAsync();
    public Task<IList<IUser>> GetUsersAsync();
    public Task<bool> UpdateUserAsync(IUser user);
    public Task<bool> DeleteUserAsync(int userId);
}