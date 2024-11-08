using System.Reflection;
using LongDistanceService.Domain.Entities;
using LongDistanceService.Domain.Entities.Addresses;
using LongDistanceService.Domain.Entities.Cargoes;
using LongDistanceService.Domain.Entities.Drivers;
using LongDistanceService.Domain.Entities.Personals;
using LongDistanceService.Domain.Entities.Vehicles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext(options), IApplicationDbContext
{
    public IQueryable<City> Cities => Set<City>();
    public IQueryable<Street> Streets => Set<Street>();
    public IQueryable<Bank> Banks => Set<Bank>();
    public IQueryable<VehicleBrand> VehicleBrands => Set<VehicleBrand>();
    public IQueryable<VehicleModel> VehicleModels => Set<VehicleModel>();
    public IQueryable<Vehicle> Vehicles => Set<Vehicle>();
    public IQueryable<Unit> Units => Set<Unit>();
    public IQueryable<CargoCategory> CargoCategories => Set<CargoCategory>();
    public IQueryable<Cargo> Cargoes => Set<Cargo>();
    public IQueryable<DriverCategory> DriverCategories => Set<DriverCategory>();
    public IQueryable<Driver> Drivers => Set<Driver>();
    public IQueryable<Legal> Legals => Set<Legal>();
    public IQueryable<Individual> Individuals => Set<Individual>();
    public IQueryable<VehicleCargoCategory> VehicleCargoCategories => Set<VehicleCargoCategory>();
    public IQueryable<OrderDriver> OrderDrivers => Set<OrderDriver>();
    public IQueryable<OrderCargo> OrderCargoes => Set<OrderCargo>();
    public IQueryable<Order> Orders => Set<Order>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}