using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Domain.CQRS.Queries.Orders;
using LongDistanceService.Domain.CQRS.Responses.Addresses;
using LongDistanceService.Domain.CQRS.Responses.Cargoes;
using LongDistanceService.Domain.CQRS.Responses.Drivers;
using LongDistanceService.Domain.CQRS.Responses.Orders;
using LongDistanceService.Domain.CQRS.Responses.Personals;
using LongDistanceService.Domain.CQRS.Responses.Vehicles;
using LongDistanceService.Domain.Enums;
using LongDistanceService.Domain.Models.Abstract.Cargoes;
using LongDistanceService.Domain.Models.Abstract.Drivers;
using LongDistanceService.Domain.Models.Abstract.Order;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Handlers.Queries.Orders;

public class GetOrdersHandler(IApplicationDbContext context)
    : IRequestHandler<GetOrderInfosRequest, IList<OrderInfoResponse>>, IRequestHandler<GetOrderRequest, OrderResponse?>
{
    public async Task<IList<OrderInfoResponse>> Handle(GetOrderInfosRequest request,
        CancellationToken cancellationToken)
    {
        var orders = context.Orders
            .Include(p => p.ReceiveCity)
            .Include(p => p.ReceiveStreet)
            .Include(p => p.SendCity)
            .Include(p => p.SendStreet)
            .Include(p => p.Vehicle).ThenInclude(v => v.Model).ThenInclude(v => v.Brand)
            .Include(p => p.OrderDrivers)
            .Select(o => new OrderInfoResponse
            {
                Id = o.Id,
                DriversAmount = o.OrderDrivers.Count,
                State = o.State,
                From = $"{o.SendCity.Name}, {o.SendStreet.Name}",
                To = $"{o.ReceiveCity.Name}, {o.ReceiveStreet.Name}",
                ImagePath = o.Vehicle.ImagePath,
                Vehicle = $"{o.Vehicle.Model.Brand.Name}, {o.Vehicle.Model.Name}, {o.Vehicle.Year}"
            });

        return await orders.ToListAsync(cancellationToken);
    }

    public async Task<OrderResponse?> Handle(GetOrderRequest request, CancellationToken cancellationToken)
    {
        var order = await context.Orders
            .Include(p => p.ReceiveCity)
            .Include(p => p.ReceiveStreet)
            .Include(p => p.SendCity)
            .Include(p => p.SendStreet)
            .Include(p => p.Vehicle).ThenInclude(v => v.Model).ThenInclude(v => v.Brand)
            .Include(p => p.OrderDrivers).ThenInclude(d => d.Driver).ThenInclude(d => d.Category)
            .Include(p => p.OrderCargoes).ThenInclude(o => o.Cargo).ThenInclude(c => c.Category)
            .ThenInclude(c => c.Unit)
            .Where(o => o.Id == request.OrderId)
            .Select(o => new OrderResponse
            {
                Id = o.Id,
                LoadingDate = o.LoadingDate,
                ReceiveHouseNumber = o.ReceiveHouseNumber,
                SendHouseNumber = o.SendHouseNumber,
                State = o.State,
                RouteLength = o.RouteLength,
                ReceiverType = o.ReceiverType,
                SenderType = o.SenderType,
                ReceiverId = o.ReceiverId,
                SenderId = o.SenderId,
                ReceiveCity = new CityResponse { Id = o.ReceiveCity.Id, Name = o.ReceiveCity.Name },
                ReceiveStreet = new StreetResponse { Id = o.ReceiveStreet.Id, Name = o.ReceiveStreet.Name },
                SendCity = new CityResponse { Id = o.SendCity.Id, Name = o.SendCity.Name },
                SendStreet = new StreetResponse() { Id = o.SendStreet.Id, Name = o.SendStreet.Name },
                OrderCargoes = new List<IOrderCargo>(o.OrderCargoes.Select(c => new OrderCargoResponse()
                {
                    Amount = c.Amount,
                    Price = c.Price,
                    Weight = c.Price,
                    Cargo = new CargoResponse()
                    {
                        Id = c.Cargo.Id,
                        Name = c.Cargo.Name,
                        Category = new CargoCategoryResponse()
                        {
                            Id = c.Cargo.Category.Id,
                            Name = c.Cargo.Category.Name,
                            Unit = new UnitResponse()
                            {
                                Id = c.Cargo.Category.UnitId,
                                Name = c.Cargo.Category.Name
                            }
                        }
                    }
                })),
                OrderDrivers = new List<IDriver>(o.OrderDrivers.Select(d => new DriverResponse()
                {
                    Id = d.Driver.Id,
                    Experience = d.Driver.Experience,
                    Name = d.Driver.Name,
                    Patronymic = d.Driver.Patronymic,
                    Surname = d.Driver.Surname,
                    EmployeeNumber = d.Driver.EmployeeNumber,
                    Class = d.Driver.Class,
                    BirthYear = d.Driver.BirthYear,
                    Category = new DriverCategoryResponse() { Id = d.Driver.CategoryId, Name = d.Driver.Category.Name }
                }).ToList()),
                Vehicle = new VehicleResponse
                {
                    Id = o.Vehicle.Id,
                    Kilometerage = o.Vehicle.Kilometerage,
                    LicensePlate = o.Vehicle.LicensePlate,
                    Year = o.Vehicle.Year,
                    OverhaulYear = o.Vehicle.OverhaulYear,
                    ImagePath = o.Vehicle.ImagePath,
                    LoadCapacity = o.Vehicle.LoadCapacity,
                    Model = new ModelResponse()
                    {
                        Id = o.Vehicle.Model.Id, Name = o.Vehicle.Model.Name,
                        Brand = new BrandResponse() { Id = o.Vehicle.Model.Brand.Id, Name = o.Vehicle.Model.Brand.Name }
                    },
                    CargoCategories = new List<ICargoCategory>(o.Vehicle.VehicleCargoCategories.Select(c =>
                        new CargoCategoryResponse
                        {
                            Id = c.Category.Id,
                            Unit = new UnitResponse
                            {
                                Id = c.Category.Unit.Id,
                                Name = c.Category.Unit.Name
                            },
                            Name = c.Category.Name
                        }).ToList())
                }
            }).SingleOrDefaultAsync(cancellationToken);

        if (order == null) return null;

        if (order.ReceiverType == ClientTypes.Individual)

            order.IndividualReceiver = await context.Individuals.Where(i => i.Id == order.ReceiverId)
                .Select(c => new IndividualResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Patronymic = c.Patronymic,
                    PassportDate = c.PassportDate,
                    PassportIssued = c.PassportIssued,
                    PassportSeries = c.PassportSeries,
                    Phone = c.Phone
                }).SingleOrDefaultAsync(cancellationToken);
        else
            order.LegalReceiver = await context.Legals
                .Include(l => l.Bank)
                .Include(l => l.Street)
                .Include(l => l.City)
                .Where(l => l.Id == order.ReceiverId)
                .Select(l =>
                    new LegalResponse()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Patronymic = l.Patronymic,
                        Phone = l.Phone,
                        Account = l.BankAccount,
                        TIN = l.TIN,
                        HouseNumber = l.HouseNumber,
                        OfficeNumber = l.OfficeNumber,
                        CompanyName = l.CompanyName,
                        Bank = new BankResponse()
                        {
                            Id = l.BankId,
                            Name = l.Bank.Name
                        },
                        City = new CityResponse()
                        {
                            Id = l.CityId,
                            Name = l.City.Name
                        },
                        Street = new StreetResponse()
                        {
                            Id = l.StreetId,
                            Name = l.Street.Name
                        }
                    })
                .SingleOrDefaultAsync(cancellationToken);

        if (order.SenderType == ClientTypes.Individual)
            order.IndividualSender = await context.Individuals.Where(i => i.Id == order.SenderId)
                .Select(c => new IndividualResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                    Surname = c.Surname,
                    Patronymic = c.Patronymic,
                    PassportDate = c.PassportDate,
                    PassportIssued = c.PassportIssued,
                    PassportSeries = c.PassportSeries,
                    Phone = c.Phone
                }).SingleOrDefaultAsync(cancellationToken);
        else
            order.LegalSender = await context.Legals
                .Include(l => l.Bank)
                .Include(l => l.Street)
                .Include(l => l.City)
                .Where(l => l.Id == order.SenderId)
                .Select(l =>
                    new LegalResponse()
                    {
                        Id = l.Id,
                        Name = l.Name,
                        Surname = l.Surname,
                        Patronymic = l.Patronymic,
                        Phone = l.Phone,
                        Account = l.BankAccount,
                        TIN = l.TIN,
                        HouseNumber = l.HouseNumber,
                        OfficeNumber = l.OfficeNumber,
                        CompanyName = l.CompanyName,
                        Bank = new BankResponse()
                        {
                            Id = l.BankId,
                            Name = l.Bank.Name
                        },
                        City = new CityResponse()
                        {
                            Id = l.CityId,
                            Name = l.City.Name
                        },
                        Street = new StreetResponse()
                        {
                            Id = l.StreetId,
                            Name = l.Street.Name
                        }
                    })
                .SingleOrDefaultAsync(cancellationToken);

        return order;
    }
}