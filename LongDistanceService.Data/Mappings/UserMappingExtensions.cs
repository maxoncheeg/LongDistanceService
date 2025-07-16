using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Data.Mappings;

public static class UserMappingExtensions
{
    public static IQueryable<UserResponse> ToUserResponse(this IQueryable<User> @this)
    {
        return @this.Select(user => new UserResponse
        {
            Id = user.Id,
            Login = user.Login,
            IsEmailVerified = user.IsEmailVerified,
            IsExternalUser = user.AuthProviders.Count > 0,
            Roles = new List<IRole>(user.UserRoles.Select(userRole => new RoleResponse
            {
                Id = userRole.Role.Id,
                Type = userRole.Role.Type
            }))
        });
    }
}