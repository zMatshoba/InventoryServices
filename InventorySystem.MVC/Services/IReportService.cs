using InventorySystem.MVC.Models;

namespace InventorySystem.MVC.Services
{
    public interface IReportService
    {
        Task<DailySalesSummaryModel> GetDailySalesSummaryAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken);
    }
}