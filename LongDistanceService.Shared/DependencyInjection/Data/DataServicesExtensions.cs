using LongDistanceService.Data.Contexts;
using LongDistanceService.Data.Contexts.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.Data;

public static class DataServicesExtensions
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection @this, string connectionString) =>
        @this.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options => options.UseNpgsql(connectionString));

    public static IServiceCollection AddPostresConnection(this IServiceCollection @this, string connectionString) =>
        @this.AddScoped<ISqlConnection>(_ => new PostgreSqlConnection(connectionString));

}