using InventoryServices.Application.Dtos.ReportDto;
using InventoryServices.Application.Interfaces.IRepository;
using InventoryServices.Application.Interfaces.IServices;

namespace InventoryServices.Application.Services;

public class ReportService(IReportRepository reportRepository) : IReportService
{
    public async Task<DailySalesResponseViewDto> GetDailySalesSummaryAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
    {
        var report = await reportRepository.GetSalesSummaryAsync(startDate, endDate,cancellationToken);

        var days = report.GroupBy(x => x.Date)
                            .Select(day => new DailySalesViewDto
                            {
                                Date = day.Key,
                                Products = [.. day.Select(product => new ProductSaleViewDto
                                {
                                    Sku = product.Sku,
                                    QtySold = product.QtySold,
                                    TotalSales = product.TotalSales,
                                })],
                                TotalQtySold = day.Select(qty => qty.QtySold).Sum(),
                                TotalSales = day.Select(sales => sales.TotalSales).Sum(),
                            }).ToList();
        return new DailySalesResponseViewDto
        {
            StartDate = startDate,
            EndDate = endDate,
            Days = days
        };
    }
}
