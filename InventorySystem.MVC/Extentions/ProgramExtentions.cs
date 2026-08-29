using InventorySystem.MVC.Services.HttpService;

namespace InventorySystem.MVC.Extentions
{
    public static class ProgramExtentions
    {

        public static IServiceCollection AddHttpClientServices(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            string? baseAddress = configuration["HttpClientBase:InventorySystemBaseAddress"];

            if (baseAddress is not null)
            {
                services.AddHttpClient<IHttpClientService, HttpClientService>(client =>
                {
                    client.BaseAddress = new Uri(baseAddress);
                    //client.DefaultRequestHeaders.Add("XApiKey", configuration["Key:XApiKey"]);
                });
            }

            return services;
        }
    }
}
