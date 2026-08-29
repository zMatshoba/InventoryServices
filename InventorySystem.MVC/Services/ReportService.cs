using InventorySystem.MVC.Configuration;
using InventorySystem.MVC.Models;
using InventorySystem.MVC.Services.HttpService;
using Microsoft.Extensions.Options;

namespace InventorySystem.MVC.Services
{
    public class ReportService(IHttpClientService httpClient,
                               IOptionsSnapshot<ApiEndpoints> options) : IReportService
    {

        public async Task<DailySalesSummaryModel> GetDailySalesSummaryAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
        {
            var route = options.Value.GetDailySalesSummary.Replace("{startdate}", startDate.ToString()).Replace("{enddate}", endDate.ToString());

            return await httpClient.HttpRetrieveByIdAsync<DailySalesSummaryModel>(route);
        }
    }
}
