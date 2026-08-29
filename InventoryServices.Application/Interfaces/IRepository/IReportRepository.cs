using InventoryServices.Application.Dtos.ReportDto;

namespace InventoryServices.Application.Interfaces.IRepository;

public interface IReportRepository
{
    Task<IReadOnlyList<DailySalesSqlResult>> GetSalesSummaryAsync(DateOnly startDate, DateOnly endDate,CancellationToken cancellationToken);
}
