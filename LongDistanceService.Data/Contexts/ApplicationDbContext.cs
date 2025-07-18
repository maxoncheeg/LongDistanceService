﻿using System.Reflection;
using LongDistanceService.Data.Contexts.Abstract;
using LongDistanceService.Data.Entities;
using LongDistanceService.Data.Entities.Addresses;
using LongDistanceService.Data.Entities.Cargoes;
using LongDistanceService.Data.Entities.Drivers;
using LongDistanceService.Data.Entities.Identity;
using LongDistanceService.Data.Entities.Personals;
using LongDistanceService.Data.Entities.Vehicles;
using LongDistanceService.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace LongDistanceService.Data.Contexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options), IApplicationDbContext
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
    public IQueryable<User> Users => Set<User>();
    public IQueryable<AuthProvider> AuthProviders => Set<AuthProvider>();
    public IQueryable<Role> Roles => Set<Role>();
    public IQueryable<UserRole> UserRoles => Set<UserRole>();
    public IQueryable<TwoFactorSecret> TwoFactorSecrets => Set<TwoFactorSecret>();
    public IQueryable<Application> Applications => Set<Application>();
    public IQueryable<ApplicationMessage> ApplicationMessages  => Set<ApplicationMessage>();

    public async Task CreateAsync<TEntity>(TEntity entity) where TEntity : class
    {
        await Set<TEntity>().AddAsync(entity);
    }

    public async Task CreateRangeAsync<TEntity>(IList<TEntity> entities) where TEntity : class
    {
        await Set<TEntity>().AddRangeAsync(entities);
    }

    public new void Update<TEntity>(TEntity entity) where TEntity : class
    {
        Set<TEntity>().Update(entity);
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
        Set<TEntity>().Remove(entity);
    }

    public void DeleteRange<TEntity>(IList<TEntity> entities) where TEntity : class
    {
        Set<TEntity>().RemoveRange(entities);
    }

    public async Task SaveAsync()
    {
        await SaveChangesAsync();
    }

    public IQueryable<IList<object>> SqlQuery(string query)
    {
        return Database.SqlQueryRaw<List<object>>(query);
    }

    public int ExecuteSql(string query)
    {
        return Database.ExecuteSqlRaw(query);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}