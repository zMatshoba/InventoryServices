namespace InventorySystem.MVC.Configuration;

public class ApiEndpoints
{
    public string GetProducts { get; set; } = string.Empty;
    public string GetProduct { get; set; } = string.Empty;
    public string CreateProduct { get; set; } = string.Empty;
    public string UpdateProduct { get; set; } = string.Empty;
    public string StockAdjustment { get; set; } = string.Empty;
    public string CreateOrder { get; set; } = string.Empty;
    public string GetOrders { get; set; } = string.Empty;
    public string GetDailySalesSummary { get; set; } = string.Empty;
}
