using InventoryServices.Application.Interfaces.IServices;
using InventoryServices.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryServices.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        return services.AddScoped<IProductService, ProductService>()
                       .AddScoped<IOrderService,OrderService>()
                       .AddScoped<IReportService,ReportService>();
    }
}
