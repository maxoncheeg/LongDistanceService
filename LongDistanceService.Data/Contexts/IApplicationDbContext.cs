using LongDistanceService.Data.Entities;
using LongDistanceService.Data.Entities.Addresses;
using LongDistanceService.Data.Entities.Cargoes;
using LongDistanceService.Data.Entities.Drivers;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Data.Entities.Personals;
using LongDistanceService.Data.Entities.Vehicles;

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
    
    IQueryable<User> Users { get; }
    IQueryable<MenuTab> MenuTabs { get; }
    IQueryable<MenuTabRight> MenuTabRights { get; }
}