using LongDistanceService.Data.Handlers.Queries.DriverCategories;
using LongDistanceService.Data.Handlers.Queries.Menus;
using LongDistanceService.Data.Handlers.Queries.Users;
using LongDistanceService.Domain.CQRS.Queries.DriverCategories;
using LongDistanceService.Domain.CQRS.Queries.Menus;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Responses.DriverCategories;
using LongDistanceService.Domain.CQRS.Responses.Menus;
using LongDistanceService.Domain.CQRS.Responses.Users;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.MediatR;

public static class MediatRHandlersExtensions
{
    public static IServiceCollection AddMediatRHandlers(this IServiceCollection @this)
    {
        #region Commands

        #endregion

        #region Queries

        @this.AddTransient<IRequestHandler<GetDriverCategoriesRequest, IList<DriverCategoryResponse>>,
            GetDriverCategoriesHandler>()
            .AddTransient<IRequestHandler<GetUserByLoginRequest, UserResponse?>,
                GetUserHandler>()
            .AddTransient<IRequestHandler<GetMenuRequest, IList<MenuItemResponse>>,
                GetMenuHandler>()
            .AddTransient<IRequestHandler<IsUserAdminRequest, bool>, IsUserAdminHandler>();

        #endregion

        return @this;
    }
}