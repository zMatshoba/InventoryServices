namespace InventorySystem.MVC.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddExternalService(this IServiceCollection services)
    {
        return services.AddScoped<IProductService, ProductService>()
                       .AddScoped<IReportService,ReportService>();
    }
}
