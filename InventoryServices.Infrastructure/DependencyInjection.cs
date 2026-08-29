using InventoryServices.Application.Interfaces.IRepository;
using InventoryServices.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryServices.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfigurationManager configuration)
    {
        var dbConnection = configuration.GetConnectionString("InventoryDb");

        return services.AddScoped<IProductRepository, ProductRepository>()
                       .AddScoped<IOrderRepository, OrderRepository>()
                       .AddScoped<IReportRepository, ReportRepository>()
                       .AddDbContext<InventoryDbContext>(options =>
                       {
                           options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                           options.UseSqlServer(dbConnection, options => options.EnableRetryOnFailure(maxRetryCount: 5));
                       });
    }
}
