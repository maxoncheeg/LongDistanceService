using LongDistanceService.Data.Handlers.Commands.Addresses;
using LongDistanceService.Data.Handlers.Commands.Applications;
using LongDistanceService.Data.Handlers.Commands.AuthProviders;
using LongDistanceService.Data.Handlers.Commands.Cargoes;
using LongDistanceService.Data.Handlers.Commands.Drivers;
using LongDistanceService.Data.Handlers.Commands.Orders;
using LongDistanceService.Data.Handlers.Commands.Personals;
using LongDistanceService.Data.Handlers.Commands.Sql;
using LongDistanceService.Data.Handlers.Commands.TwoFactor;
using LongDistanceService.Data.Handlers.Commands.Users;
using LongDistanceService.Data.Handlers.Commands.Vehicles;
using LongDistanceService.Data.Handlers.Queries.Addresses;
using LongDistanceService.Data.Handlers.Queries.Applications;
using LongDistanceService.Data.Handlers.Queries.AuthProviders;
using LongDistanceService.Data.Handlers.Queries.Cargoes;
using LongDistanceService.Data.Handlers.Queries.DriverCategories;
using LongDistanceService.Data.Handlers.Queries.Drivers;
using LongDistanceService.Data.Handlers.Queries.Orders;
using LongDistanceService.Data.Handlers.Queries.Personals;
using LongDistanceService.Data.Handlers.Queries.TwoFactor;
using LongDistanceService.Data.Handlers.Queries.Users;
using LongDistanceService.Data.Handlers.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Commands.Addresses;
using LongDistanceService.Domain.CQRS.Commands.Applications;
using LongDistanceService.Domain.CQRS.Commands.AuthProviders;
using LongDistanceService.Domain.CQRS.Commands.Cargoes;
using LongDistanceService.Domain.CQRS.Commands.Drivers;
using LongDistanceService.Domain.CQRS.Commands.Orders;
using LongDistanceService.Domain.CQRS.Commands.Personals;
using LongDistanceService.Domain.CQRS.Commands.Sql;
using LongDistanceService.Domain.CQRS.Commands.TwoFactor;
using LongDistanceService.Domain.CQRS.Commands.Users;
using LongDistanceService.Domain.CQRS.Commands.Vehicles;
using LongDistanceService.Domain.CQRS.Queries.Addresses;
using LongDistanceService.Domain.CQRS.Queries.Applications;
using LongDistanceService.Domain.CQRS.Queries.AuthProviders;
using LongDistanceService.Domain.CQRS.Queries.Cargoes;
using LongDistanceService.Domain.CQRS.Queries.DriverCategories;
using LongDistanceService.Domain.CQRS.Queries.Drivers;
using LongDistanceService.Domain.CQRS.Queries.Orders;
using LongDistanceService.Domain.CQRS.Queries.Personals;
using LongDistanceService.Domain.CQRS.Queries.Profile;
using LongDistanceService.Domain.CQRS.Queries.TwoFactor;
using LongDistanceService.Domain.CQRS.Queries.Users;
using LongDistanceService.Domain.CQRS.Queries.Vehicles;
using LongDistanceService.Domain.CQRS.Responses.Addresses;
using LongDistanceService.Domain.CQRS.Responses.Applications;
using LongDistanceService.Domain.CQRS.Responses.AuthProviders;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.Drivers;
using LongDistanceService.Domain.CQRS.Responses.Orders;
using LongDistanceService.Domain.CQRS.Responses.Personals;
using LongDistanceService.Domain.CQRS.Responses.Sql;
using LongDistanceService.Domain.CQRS.Responses.TwoFactors;
using LongDistanceService.Domain.CQRS.Responses.Users;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using LongDistanceService.Domain.Enums;
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
            
            // applications
            .AddTransient<IRequestHandler<CreateApplicationRequest>,
                ApplicationHandler>()
            .AddTransient<IRequestHandler<FinishApplicationRequest>,
                ApplicationHandler>()
            .AddTransient<IRequestHandler<SendApplicationMessageRequest>,
                ApplicationMessagesHandler>()
            
            // vehicles
            .AddTransient<IRequestHandler<DeleteVehicleRequest>,
                VehicleHandler>()
            .AddTransient<IRequestHandler<EditVehicleRequest>,
                VehicleHandler>()
            
            // drivers
            .AddTransient<IRequestHandler<DeleteDriverRequest, bool>, DriverHandler>()
            .AddTransient<IRequestHandler<EditDriverRequest, bool>, DriverHandler>()
            
            // brands
            .AddTransient<IRequestHandler<EditBrandRequest, bool>, BrandHandler>()
            .AddTransient<IRequestHandler<DeleteBrandRequest, bool>, BrandHandler>()
            
            // driver categories
            .AddTransient<IRequestHandler<EditDriverCategoryRequest, bool>, DriverCategoryHandler>()
            .AddTransient<IRequestHandler<DeleteDriverCategoryRequest, bool>, DriverCategoryHandler>()
            
            // streets
            .AddTransient<IRequestHandler<EditStreetRequest, bool>, AddressHandler>()
            .AddTransient<IRequestHandler<DeleteStreetRequest, bool>, AddressHandler>()
            
            // cities
            .AddTransient<IRequestHandler<EditCityRequest, bool>, AddressHandler>()
            .AddTransient<IRequestHandler<DeleteCityRequest, bool>, AddressHandler>()
            
            // units
            .AddTransient<IRequestHandler<EditUnitRequest, bool>, UnitHandler>()
            .AddTransient<IRequestHandler<DeleteUnitRequest, bool>, UnitHandler>()
            
            // models
            .AddTransient<IRequestHandler<DeleteModelRequest, bool>, ModelHandler>()
            .AddTransient<IRequestHandler<EditModelRequest, bool>, ModelHandler>()
            
            // cargos
            .AddTransient<IRequestHandler<DeleteCargoCategoryRequest, bool>, CargoCategoryHandler>()
            .AddTransient<IRequestHandler<EditCargoCategoryRequest, bool>, CargoCategoryHandler>()
            .AddTransient<IRequestHandler<DeleteCargoRequest, bool>, CargoHandler>()
            .AddTransient<IRequestHandler<EditCargoRequest, bool>, CargoHandler>()
            
            // orders
            .AddTransient<IRequestHandler<AddOrderRequest, bool>, OrderHandler>()

            // personals
            .AddTransient<IRequestHandler<DeleteLegalRequest, bool>, PersonalHandler>()
            .AddTransient<IRequestHandler<EditLegalRequest, bool>, PersonalHandler>()
            .AddTransient<IRequestHandler<DeleteIndividualRequest, bool>, PersonalHandler>()
            .AddTransient<IRequestHandler<EditIndividualRequest, bool>, PersonalHandler>()
            
            // banks
            .AddTransient<IRequestHandler<EditBankRequest, bool>, BankHandler>()
            .AddTransient<IRequestHandler<DeleteBankRequest, bool>, BankHandler>()

            //users
            .AddTransient<IRequestHandler<CreateUserRequest, UserResponse?>, UserHandler>()
            .AddTransient<IRequestHandler<ChangeUserPasswordRequest, bool>, UserHandler>()
            .AddTransient<IRequestHandler<UpdateUserRequest, bool>, UserHandler>()
            .AddTransient<IRequestHandler<DeleteUserRequest, bool>, UserHandler>()
            
            .AddTransient<IRequestHandler<GetUserProfileRequest, UserProfileResponse?>, GetUserProfileHandler>()
            
            .AddTransient<IRequestHandler<UpdateUserEmailVerificationRequest, bool>, UserProfileHandler>()
            
            // auth providers
            .AddTransient<IRequestHandler<AddAuthProviderRequest, bool>, AuthProviderHandler>()
            
            // two factors
            .AddTransient<IRequestHandler<CreateTwoFactorSecretRequest, bool>, TwoFactorHandler>()
            ;

        #endregion

        #region Queries

        // driver categories
        @this.AddTransient<IRequestHandler<GetDriverCategoriesRequest, IList<DriverCategoryResponse>>,
                GetDriverCategoriesHandler>()
            
            // users
            .AddTransient<IRequestHandler<GetLoginUserByLoginRequest, LoginUserResponse?>,
                GetUserHandler>()
            .AddTransient<IRequestHandler<GetLoginUserByIdRequest, LoginUserResponse?>,
                GetUserHandler>()
            .AddTransient<IRequestHandler<GetUsersRequest, IList<UserResponse>>,
                GetUserHandler>()
            .AddTransient<IRequestHandler<GetUserByIdRequest, UserResponse?>,
                GetUserHandler>()
            
            // applications
            .AddTransient<IRequestHandler<GetApplicationsInfoRequest, IList<ApplicationInfoResponse>>,
                GetApplicationHandler>()
            .AddTransient<IRequestHandler<GetApplicationWithMessagesRequest, ApplicationResponse?>,
                GetApplicationHandler>()
            
            // vehicles
            .AddTransient<IRequestHandler<GetVehiclesInfoRequest, IList<VehicleInfoResponse>>,
                GetVehicleHandler>()
            .AddTransient<IRequestHandler<GetVehicleRequest, VehicleResponse?>,
                GetVehicleHandler>()
            
            // models
            .AddTransient<IRequestHandler<GetModelsRequest, IList<ModelResponse>>,
                GetModelsHandler>()
            
            // cargo categories
            .AddTransient<IRequestHandler<GetCargoCategoriesRequest, IList<CargoCategoryResponse>>,
                GetCargoesHandler>()
            
            // drivers
            .AddTransient<IRequestHandler<GetDriversInfoRequest, IList<DriverInfoResponse>>,
                GetDriverHandler>()
            .AddTransient<IRequestHandler<GetDriverRequest, DriverResponse?>,
                GetDriverHandler>()
            
            // personals
            .AddTransient<IRequestHandler<GetLegalsRequest, IList<LegalResponse>>, GetPersonalsHandler>()
            .AddTransient<IRequestHandler<GetIndividualsRequest, IList<IndividualResponse>>, GetPersonalsHandler>()
            
            // cities and streets
            .AddTransient<IRequestHandler<GetCitiesRequest, IList<CityResponse>>, GetAddressHandler>()
            .AddTransient<IRequestHandler<GetStreetsRequest, IList<StreetResponse>>, GetAddressHandler>()
            
            // brands
            .AddTransient<IRequestHandler<GetBrandsRequest, IList<BrandResponse>>, GetBrandsHandler>()
            
            // units
            .AddTransient<IRequestHandler<GetUnitsRequest, IList<UnitResponse>>, GetUnitsHandler>()
            
            // cargoes
            .AddTransient<IRequestHandler<GetCargoesRequest, IList<CargoResponse>>, GetCargoesHandler>()
            
            // orders
            .AddTransient<IRequestHandler<GetSlimOrdersRequest, IList<SlimOrderResponse>>, GetOrdersHandler>()
            .AddTransient<IRequestHandler<GetOrderRequest, OrderResponse?>, GetOrdersHandler>()
            
            // banks
            .AddTransient<IRequestHandler<GetBanksRequest, IList<BankResponse>>, GetBanksHandler>()
            
            // roles
            .AddTransient<IRequestHandler<GetRolesRequest, IList<RoleResponse>>, GetRolesHandler>()
            
            // users
            .AddTransient<IRequestHandler<GetUserRoleRequest, Roles?>, GetUserRoleHandler>()
            
            // auth providers
            .AddTransient<IRequestHandler<GetAuthProvidersRequest, IList<AuthProviderResponse>?>,
                GetAuthProvidersHandler>()
            .AddTransient<IRequestHandler<GetAuthProviderByIdRequest, AuthProviderResponse?>,
                GetAuthProvidersHandler>()
            
            // two factors
            .AddTransient<IRequestHandler<GetLastTwoFactorSecretRequest, TwoFactorSecretResponse?>, GetTwoFactorSecretHandler>()
            ;

        #endregion

        return @this;
    }
}