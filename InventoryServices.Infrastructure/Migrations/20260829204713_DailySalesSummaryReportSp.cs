using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryServices.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DailySalesSummaryReportSp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"CREATE OR ALTER PROCEDURE [dbo].[sp_GetDailySalesReportingSummary]
@StartDate As Date,
@EndDate As Date
AS
BEGIN
SELECT CAST(o.PlacedAt AS DATE) AS [Date]
	  ,p.Sku
	  ,SUM(i.Qty) AS QtySold
	  ,SUM(i.UnitPrice * i.Qty) AS TotalSales
  FROM [InventorySystem].[dbo].[Orders] o
  JOIN Items i ON o.Id = i.OrderId
  JOIN Products p ON i.ProductId = p.Id
  WHERE CAST(o.PlacedAt AS DATE) >= @StartDate AND CAST(o.PlacedAt AS DATE) <= @EndDate
  GROUP BY CAST(o.PlacedAt AS DATE), p.Sku
  ORDER BY [Date],p.Sku
END
GO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
