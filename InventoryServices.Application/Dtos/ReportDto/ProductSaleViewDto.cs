namespace InventoryServices.Application.Dtos.ReportDto;

public class ProductSaleViewDto
{
    public string Sku { get; set; } = string.Empty;
    public int QtySold { get; set; }
    public decimal TotalSales { get; set; } 
}
