using LongDistanceService.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LongDistanceService.Shared.DependencyInjection.Data;

public static class DataServicesExtensions
{
    public static IServiceCollection AddPostgresDatabase(this IServiceCollection @this, string connectionString) =>
        @this.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));
}