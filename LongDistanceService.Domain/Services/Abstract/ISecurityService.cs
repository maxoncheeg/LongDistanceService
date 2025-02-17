using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract;

namespace LongDistanceService.Domain.Services.Abstract;

public interface ISecurityService
{
    public Task<bool> IsAdminAsync();
    public Task<bool> IsManagementAsync();
    public Task<bool> IsDriverAsync();
    public Task<bool> IsClientAsync();
    public Task<UserRole?> GetUserRoleAsync();
}