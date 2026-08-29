namespace InventoryServices.Application.Dtos.ReportDto;

public class DailySalesSqlResult
{
    public DateOnly Date { get; set; }
    public string Sku { get; set; } = string.Empty;
    public int QtySold { get; set; }
    public decimal TotalSales { get; set; }
}
