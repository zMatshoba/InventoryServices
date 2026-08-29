using InventoryServices.Application.Dtos.ReportDto;
using InventoryServices.Application.Interfaces.IRepository;
using Microsoft.EntityFrameworkCore;

namespace InventoryServices.Infrastructure.Repository;

public class ReportRepository(InventoryDbContext dbContext) : IReportRepository
{
    public async Task<IReadOnlyList<DailySalesSqlResult>> GetSalesSummaryAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken)
    {
        return await dbContext.DailySalesViews.FromSqlInterpolated(
            $"""
                EXEC dbo.sp_GetDailySalesReportingSummary
                            @StartDate = {startDate.ToString("yyyy-MM-dd")},
                            @EndDate = {endDate.ToString("yyyy-MM-dd")}
            """).ToListAsync(cancellationToken);
    }
}
