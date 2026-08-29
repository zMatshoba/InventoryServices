namespace InventoryServices.Application.Dtos.ReportDto;

public class DailySalesViewDto
{
    public DateOnly Date { get; set; }

    public List<ProductSaleViewDto> Products { get; set; } = [];

    public int TotalQtySold { get; set; }   

    public decimal TotalSales { get; set; } 

}
