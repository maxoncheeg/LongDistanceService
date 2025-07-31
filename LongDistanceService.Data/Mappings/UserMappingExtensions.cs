using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Order;
using LongDistanceService.Domain.Models.Abstract.Users;

namespace LongDistanceService.Data.Mappings;

public static class UserMappingExtensions
{
    public static IQueryable<UserResponse> ToUserResponse(this IQueryable<User> @this)
    {
        return @this.Select(user => new UserResponse
        {
            Id = user.Id,
            Email = user.Login,
            IsEmailVerified = user.IsEmailVerified,
            IsExternalUser = user.AuthProviders.Count > 0,
            Roles = new List<IRole>(user.UserRoles.Select(userRole => new RoleResponse
            {
                Id = userRole.Role.Id,
                Type = userRole.Role.Type
            }))
        });
    }

    public static IQueryable<UserProfileResponse> ToUserProfileResponse(this IQueryable<User> @this,
        IApplicationDbContext context)
    {
        return @this.Select(user => new UserProfileResponse
        {
            Id = user.Id,
            Email = user.Login,

            AuthProviders = user.AuthProviders.Select(provider => provider.ProviderName).ToList(),

            Roles = new List<IRole>(user.UserRoles.Select(userRole => new RoleResponse
            {
                Id = userRole.Role.Id,
                Type = userRole.Role.Type
            }).ToList()),
        });
    }
}