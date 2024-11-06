using LongDistanceService.Domain.Entities;
using LongDistanceService.Domain.Entities.Addresses;
using LongDistanceService.Domain.Entities.Cargos;
using LongDistanceService.Domain.Entities.Personals;
using LongDistanceService.Domain.Entities.Vehicles;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext(options), IApplicationDbContext
{
    public DbSet<VehicleBrand> VehicleBrands { get; set; } 
    public DbSet<VehicleModel> VehicleModels { get; set; } 
    public DbSet<Vehicle> Vehicles { get; set; } 
    
    public DbSet<Unit> Units { get; set; }
    public DbSet<CargoCategory> CargoCategories { get; set; }
    public DbSet<Cargo> Cargoes { get; set; }
    
    public DbSet<VehicleCargoCategory> VehicleCargoCategories { get; set; }
    
    public DbSet<Bank> Banks { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Street> Streets { get; set; }
    public DbSet<Individual> Individuals { get; set; }
    public DbSet<Legal> Legals { get; set; }
    
    public DbSet<OrderCargo> OrderCargoes { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }
}