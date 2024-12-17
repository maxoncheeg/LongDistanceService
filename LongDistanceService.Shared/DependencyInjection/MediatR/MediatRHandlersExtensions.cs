using LongDistanceService.Data.Handlers.Commands.Applications;
using LongDistanceService.Data.Handlers.Commands.Sql;
using LongDistanceService.Data.Handlers.Commands.Vehicles;
using LongDistanceService.Data.Handlers.Queries.Applications;
using LongDistanceService.Data.Handlers.Queries.Cargoes;
using LongDistanceService.Data.Handlers.Queries.DriverCategories;
using LongDistanceService.Data.Handlers.Queries.Menus;
using LongDistanceService.Data.Handlers.Queries.Users;
using LongDistanceService.Data.Handlers.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Commands.Applications;
using LongDistanceService.Domain.CQRS.Commands.Sql;
using LongDistanceService.Domain.CQRS.Commands.Vehicles;
using LongDistanceService.Domain.CQRS.Queries.Applications;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.CQRS.Queries.DriverCategories;
using LongDistanceService.Domain.CQRS.Queries.Menus;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Responses.Applications;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.DriverCategories;
using LongDistanceService.Domain.CQRS.Responses.Menus;
using LongDistanceService.Domain.CQRS.Responses.Sql;
using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.MediatR;

public static class MediatRHandlersExtensions
{
    public static IServiceCollection AddMediatRHandlers(this IServiceCollection @this)
    {
        #region Commands

        @this.AddTransient<IRequestHandler<SelectSqlRequest, SqlSelectResponse>,
                SqlHandler>()
            .AddTransient<IRequestHandler<CommandSqlRequest, SqlCommandResponse>,
                SqlHandler>()
            .AddTransient<IRequestHandler<CreateApplicationRequest>,
                ApplicationHandler>()
            .AddTransient<IRequestHandler<FinishApplicationRequest>,
                ApplicationHandler>()
            .AddTransient<IRequestHandler<SendApplicationMessageRequest>,
                ApplicationMessagesHandler>()
            .AddTransient<IRequestHandler<DeleteVehicleRequest>,
                VehicleHandler>()
            .AddTransient<IRequestHandler<EditVehicleRequest>,
                VehicleHandler>();

        #endregion

        #region Queries

        @this.AddTransient<IRequestHandler<GetDriverCategoriesRequest, IList<DriverCategoryResponse>>,
                GetDriverCategoriesHandler>()
            .AddTransient<IRequestHandler<GetUserByLoginRequest, UserResponse?>,
                GetUserHandler>()
            .AddTransient<IRequestHandler<GetMenuRequest, IList<MenuItemResponse>>,
                GetMenuHandler>()
            .AddTransient<IRequestHandler<GetUserRightsRequest, UserRightsResponse?>,
                UserRightsHandler>()
            .AddTransient<IRequestHandler<IsUserAdminRequest, bool>, UserRightsHandler>()
            .AddTransient<IRequestHandler<GetApplicationsInfoRequest, IList<ApplicationInfoResponse>>,
                GetApplicationHandler>()
            .AddTransient<IRequestHandler<GetApplicationWithMessagesRequest, ApplicationResponse?>,
                GetApplicationHandler>()
            .AddTransient<IRequestHandler<GetVehiclesInfoRequest, IList<VehicleInfoResponse>>,
                GetVehicleHandler>()
            .AddTransient<IRequestHandler<GetVehicleRequest, VehicleResponse?>,
                GetVehicleHandler>()
            .AddTransient<IRequestHandler<GetModelsRequest, IList<ModelResponse>>,
                GetModelsHandler>()
            .AddTransient<IRequestHandler<GetCargoCategoriesRequest, IList<CargoCategoryResponse>>,
                GetCargoesHandler>();

        #endregion

        return @this;
    }
}