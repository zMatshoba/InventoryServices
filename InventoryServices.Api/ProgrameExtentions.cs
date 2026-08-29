using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace InventoryServices.Api;

public static class ProgrameExtentions
{
    public static IServiceCollection AddHealthCheckServices(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        var InventoryDbConnectionString = configuration.GetConnectionString("InventoryDb")
                                    ?? throw new InvalidOperationException("ConnectionStrings:InventoryDb is missing in configuration");

        services.AddHealthChecks()
                .AddCheck("Self", () => HealthCheckResult.Healthy())
                .AddSqlServer(
                    connectionString: InventoryDbConnectionString,
                    name: "Inventory DB",
                    failureStatus: HealthStatus.Unhealthy);

        return services;
    }
}
