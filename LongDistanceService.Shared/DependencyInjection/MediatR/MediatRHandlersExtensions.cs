using LongDistanceService.Data.Handlers.Commands.Addresses;
using LongDistanceService.Data.Handlers.Commands.Applications;
using LongDistanceService.Data.Handlers.Commands.Cargoes;
using LongDistanceService.Data.Handlers.Commands.Drivers;
using LongDistanceService.Data.Handlers.Commands.Personals;
using LongDistanceService.Data.Handlers.Commands.Sql;
using LongDistanceService.Data.Handlers.Commands.Vehicles;
using LongDistanceService.Data.Handlers.Queries.Addresses;
using LongDistanceService.Data.Handlers.Queries.Applications;
using LongDistanceService.Data.Handlers.Queries.Cargoes;
using LongDistanceService.Data.Handlers.Queries.DriverCategories;
using LongDistanceService.Data.Handlers.Queries.Drivers;
using LongDistanceService.Data.Handlers.Queries.Menus;
using LongDistanceService.Data.Handlers.Queries.Personals;
using LongDistanceService.Data.Handlers.Queries.Users;
using LongDistanceService.Data.Handlers.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Commands.Addresses;
using LongDistanceService.Domain.CQRS.Commands.Applications;
using LongDistanceService.Domain.CQRS.Commands.Cargoes;
using LongDistanceService.Domain.CQRS.Commands.Drivers;
using LongDistanceService.Domain.CQRS.Commands.Personals;
using LongDistanceService.Domain.CQRS.Commands.Sql;
using LongDistanceService.Domain.CQRS.Commands.Vehicles;
using LongDistanceService.Domain.CQRS.Queries.Addresses;
using LongDistanceService.Domain.CQRS.Queries.Applications;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.CQRS.Queries.DriverCategories;
using LongDistanceService.Domain.CQRS.Queries.Drivers;
using LongDistanceService.Domain.CQRS.Queries.Menus;
using LongDistanceService.Domain.CQRS.Queries.Personals;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Responses.Addresses;
using LongDistanceService.Domain.CQRS.Responses.Applications;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.Drivers;
using LongDistanceService.Domain.CQRS.Responses.Menus;
using LongDistanceService.Domain.CQRS.Responses.Personals;
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
        // todo: навести порядок, упорядочивание W
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
                VehicleHandler>()
            .AddTransient<IRequestHandler<DeleteDriverRequest, bool>, DriverHandler>()
            .AddTransient<IRequestHandler<EditDriverRequest, bool>, DriverHandler>()
            .AddTransient<IRequestHandler<EditBrandRequest, bool>, BrandHandler>()
            .AddTransient<IRequestHandler<DeleteBrandRequest, bool>, BrandHandler>()
            .AddTransient<IRequestHandler<EditDriverCategoryRequest, bool>, DriverCategoryHandler>()
            .AddTransient<IRequestHandler<DeleteDriverCategoryRequest, bool>, DriverCategoryHandler>()
            .AddTransient<IRequestHandler<EditStreetRequest, bool>, AddressHandler>()
            .AddTransient<IRequestHandler<DeleteStreetRequest, bool>, AddressHandler>()
            .AddTransient<IRequestHandler<EditCityRequest, bool>, AddressHandler>()
            .AddTransient<IRequestHandler<DeleteCityRequest, bool>, AddressHandler>()
            .AddTransient<IRequestHandler<EditUnitRequest, bool>, UnitHandler>()
            .AddTransient<IRequestHandler<DeleteUnitRequest, bool>, UnitHandler>()
            .AddTransient<IRequestHandler<DeleteModelRequest, bool>, ModelHandler>()
            .AddTransient<IRequestHandler<EditModelRequest, bool>, ModelHandler>()
            .AddTransient<IRequestHandler<DeleteCargoCategoryRequest, bool>, CargoCategoryHandler>()
            .AddTransient<IRequestHandler<EditCargoCategoryRequest, bool>, CargoCategoryHandler>()
            .AddTransient<IRequestHandler<DeleteCargoRequest, bool>, CargoHandler>()
            .AddTransient<IRequestHandler<EditCargoRequest, bool>, CargoHandler>()
            .AddTransient<IRequestHandler<EditBankRequest, bool>, BankHandler>()
            .AddTransient<IRequestHandler<DeleteBankRequest, bool>, BankHandler>();

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
                GetCargoesHandler>()
            .AddTransient<IRequestHandler<GetDriversInfoRequest, IList<DriverInfoResponse>>,
                GetDriverHandler>()
            .AddTransient<IRequestHandler<GetDriverRequest, DriverResponse?>,
                GetDriverHandler>()
            .AddTransient<IRequestHandler<GetCitiesRequest, IList<CityResponse>>, GetAddressHandler>()
            .AddTransient<IRequestHandler<GetStreetsRequest, IList<StreetResponse>>, GetAddressHandler>()
            .AddTransient<IRequestHandler<GetBrandsRequest, IList<BrandResponse>>, GetBrandsHandler>()
            .AddTransient<IRequestHandler<GetUnitsRequest, IList<UnitResponse>>, GetUnitsHandler>()
            .AddTransient<IRequestHandler<GetCargoesRequest, IList<CargoResponse>>, GetCargoesHandler>()
            .AddTransient<IRequestHandler<GetBanksRequest, IList<BankResponse>>, GetBanksHandler>();

        #endregion

        return @this;
    }
}