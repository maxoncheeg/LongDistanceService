using LongDistanceService.Domain.Entities;
using LongDistanceService.Domain.Entities.Addresses;
using LongDistanceService.Domain.Entities.Cargoes;
using LongDistanceService.Domain.Entities.Drivers;
using LongDistanceService.Domain.Entities.Personals;
using LongDistanceService.Domain.Entities.Vehicles;

namespace LongDistanceService.Data.Contexts;

public interface IApplicationDbContext : IDbContext
{
    IQueryable<City> Cities { get; }
    IQueryable<Street> Streets { get; }
    IQueryable<Bank> Banks { get; }
    
    IQueryable<VehicleBrand> VehicleBrands { get; }
    IQueryable<VehicleModel> VehicleModels { get; }
    IQueryable<Vehicle> Vehicles { get; }
    
    IQueryable<Unit> Units { get; }
    IQueryable<CargoCategory> CargoCategories { get; }
    IQueryable<Cargo> Cargoes { get; }
    
    IQueryable<DriverCategory> DriverCategories { get; }
    IQueryable<Driver> Drivers { get; }
    
    IQueryable<Legal> Legals { get; }
    IQueryable<Individual> Individuals { get; }
    
    IQueryable<VehicleCargoCategory> VehicleCargoCategories { get; }
    IQueryable<OrderDriver> OrderDrivers { get; }
    IQueryable<OrderCargo> OrderCargoes { get; }

    IQueryable<Order> Orders { get; }
}