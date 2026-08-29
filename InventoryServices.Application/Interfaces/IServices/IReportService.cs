using InventoryServices.Application.Dtos.ReportDto;

namespace InventoryServices.Application.Interfaces.IServices;

public interface IReportService
{
    Task<DailySalesResponseViewDto> GetDailySalesSummaryAsync(DateOnly startDate, DateOnly endDate,CancellationToken cancellationToken);
}
